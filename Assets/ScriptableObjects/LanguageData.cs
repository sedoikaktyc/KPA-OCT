using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Init Data", menuName = "ScriptableObject/LanguageSettings")]
    public class LanguageData : ScriptableObject
    {
        public string CurrentLanguage { get; set; }
        public Dictionary<string, string> CurrentObjectText { get; set; }
    }
}
