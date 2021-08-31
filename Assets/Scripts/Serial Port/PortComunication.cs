using UnityEngine;
using System.IO.Ports;
using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections.Concurrent;
using System.IO;
using DataFromXML;

namespace DataFromArduino
{
    public class PortComunication
    {

        internal delegate void MessReady(string mess);
        internal static event MessReady MessageReceived;

        internal delegate void NameReady(string mess);
        internal static event NameReady DeviceNameReceived;

        private readonly SerialPort _port;

        private bool _checkMess = true;

        private string _deviceName;
        private bool _isFirstMessage = true;

        //сборка начальных положений с девайса осуществляеться до сообщения stop
        private bool _isSetupEnd = false;
        private const string _setupEndMessage = "stop";

        private bool _isThisDeviceNeed = true;

        private InitialPositionFromArduino _initPosition;

        public PortComunication(SerialPort port)
        {
            this._port = port;
            port.Open();

            _deviceName = port.PortName;
            DeviceNameReceived?.Invoke(_deviceName);
            Thread portThread = new Thread(ReadPort)
            {
                Name = port.PortName
            };
            portThread.Start();

            _initPosition = new InitialPositionFromArduino();
        }

        private void ReadPort()
        {
            DevicesManager.AppIsClosed += ClosePort;
            DevicesManager.DeviceIsDisconect += ClosePort;

            while (_checkMess)
            {
                try
                {
                    ParseRead();
                    Thread.Sleep(1);

                } catch (IOException e)
                {
                    //при отключении устройства происходит загрузка сцены дисконекта
                    DisconnectEvent.instance.ReciveRestart();
                    ClosePort();
                }

            }

        }

        private void ParseRead()
        {
            if (_port.BytesToRead > 0 && _isThisDeviceNeed)
            {
                var mess = _port.ReadLine();
                _port.BaseStream.FlushAsync();
                SetDeviceSettings(mess);
                MessageReceived?.Invoke(mess);
            }

        }

        //TODO state pattern
        private void SetDeviceSettings(string input)
        {   
            //первое сообщения с устройства является его именем
            if (_isFirstMessage)
            {
                _deviceName = input;
                CheckIsDeviceNeed();
                _isFirstMessage = false;
                DeviceNameReceived?.Invoke(input);
            }

            //сообщения после стоп , будут редактировать словарь начальных положений
            if (_isSetupEnd)
            {
                _initPosition.EditDictionary(_deviceName, input);
            }

            //до конца устанвки формируется словарь начальных положений
            if (!_isSetupEnd && _isThisDeviceNeed)
            {
                SetDeviceInitialPosition(_deviceName, input);
                if (input == _setupEndMessage)
                {
                    _isSetupEnd = true;
                }
            }
        }

        private void CheckIsDeviceNeed()
        {
            if (!DeviceName.DeviceNames.Contains(_deviceName))
            {
                _isThisDeviceNeed = false;
            }
        }

        private void SetDeviceInitialPosition(string deviceName, string input)
        {
            _initPosition.ReceiveInput(deviceName, input);
        }

        public string GetPortName()
        {
            return _deviceName;
        }

        public void SendToPort(string message)
        {
            _port.WriteLine(message);
        }

        private void ClosePort()
        {
            DevicesManager.AppIsClosed -= ClosePort;
            DevicesManager.DeviceIsDisconect -= ClosePort;

            _checkMess = false;
            _port.Dispose();
            _port.Close();
        }
    }
}