using DataFromXML;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using ScriptableObjects;

namespace LanguageSettings
{
    public class LanguageXML : MonoBehaviour
    {
        public static LanguageXML Instance;
        public string ChosenLanguage { get; set; }
        public Dictionary<string, string> LanguageOption { get; private set; }
        [SerializeField]
        public Dictionary<string, LanguageSubs> LanguageDictionary { get; private set; }

        public List<string> LanguageOptionKeyList = new List<string>();

        public delegate void ChangeLanguage();
        public static event ChangeLanguage LanguageChangeNow;

        private LoginAndPassController LoginAndPass;

        private XML _xml;
        private XDocument _languageSettings;
        private XDocument _languageSubs;

        private const string LanguageXMLSettingsName = "LanguageSettings";
        private const string LanguageXMLSunsName = "LanguageDictionary";
        private const string ParentElemnt = "languageSettings";
        private const string ParentSubsElemnt = "languageSubs";
        private const string LanguageElement = "language";
        private const string LanguageOptionElement = "languageOption";
        private const string LanguageDesignationElement = "languageDesignation";
        private const string LanguangeAttribure = "name";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            DontDestroyOnLoad(this);

           LanguageOption = new Dictionary<string, string>();
            LanguageDictionary = new Dictionary<string, LanguageSubs>();
            ParseXML();
        }
        private void Start()
        {
            
        }

        private void ParseXML()
        {
            _xml = new XML();
            _languageSettings = _xml.LoadXML(LanguageXMLSettingsName);

            foreach (XElement deviceElement in _languageSettings.Element(ParentElemnt).Elements(LanguageElement))
            {
                ChosenLanguage = deviceElement.Value;
            }

            foreach (XElement deviceElement in _languageSettings.Element(ParentElemnt).Elements(LanguageOptionElement))
            {
                var attributeValue = deviceElement.Attribute(LanguangeAttribure).Value;
                LanguageOption.Add(attributeValue, deviceElement.Value);
                LanguageOptionKeyList.Add(attributeValue);
            }

            _languageSubs = _xml.LoadXML(LanguageXMLSunsName);

            
            foreach (XElement deviceElement in _languageSubs.Element(ParentSubsElemnt).Elements(LanguageDesignationElement))
            {
                var attributeValue = deviceElement.Attribute(LanguangeAttribure).Value;

                LanguageDictionary.Add(attributeValue, new LanguageSubs() { RuText = deviceElement.Value.Split('#')[0], EngText  = deviceElement.Value.Split('#')[1] });
                
            }


            Debug.Log(TakeText("login"));
            //LanguageChangeNow?.Invoke();
            
        }

        public string TakeText(string KeyForSearchingInTheDictionary)
        {
            if (ChosenLanguage == "Ru") return LanguageDictionary[KeyForSearchingInTheDictionary].RuText;
            else if (ChosenLanguage == "Eng") return LanguageDictionary[KeyForSearchingInTheDictionary].EngText;
            else return "text_doesnt_found";

        }
    }

    public class LanguageSubs
    {
        public string RuText;
        public string EngText;
    }
}