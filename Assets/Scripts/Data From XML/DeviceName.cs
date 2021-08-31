using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace DataFromXML
{
    public class DeviceName : MonoBehaviour
    {

        internal delegate void NamesHandler(List<string> deviceNames);
        internal static event NamesHandler NamesRecived;

        internal static List<string> DeviceNames { get; private set; }

        private const string ParentElement = "devices";
        private const string ChildElement = "device";
        private const string Attribute = "nameDevice";
        private const string PartPath = "_init";

        private readonly XML _xml = new XML();
        private XDocument _init;

        private void Awake()
        {
            DeviceNames = new List<string>();
        }

        public void ReceiveDeviceName(string lessonNumber)
        {
            _init = _xml.LoadXML(lessonNumber + PartPath);

            bool hasElement = _init.Descendants(ParentElement).Any();
            if (hasElement)
            {
                foreach (XElement deviceElement in _init.Element(ParentElement).Elements(ChildElement))
                {
                    XAttribute nameDevice = deviceElement.Attribute(Attribute);
                    DeviceNames.Add(nameDevice.Value);

                    GetComponent<InitialPositions>().ReceiveInitialPosition(deviceElement, nameDevice.Value);
                }

                NamesRecived?.Invoke(DeviceNames);
            } else
            {
                Debug.Log(": <color=red> Ошибка в XML файле " + lessonNumber + PartPath + ".xml. " +
                                "Файл должен содержать родительский элемент " + ParentElement + ", дочерний элементом " + ChildElement + " " +
                                ", атрибут  " + Attribute + ", значение которого имя прибора согласованное со скетчем.</color>");
            }
        }
    }
}
