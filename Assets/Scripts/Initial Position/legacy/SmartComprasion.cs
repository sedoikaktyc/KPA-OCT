using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComprasionInitialPosition
{
    public class SmartComprasion : IComprasionAlgorithm
    {
        public Dictionary<string, string> XMLcontrolPosition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Dictionary<string, string> ArduinoControlPosition { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool CompareControlPosition(Dictionary<string, string> positionsFromXML, Dictionary<string, string> positionsFromDevice)
        {
            throw new System.NotImplementedException();
        }

    }
}