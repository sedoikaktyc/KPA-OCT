using UnityEngine;
using System.IO.Ports;
using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections.Concurrent;
using UnityEngine.EventSystems;
using DataFromArduino;


/// <summary>
/// класс графического отображения работы с SerialPort
/// для активации окна нажать клавишу R
/// </summary>
public class TestPortUI : MonoBehaviour
{
    public static TestPortUI instance;

    public delegate void MessageToSend(string mess, int indexDevice);
    public static event MessageToSend MessageToSendReady;

    [SerializeField]
    private GameObject testingWindow;
    private bool IsWindowShow;

    [SerializeField]
    private Text messageFromDevice;

    [SerializeField]
    private Toggle togglePort;

    [SerializeField]
    private GameObject conntentOfScroll;

    [SerializeField]
    private ScrollRect scrollMessageFromArduino;

    [SerializeField]
    private InputField textFiealdToSendInPort;
    private string messToSend;

    private List<Toggle> toggles = new List<Toggle>();
    private int indexOfPort = -1;

    private bool needToScrollMessageWindow;

    private void Awake()
    {
        InstantiateTestUI();
    }

    private void Start()
    {
        DevicesManager.MessageFromDeviceReady += ShowMessageFromDevice;
        DevicesManager.DeviceIsDisconect += UnsubscribeUI;
    }

    private void InstantiateTestUI()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        ControlOfVisibleTestWindow();
    }

    private void FixedUpdate()
    {
        ScrollMessageWindowDown();
    }

    private void ControlOfVisibleTestWindow()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            IsWindowShow = !IsWindowShow;
            testingWindow.SetActive(IsWindowShow);
        }
    }

    public void SetTogglesOnUi()
    {
        var portsName = DevicesManager.PortNames;

        foreach (var name in portsName)
        {
            Toggle togg = Instantiate(togglePort);

            togg.gameObject.name = name;
            togg.transform.SetParent(conntentOfScroll.transform, false);
            togg.GetComponentInChildren<Text>().text = name;
            togg.gameObject.SetActive(true);

            //добавил делегат функции после создания toggle
            togg.onValueChanged.AddListener(delegate { ToggleContoll(); });

            toggles.Add(togg);
        }
    }

    public void ToggleContoll()
    {
        var currentToggle = EventSystem.current.currentSelectedGameObject;
        if (currentToggle.GetComponent<Toggle>().isOn)
        {

            foreach (var togg in toggles)
            {
                if (togg != currentToggle.GetComponent<Toggle>())
                {
                    togg.isOn = false;
                }

            }

            indexOfPort = toggles.IndexOf(currentToggle.GetComponent<Toggle>());

        }
        else
        {
            indexOfPort = -1;
        }
    }

    public void SendMessageToDevice()
    {
        if (indexOfPort != -1)
        {
            messToSend = textFiealdToSendInPort.text;
            MessageToSendReady?.Invoke(messToSend, indexOfPort);
        }
        else
        {
            Debug.LogError("Порт выбран не верно!");
        }
    }

    private void ShowMessageFromDevice(string massage)
    {
        messageFromDevice.text = messageFromDevice.text + "\n" + massage;
        needToScrollMessageWindow = true;

        CutLongString();
    }

    private void CutLongString()
    {
        if (messageFromDevice.text.Length > 3000)
        {
            messageFromDevice.text = messageFromDevice.text.Substring(1500, 1500);
        }
    }

    private void ScrollMessageWindowDown()
    {
        if (needToScrollMessageWindow)
        {
            scrollMessageFromArduino.normalizedPosition = new Vector2(0f, 0f);
            needToScrollMessageWindow = false;
        }
    }

    private void UnsubscribeUI()
    {
        DevicesManager.MessageFromDeviceReady -= ShowMessageFromDevice;
        DevicesManager.DeviceIsDisconect -= UnsubscribeUI;
    }
}
