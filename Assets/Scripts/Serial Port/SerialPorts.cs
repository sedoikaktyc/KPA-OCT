using UnityEngine;
using System.IO.Ports;
using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;

namespace DataFromArduino
{
    public class SerialPorts
    {
        internal int OpenPortsCount { get; private set; }

        internal delegate void NotFoundDevice();
        internal static event NotFoundDevice DevicesNotFound;

        internal delegate void FoundDevice();
        internal static event FoundDevice DevicesFound;

        private string[] _portNames;
        private string[] _deviceNames;
        private List<PortComunication> _ports = new List<PortComunication>();
        private const int _baudRate = 115200;

        public void PortsSearch()
        {
            _portNames = SerialPort.GetPortNames();
            _deviceNames = _portNames;
            OpenPortsCount = _portNames.Length;

            if (_portNames.Length <= 0)
            {
                DevicesNotFound?.Invoke();
            } else
            {
                DevicesFound?.Invoke();
                CreatePorts();
            }
        }

        private void CreatePorts()
        {
            for (int i = 0; i < _portNames.Length; i++)
            {
                SerialPort port = new SerialPort(_portNames[i], _baudRate);
                port.ReadTimeout = 2000;
                port.DtrEnable = true;
                port.RtsEnable = true;

                PortComunication newPort = new PortComunication(port);
                _ports.Add(newPort);


                _deviceNames[i] = newPort.GetPortName();
            }
        }

        public string[] GetPortsName()
        {
            return _portNames;
        }

        public void SendToPort(string message, int kpaIndex)
        {
            _ports[kpaIndex].SendToPort(message);
        }
    }
}