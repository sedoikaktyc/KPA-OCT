using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class xml_loader : MonoBehaviour
{
    string m_Path;
    string xml_marling = "xml_marling.xml";
    string slash = "/";


    void createTXT()
    {

        if (!File.Exists(m_Path+"/log.txt"))
        {
            File.WriteAllText(m_Path + "/log.txt", "srabotalo");
            Debug.Log("createTXT");
        }


    }
    public void CheckXML()
    {
        if (!File.Exists(m_Path + slash + xml_marling))
        {

        }

    }

    void Start()
    {
        CheckXML();
        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);

        createTXT();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
