using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ComprasionInitialPosition
{
    public interface IComprasionAlgorithm
    {

        public Dictionary<string, string> XMLcontrolPosition { get; set; }
        public Dictionary<string, string> ArduinoControlPosition { get; set;}
        public bool CompareControlPosition(Dictionary<string, string> positionsFromXML, Dictionary<string, string> positionsFromDevice);
       
    }
}