using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace DataFromArduino
{
    public class InitialPositionFromArduino
    {
        public static ConcurrentDictionary<string, int> DevicesInitialPositions { get; private set;}

        private InputSeparator _separator;

        private List<string> _excludedInput = new List<string>() { "complite", "stop" };

        public InitialPositionFromArduino()
        {
            _separator = new InputSeparator("Device");
            DevicesInitialPositions = new ConcurrentDictionary<string, int>();
        }

        public void ReceiveInput(string name, string data)
        {
            if (name != data && !_excludedInput.Contains(data))
            {
                var key = _separator.ReceiveConnectDeviceAndControllnames(name, data);
                var value = _separator.ReceiveInitialPosition(data);
                DevicesInitialPositions.TryAdd(key, value);
            }

            if (data == _excludedInput[1]) {
                DataForComparison.Instance.AddSetupFinishedDevice();
            }
        }

        public void EditDictionary(string name, string data) {

            var key = _separator.ReceiveConnectDeviceAndControllnames(name, data);
            var value = _separator.ReceiveInitialPosition(data);

            if (DevicesInitialPositions.ContainsKey(key))
            {
                DevicesInitialPositions[key] = value;
                DataForComparison.Instance.SendComparisonData();
            } else {
                ErrorNoControllInDictionary(key);
            }
        }

        private void ErrorNoControllInDictionary(string key)
        {
            Debug.LogError("С подключенного устройства пришла команда от органа управления -" +
                key + " которого нет в списке начальных условий.");
        }
    }
}
