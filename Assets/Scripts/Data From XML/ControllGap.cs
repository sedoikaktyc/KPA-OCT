using UnityEngine;
using ScriptableObjects;
using System.Xml.Linq;
using System;
using Utils;
using System.Collections.Generic;

namespace DataFromXML
{
    public class ControllGap : MonoBehaviour
    {
        public ControllsData InitialPositionData;

        private const string ChildElement = "luft";
        //учитывается только левый люфт так как в XML правый и левый люфт всегда должны быть одинаковыми
        private const string GapElement = "left";

        private void Awake()
        {
            InitialPositionData.ControllsGap = new Dictionary<string, int>();
        }

        public void SetGapControll(XElement controllElement, string dictionaryKey)
        {
            XElement gapElement = controllElement.Element(ChildElement);
            XElement gap = gapElement.Element(GapElement);

            if (gapElement == null || gap == null)
                SendErrorInXMLLog();

            if (!InitialPositionData.ControllsGap.ContainsKey(dictionaryKey))
            {
                InitialPositionData.ControllsGap.Add(dictionaryKey, int.Parse(gap.Value));
            }
        }

        private void SendErrorInXMLLog()
        {
            Debug.LogError("Oшибка в заполнении XML файла начальных условий. " +
                "Отсутствует люфт одного из органов управления.");
        }
    }
}
