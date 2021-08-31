using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.EventSystems;

public class ListType : MonoBehaviour
{

    private Dropdown _dropdown;
    [SerializeField]
    private List<string> _pziNames = new List<string>();
    [SerializeField]
    private Button _nextBtn;

    private void Awake()
    {
        _dropdown = transform.GetComponentInChildren<Dropdown>();
       
        //_dropdown.OnSelect
        //_dropdown.onSelect.AddListener(delegate { ChangePzi(); });
    }

    IEnumerator BtnDisable()
    {
        bool run = true;
        while (run)
        {
            _nextBtn.gameObject.GetComponent<Button>().interactable = false;
              
                _nextBtn.gameObject.GetComponentInChildren<Text>().text = "-";
            yield return new WaitForSeconds(0.7f);
            _nextBtn.gameObject.GetComponentInChildren<Text>().text = "- -";
            yield return new WaitForSeconds(0.7f);
            _nextBtn.gameObject.GetComponentInChildren<Text>().text = "- - -";
            yield return new WaitForSeconds(0.7f);
            LoginAndPassController.Instance.RefreshText();
            yield return new WaitForSeconds(0.2f);
            //_nextBtn.enabled = true;
            _nextBtn.gameObject.GetComponent<Button>().interactable = true;
            run = false;
        }
    }

    void Start()
    {

        _nextBtn.gameObject.GetComponent<Button>().interactable = false;

        string[] allfiles = Directory.GetFiles(Application.dataPath + "/Resources/XML/", "LM*init.xml");
        foreach (string filename in allfiles)
        {
            string[] forSplit = filename.Split('_');
            string[] forSplit2 = forSplit[0].Split('/');
            _pziNames.Add(forSplit2[forSplit2.Length-1]);
            
            //Debug.Log(forSplit2[forSplit2.Length - 1]);

        }
        _pziNames.Add("");
        _dropdown.AddOptions(_pziNames);
        _dropdown.value = _pziNames.Count;
        _dropdown.onValueChanged.AddListener(delegate { ChangePzi(); });

        if ((File.Exists(Application.dataPath + "/Resources/XML/log.xml")))
        {
            try
            {
               // File.Delete(Application.dataPath + "/Resources/XML/log.xml");
            }
            catch
            {
                //Debug.LogError("file not availeable");
            }
        }
        else
        {
            //Debug.LogError("file doesnt found");
        }
    }

    private void ChangePzi() {


        StartCoroutine("BtnDisable");


        _nextBtn.enabled = false;

        Debug.Log("save xml");

        XmlDocument xmlDoc = new XmlDocument();



        XmlNode userNode = xmlDoc.CreateElement("PZI");
        XmlAttribute attribute = xmlDoc.CreateAttribute("number");
        attribute.Value = _pziNames[_dropdown.value];
        userNode.Attributes.Append(attribute);
        userNode.InnerText = "";
        xmlDoc.AppendChild(userNode);


        xmlDoc.Save(Application.dataPath + "/Resources/XML/log.xml");
       


        _nextBtn.enabled = true;
    }
}
