using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Init Data", menuName = "ScriptableObject/Initial Position So")]
    public class ControllsData : ScriptableObject
    {
        public Dictionary<string, bool> Devices { get; set; }
        public Dictionary<string, int> XMLPositions { get; set; }
        public ConcurrentDictionary<string, int> DevicePositions { get; set; }
        public List<string> IncorrectPosition { get; set; }
        public Dictionary<string, int> ControllsGap { get; set; }
        public Dictionary<string, string> ControllsRealPosition { get; set; }
        public Dictionary<string, string> ControllsRealName { get; set; }
    }
}
