using System;
using UnityEngine;

namespace Utils
{
    public class InputSeparator
    {
        private const char _separator = '#';
        private const int _separatorCount = 3;
        private string _dataFrom;

        /// <summary>
        /// констуктор объекта принимает строку 
        /// с указанием откуда отправляются данные 
        /// </summary>
        /// <param name="dataFrom"></param>
        public InputSeparator(string dataFrom)
        {
            _dataFrom = dataFrom;
        }

        public string ReceiveConnectDeviceAndControllnames(string name, string controll)
        {
            var separationInput = controll.Split(_separator);
            var controllName = separationInput[0] + separationInput[1];
            return name + controllName;
        }

        public int ReceiveInitialPosition(string controll)
        {
            var separationInput = controll.Split(_separator);

            if (separationInput.Length == _separatorCount)
            {
                var controllPosition = 0;
                if (separationInput[2].Contains("."))
                {
                    controllPosition = Convert.ToInt32(separationInput[2].Substring(0, separationInput[2].IndexOf(".")));
                } else
                {
                    controllPosition = Convert.ToInt32(separationInput[2]);
                }
                return controllPosition;
            } else
            {
                SendErrorInInitialPositionXML(controll);
                return int.Parse("404 " + _dataFrom);
            }
        }


        private void SendErrorInInitialPositionXML(string errorData)
        {
            Debug.Log(": <color=red> Ошибка во входящих данных начальных положений. " +
                      " Ошибка произошла в - " +
                      _dataFrom + "." +
                      " Ошибка во входящем сообщении " + errorData + "</color>");
        }
    }
}
