using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using Utils;

namespace DataFromXML
{
    public class InitialPositions : MonoBehaviour
    {
        public static Dictionary<string, int> XMLDevicesInitPositions { get; private set; }

        private const string ParentElement = "initialPositions";
        private const string ChildElement = "control";
        private const string Attribute = "name";
        private const string ControlChildElement = "position";

        private InputSeparator _separator;

        private XElement _controllElement;

        private void Awake()
        {
            XMLDevicesInitPositions = new Dictionary<string, int>();
            _separator = new InputSeparator("XML");
        }

        public void ReceiveInitialPosition(XElement deviceElement, string deviceName)
        {
            bool hasElement = deviceElement.Descendants(ParentElement).Any();
            bool hasElement2 = deviceElement.Descendants(ParentElement).Elements(ChildElement).Any();


            if (hasElement && hasElement2)
            {
                foreach (var controllElement in deviceElement.Element(ParentElement).Elements(ChildElement))
                {
                    XAttribute control = controllElement.Attribute(Attribute);
                    XElement position = controllElement.Element(ControlChildElement);

                    _controllElement = controllElement;

                    if (control == null || position == null)
                        SendErrorInXMLLog();

                    SetPositions(deviceName, control.Value + position.Value);
                }
            } else
            {
                SendErrorInXMLLog();
            }
        }

        /// <summary>
        /// сборка начальных позиций  устройства
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="controlAndPosition"></param>
        private void SetPositions(string deviceName, string controlAndPosition)
        {
            if (!XMLDevicesInitPositions.ContainsKey(_separator.ReceiveConnectDeviceAndControllnames(deviceName, controlAndPosition)))
            {
                var key = _separator.ReceiveConnectDeviceAndControllnames(deviceName, controlAndPosition);
                var value = _separator.ReceiveInitialPosition(controlAndPosition);
                XMLDevicesInitPositions.Add(key, value);

                GetComponent<ControllGap>().SetGapControll(_controllElement, key);
                GetComponent<RealControllData>().SetRealData(_controllElement, key);
            }

        }

        private void SendErrorInXMLLog()
        {
            Debug.Log(": <color=red> Ошибка в XML файле инициализации начальных положений " +
                                "Файл должен содержать родительский элемент " + ParentElement + ", дочерний элемент " + ChildElement + " " +
                                ", атрибут  " + Attribute + ", значение которого имя органа управления." +
                                "Позиция органа управления должна быть в указана в дочернем элементе " + ControlChildElement + ".</color>");
        }

    }

}