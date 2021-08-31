using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataFromArduino;
using DataFromXML;
using System;
using System.Collections.Concurrent;
using ScriptableObjects;
using StartPosition;

public class DataForComparison : MonoBehaviour
{
    public static DataForComparison Instance;

    public ControllsData AllInitialData;

    private Comparison _comparison;
    private InitialPositionDisplay _initialPositionDisplay;

    private int _deviceCount = 0;
    private int _setupFinishedDevices = 0;

    private ConcurrentQueue<bool> m_queuedLogs = new ConcurrentQueue<bool>();

    private void Awake()
    {
        _comparison = new Comparison();

        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
        DeviceName.NamesRecived += SetDeviceNamesFromXML;
        PortComunication.DeviceNameReceived += SetDeviceNamesFromArduino;
    }

    private void SetDeviceNamesFromArduino(string name)
    {
        _comparison.CompareNameFromXMLandDevice(name);
    }

    private void SetDeviceNamesFromXML(List<string> deviceNames)
    {
        _deviceCount = deviceNames.Count;
        _comparison.MakeDictFromList(deviceNames);
    }

    public void AddSetupFinishedDevice()
    {
        _setupFinishedDevices++;
        //TODO протестировань на устройствах с большим колличество органов управления
        if (_setupFinishedDevices >= _deviceCount)
        {
            SendComparisonData();
        }
    }

    public void SendComparisonData()
    {
        AllInitialData.DevicePositions = InitialPositionFromArduino.DevicesInitialPositions;
        AllInitialData.XMLPositions = InitialPositions.XMLDevicesInitPositions;
        _comparison.CompareInitialPosition(AllInitialData.XMLPositions, AllInitialData.DevicePositions, AllInitialData.ControllsGap);

        SetInitialData();
    }

    public void SetInitialData()
    {
        AllInitialData.Devices = _comparison.GetDevices();
        AllInitialData.IncorrectPosition = _comparison.IncorrectPosition;
    }

    public void TrySendDataToInitialScene(bool comparisonStatus)
    {
        m_queuedLogs.Enqueue(comparisonStatus);
    }


    private void Update()
    {
        while (m_queuedLogs.TryDequeue(out bool comparisonStatus))
        {
            SendDataToInitialScene(comparisonStatus);
        }
    }

    public void SendDataToInitialScene(bool comparisonStatus)
    {
        if (_initialPositionDisplay == null)
        {
            _initialPositionDisplay = FindObjectOfType<InitialPositionDisplay>();
        }

        if (_initialPositionDisplay != null)
        {
            _initialPositionDisplay.CheckDeviceComparionStatus(comparisonStatus);
        }
    }

    public void Unsubscribe()
    {
        DeviceName.NamesRecived -= SetDeviceNamesFromXML;
        PortComunication.DeviceNameReceived -= SetDeviceNamesFromArduino;
    }
}
