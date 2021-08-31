using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections;

namespace DataFromArduino
{
    public class DevicesManager : MonoBehaviour
    {
        public static string[] PortNames { get; private set; }
        public static List<string> DeviceNames { get; private set; }

        public delegate void AppClose();
        public static event AppClose AppIsClosed;

        public delegate void MessageFromDevice(string message);
        public static event MessageFromDevice MessageFromDeviceReady;

        public delegate void Disconect();
        public static event Disconect DeviceIsDisconect;

        public delegate void DeviceNamesHandler(List<string> deviceNames);
        public static event DeviceNamesHandler DeviceNamesRecived;

        private static DevicesManager instance;

        private SerialPorts arduinoInit;

        private ConcurrentQueue<string> m_queuedLogs = new ConcurrentQueue<string>();

        private void Awake()
        {
            InstantiateManager();
        }

        private void Start()
        {
            PortComunication.MessageReceived += ReceiveMessage;
            TestPortUI.MessageToSendReady += SendToDevice;
            SerialPorts.DevicesFound += InitPorts;
            SerialPorts.DevicesNotFound += RestartDeviceSearch;

            arduinoInit = new SerialPorts();
            arduinoInit.PortsSearch();

            DeviceNames = new List<string>();
        }

        private void InstantiateManager()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void RestartDeviceSearch()
        {
            StartSceneController.Instance.ReciveStatus(StartSceneController.InitialPositionCheckState.Reconnect);
            StartText.Instance.ShowNoDeviceInPortMessage();
        }

        private void InitPorts()
        {
            PortNames = arduinoInit.GetPortsName();
            TestPortUI.instance.SetTogglesOnUi();
        }

        private void ReceiveMessage(string mess)
        {
            m_queuedLogs.Enqueue(mess);
        }

        private void Update()
        {
            while (m_queuedLogs.TryDequeue(out string message))
            {
                MessageFromDeviceReady?.Invoke(message);
            }
        }

        public void SendToDevice(string mess, int deviceIndex)
        {
            //сообщения на стороне ардуино принимаются до следующей строки
            arduinoInit.SendToPort(mess + "\n", deviceIndex);
        }


        public void CloseAllPorts() {

            Destroy(gameObject);
            AppIsClosed?.Invoke();
        }

        //скопировать для закрытия сцены
        private void OnApplicationQuit()
        {
            Destroy(gameObject);
            AppIsClosed?.Invoke();
        }

        public static void DisconnectDevice()
        {
            instance.UnsubscribeFromEvenets();
            DeviceIsDisconect?.Invoke();
        }

        //для коректной перезагрузки стартовой сцены необходимо отписаться от всех событий связанных с работой serial port
        private void UnsubscribeFromEvenets()
        {
            PortComunication.MessageReceived -= ReceiveMessage;
            TestPortUI.MessageToSendReady -= SendToDevice;
            SerialPorts.DevicesFound -= InitPorts;
            SerialPorts.DevicesNotFound -= RestartDeviceSearch;
        }
    }
}