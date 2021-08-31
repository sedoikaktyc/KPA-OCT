using UnityEngine;
using ScriptableObjects;
using Utils;
using System.Xml.Linq;
using System.Collections.Generic;

namespace DataFromXML
{
    public class RealControllData : MonoBehaviour
    {
        public ControllsData InitialPositionData;

        private const string ChildElement = "uprav";
        private const string NameElement = "name";
        private const string PositionElement = "poloz";

        private void Awake()
        {
            InitialPositionData.ControllsRealName = new Dictionary<string, string>();
            InitialPositionData.ControllsRealPosition = new Dictionary<string, string>();
        }

        public void SetRealData(XElement controllElement, string dictionaryKey)
        {
            XElement realDataElement = controllElement.Element(ChildElement);
            XElement name = realDataElement.Element(NameElement);
            XElement position = realDataElement.Element(PositionElement);

            if (position == null || name == null || realDataElement == null)
            {
                SendErrorInXMLLog();
            }

            if (!InitialPositionData.ControllsRealName.ContainsKey(dictionaryKey))
            {
                InitialPositionData.ControllsRealName.Add(dictionaryKey, name.Value);
                InitialPositionData.ControllsRealPosition.Add(dictionaryKey, position.Value);
            }
        }

        private void SendErrorInXMLLog()
        {
            Debug.LogError("Oшибка в заполнении XML файла начальных условий. " +
                "Отсутствует имя и реальное положение одного из органов управления.");
        }
    }
}
