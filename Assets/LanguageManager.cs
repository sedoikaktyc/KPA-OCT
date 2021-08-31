using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace Language
{

    public class LanguageManager : MonoBehaviour
    {
        public static LanguageManager Instance;

        public delegate void XmlLoaded();
        public static event XmlLoaded Message;


        private XmlDocument xmlDoc;
        private TextAsset textXml;
        [SerializeField]
        public List<Control> Controls = new List<Control>();
        private string fileName;

        [System.Serializable]
        public struct Control
        {
            public int Id;
            public string RU;
            public string EN;
        };

        private void Awake()
        {
            Instance = this;
            fileName = "ru_en.xml";


        }


        // Start is called before the first frame update
        void Start()
        {
            loadXMLFromAssest();
            readXml();
        }

        private void loadXMLFromAssest()
        {
            xmlDoc = new XmlDocument();
            if (System.IO.File.Exists(getPath()))
            {
                xmlDoc.LoadXml(System.IO.File.ReadAllText(getPath()));
            }
            else
            {
                textXml = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
                xmlDoc.LoadXml(textXml.text);
            }
        }

        private void readXml()
        {
            foreach (XmlElement node in xmlDoc.SelectNodes("Controls/Control"))
            {
                Control tempControl = new Control();
                tempControl.Id = int.Parse(node.GetAttribute("id"));
                tempControl.RU = node.SelectSingleNode("RU").InnerText;
                tempControl.EN = node.SelectSingleNode("EN").InnerText;
                Controls.Add(tempControl);

            }
            VVV();
        }

        public void VVV() {

            Message?.Invoke();

        }



        private string getPath()
        {
#if UNITY_EDITOR
            return Application.dataPath + "/Resources/XML/" + fileName;
#else
        return Application.dataPath +"/XML/"+ fileName;
#endif
        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}