using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects;

namespace LanguageSettings
{
    public class UIDropdownLanguages : MonoBehaviour
    {

        public LanguageData LanguageData;

        public delegate void ChangeLanguageNow();
        public static event ChangeLanguageNow LanguageChangeNow;

        private Dropdown _dropdown;
        private LanguageXML _languageXML;
        private readonly List<string> _languageSign = new List<string>();

        private void Awake()
        {
            _dropdown = GetComponent<Dropdown>();
            _dropdown.onValueChanged.AddListener(delegate { ChangeLanguage(); });

            _languageXML = FindObjectOfType<LanguageXML>();
        }

        private void Start()
        {
            SetDropdownOptions();
        }

        private void SetDropdownOptions()
        {
            var languageOptions = new List<string>();
            foreach (var keyValue in _languageXML.LanguageOption)
            {
                languageOptions.Add(keyValue.Value);
                _languageSign.Add(keyValue.Key);
            }

            _dropdown.AddOptions(languageOptions);

            foreach (var keyValue in _languageXML.LanguageOption)
            {
                if (keyValue.Key == _languageXML.ChosenLanguage)
                {
                    _dropdown.value = languageOptions.IndexOf(keyValue.Value); 
                }
            }

            LanguageData.CurrentLanguage = _languageXML.ChosenLanguage;
            ChangeLanguage();
        }

        private void ChangeLanguage()
        {
            LanguageData.CurrentLanguage = _languageSign[_dropdown.value];


            _languageXML.ChosenLanguage = LanguageXML.Instance.LanguageOptionKeyList[_dropdown.value];
            
            LanguageChangeNow?.Invoke();

        }
    }
}
