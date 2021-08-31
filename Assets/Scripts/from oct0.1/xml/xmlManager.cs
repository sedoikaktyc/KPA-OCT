using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Text;
using UnityEngine.UI;
using System.Linq;




public class xmlManager : MonoBehaviour
{
    public string PziName; //d2t2l1pzi12

    public enum ComponentType { KPA = 1, OCT = 2 };
    public ComponentType Project;

    public static xmlManager XML;
    public TablesDataBase Table1;
    public TablesDataBase Table2;
    public TablesDataBase Table3;
    public TablesDataBase Table4;

    public TablesDataBase TableKPA;


    public PziList PZI;

    string m_Path;


    public GameObject InfoObject;

    private string xmlPath = "/Source/xml/";
    private string dataPath = "/Source/xml/";



    // Start is called before the first frame update
    private void Awake()
    {


        XML = this;
        m_Path = Application.dataPath;

        

        //PziName = transform.name;
        Debug.Log("Awake from xmlManager at PZI");
    }


    [System.Serializable]
    public class ItemEntry
    {
        [SerializeField]
        public string Name;
        public GameObject obj;
        public string TextRu;
        public string TextEng;
        public int Table;

    }

    [System.Serializable]
    public class ObjForStep
    {
        public GameObject Obj;
        public String ObjName;
        public GameObject ObjParent;
        public String ObjParentName;

    }

    [System.Serializable]
    public class StepProperties
    {
        [SerializeField]
       // public GameObject Obj;
       // public String ObjName;
        public List<ObjForStep> ObjForStep;
        public string TextRu;
        public string TextEng;
        public int Answer;
        public int Gap;
        public enum TypeOfAnswerProper { Control = 0, Action = 1, Arduino = 2 };
        public TypeOfAnswerProper TypeOfAnswer;
        public enum TypeOfArduinoAnswerProper { disabled = 0, Button = 1, NotButton = 2 };
        public TypeOfArduinoAnswerProper TypeOfArduinoAnswer;


    }

    [System.Serializable]
    public class PziList
    {
        public List<StepProperties> Steps = new List<StepProperties>();

    }


    public GameObject FindObjInStep(int step)
    {
        //Debug.Log("PZI count -- "+XML.PZI.Steps.Count);
        return XML.PZI.Steps[step].ObjForStep[0].Obj;
    }

    public GameObject[] FindObjsInStep(int step)
    {

        List<GameObject> allObjAtStep = new List<GameObject>();

        foreach (var Item in XML.PZI.Steps[step].ObjForStep) {
            allObjAtStep.Add(Item.Obj);
        }
        return allObjAtStep.ToArray();
    }


    public int FindAnswer(int step)
    {

        return XML.PZI.Steps[step].Answer;
    }

    public int FindTypeOf(int step)
    {

        return Convert.ToInt32(XML.PZI.Steps[step].TypeOfAnswer);
    }

    public int FindTypeOfArduino(int step)
    {

        return Convert.ToInt32(XML.PZI.Steps[step].TypeOfArduinoAnswer);
    }

    public int FindFap(int step)
    {

        return Convert.ToInt32(XML.PZI.Steps[step].Gap);
    }


    [System.Serializable]
    public class TablesDataBase
    {
        public List<ItemEntry> Blocks = new List<ItemEntry>();
        // ниже раскомментировать чтобы столы принадлежали собственному списку как вложеные списки
        /*
        public List<ItemEntry> Table2 = new List<ItemEntry>();
        public List<ItemEntry> Table3 = new List<ItemEntry>();
        public List<ItemEntry> Table4 = new List<ItemEntry>();
       */


    }



    public void SaveItemsData()
    {

        Debug.Log(transform.name);
        transform.name = PziName;

        int countOfCildsNow = 0;
        foreach (var Item in TableKPA.Blocks)
        {
            //child.name = BlockSquares.Squares[child.childCount];
            Item.Name = Item.obj.name;
            Debug.Log(Item.obj.name);
            //child.name = TableKPA.Blocks[countOfCildsNow].Name;
            countOfCildsNow++;

        }


        foreach (var Item in PZI.Steps)
        {
            foreach (var Obj in Item.ObjForStep)
            {
                Obj.ObjName = Obj.Obj.name;
                Obj.ObjParent = Obj.Obj.transform.parent.parent.parent.gameObject;
                Obj.ObjParentName = Obj.ObjParent.name;
            }

            //Item.Parent = Item.ObjForStep[0].Obj.transform.parent.parent.parent.gameObject;
            //Item.ParentName = Item.ObjForStep[0].Obj.transform.parent.parent.parent.name;
            //Item.ObjName = Item.Obj.name;

        }




        m_Path = Application.dataPath;
        string nameOfBlock = PziName;
        FileStream file = File.Create(m_Path + dataPath + "/" + nameOfBlock + ".dat");
        DataContractSerializer bf = new DataContractSerializer(PZI.GetType());
        MemoryStream streamer = new MemoryStream();
        bf.WriteObject(streamer, PZI);
        streamer.Seek(0, SeekOrigin.Begin);
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);
        // Close the file to prevent any corruptions
        file.Close();

        Debug.Log(m_Path + dataPath + "/" + nameOfBlock + ".dat" + " --- Saved");
    }

    public void AddItemToTable(TablesDataBase Table)
    {
        Table.Blocks.Add(new ItemEntry());


    }
    public void RemoveItemOfTable(TablesDataBase Table)
    {
        Table.Blocks.RemoveAt((Table.Blocks.Count - 1));
    }

    void Start()
    {
        m_Path = Application.dataPath;
    }




    // Update is called once per frame
    void Update()
    {

    }

    public void SaveItems()
    {
        XmlSerializer Serializer = new XmlSerializer(typeof(TablesDataBase));
        FileStream stream = new FileStream(m_Path + xmlPath + PziName + ".xml", FileMode.Create);
        Serializer.Serialize(stream, Table1);
        stream.Close();



    }



    public void LoadItems()
    {
        XmlSerializer Serializer = new XmlSerializer(typeof(TablesDataBase));
        FileStream stream = new FileStream(m_Path + xmlPath + PziName + ".xml", FileMode.Open);
        Table1 = Serializer.Deserialize(stream) as TablesDataBase;
        stream.Close();

        Debug.Log("---  " + Table1.Blocks.Count);

        InfoObject.GetComponent<infoLoader>().LoadInfoBox("xml loading complete");
        //InfoObject.GetComponent<infoLoader>.

    }




    /*класс аккумуляции всех объекто, чтобы отключать выключенные*/
    public static class GameObjectExtension
    {
        public static UnityEngine.Object Find(string name, System.Type type)
        {
            UnityEngine.Object[] objects = Resources.FindObjectsOfTypeAll(type);
            foreach (var obj in objects)
            {
                if (obj.name == name)
                {
                    return obj;
                }
            }
            return null;
        }



        public static GameObject Find(string name)
        {
            return Find(name, typeof(GameObject)) as GameObject;
        }


    }

    public void FindAllObjects()
    {


        foreach (var block in TableKPA.Blocks)
        {

            block.obj = GameObjectExtension.Find(block.Name);


        }



        foreach (var Item in PZI.Steps)
        {

            

            
            foreach (var ItemObj in Item.ObjForStep)
            {

                GameObject ParentGO = GameObjectExtension.Find(ItemObj.ObjParentName);
                //Item.Parent = ParentGO;
                foreach (Transform child in ParentGO.transform.GetChild(0).GetChild(0).transform)
                {


                    if (child.gameObject.name == ItemObj.ObjName)
                    {
                        ItemObj.Obj = child.gameObject;
                        ItemObj.ObjParent = child.gameObject.transform.parent.parent.parent.gameObject;
                        break;
                    }


                }


            }
            






        }


    }







}
