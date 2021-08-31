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
using DG.Tweening;

public class ObjectsOnImage : MonoBehaviour
{

    public GameObject PrefFoImage;
    public Canvas CanvasParent;
    public GameObject GameObjectParent;
    public GameObject BlockName;
    public Sprite Image;

    public DataBase BlockSquares = new DataBase();

    private string dataPath = "/Source/xml/";
    string m_Path;


    // Start is called before the first frame update
    void Start()
    {
        AddListenerAtBotton();
    }

    public void ChangeImages()
    {

        foreach (Transform child in transform)
        {

            child.GetComponent<Image>().sprite = Image;


        }


        //this.GetComponent<Image>().sprite = Image;
    }

    public void AddListenerAtBotton()
    {


        //Debug.Log(transform.childCount);


        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).GetComponent<Button>();
            var childOBJ = transform.GetChild(i).gameObject;
            //var childFlag = transform.GetChild(i).gameObject.GetComponent<ImageFlag>();
            // 
            ImageFlag ImageFlagAtItem = childOBJ.AddComponent<ImageFlag>();
            if (child != null)

            {
                child.onClick.AddListener(
            () =>
            {
                Color newColor = new Color(0.69f, 0.32f, 1.0f, 1.0f);
                Color newColorStart = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                

                
                // Debug.Log(ImageFlagAtItem.IsClicked);
                 if (!ImageFlagAtItem.IsClicked)
                 {
                 childOBJ.GetComponent<Image>().DOColor(newColor, 0.25f);
                    ImageFlagAtItem.IsClicked = true;
                 }
                 else {
                childOBJ.GetComponent<Image>().DOColor(newColorStart, 0.25f);
                    ImageFlagAtItem.IsClicked = false;
                }

                for (int i = 0; i < BlockSquares.Squares.Count; i++)
                {
                    if (BlockSquares.Squares[i].Name == childOBJ.name)
                    {
                        //Debug.Log(childOBJ.gameObject.name);
                        AllSceneMetods.SceneMetods.ElementSended(BlockName, childOBJ, BlockSquares.Squares[i].TextRu, ImageFlagAtItem.IsClicked);
                    }
                }




            }
            );
            }

        }

    }


    // Start is called before the first frame update
    private void Awake()
    {
        m_Path = Application.dataPath;
    }

    [System.Serializable]
    public class DataBase
    {
        public List<ItemEntry> Squares = new List<ItemEntry>();

        // ниже раскомментировать чтобы столы принадлежали собственному списку как вложеные списки
        /*
        public List<ItemEntry> Table2 = new List<ItemEntry>();
        public List<ItemEntry> Table3 = new List<ItemEntry>();
        public List<ItemEntry> Table4 = new List<ItemEntry>();
       */


    }


    public void SaveItemsData()
    {
        int countOfCildsNow = 0;
        foreach (Transform child in transform)
        {
            //child.name = BlockSquares.Squares[child.childCount];
            //Debug.Log(transform.childCount);
            child.name = BlockSquares.Squares[countOfCildsNow].Name;
            countOfCildsNow++;
        }


        m_Path = Application.dataPath;
        string nameOfBlock = BlockName.name;
        FileStream file = File.Create(m_Path + dataPath + "/" + nameOfBlock + ".dat");
        DataContractSerializer bf = new DataContractSerializer(BlockSquares.GetType());
        MemoryStream streamer = new MemoryStream();
        bf.WriteObject(streamer, BlockSquares);
        streamer.Seek(0, SeekOrigin.Begin);
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);
        // Close the file to prevent any corruptions
        file.Close();

        Debug.Log(m_Path + dataPath + "/" + nameOfBlock + ".dat" + " --- Saved");
    }

    public void AddItemToTable()
    {

        BlockSquares.Squares.Add(new ItemEntry());
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].PositionX = UnityEngine.Random.Range(100f, 400f);
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].PositionY = UnityEngine.Random.Range(100f, 400f);
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].Width = UnityEngine.Random.Range(20f, 100f);
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].Hiegth = UnityEngine.Random.Range(20f, 100f);
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].parent = transform.parent.gameObject;
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].pref = PrefFoImage;

        BlockSquares.Squares[BlockSquares.Squares.Count - 1].ScaleX = 1;
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].ScaleY = 1;
        BlockSquares.Squares[BlockSquares.Squares.Count - 1].ScaleZ = 1;


        GameObject qwe = Instantiate(BlockSquares.Squares[BlockSquares.Squares.Count - 1].pref);
        qwe.transform.SetParent(CanvasParent.transform, true);
        qwe.transform.SetParent(GameObjectParent.transform, true);
        qwe.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);
        qwe.name = "image#" + BlockSquares.Squares.Count.ToString();

        BlockSquares.Squares[BlockSquares.Squares.Count - 1].ImageItem = qwe;

    }


}






[System.Serializable]
public class ItemEntry
{

    [SerializeField]
    public string Name;
    public float status;
    public GameObject ImageItem;
    public bool IsEnable = true;
    public string TextRu;
    public string TextEng;
    public float answerAtThisStep;
    public GameObject parent;
    public GameObject pref;
    public float PositionX;
    public float PositionY;
    public float Width;
    public float Hiegth;
    public float ScaleX;
    public float ScaleY;
    public float ScaleZ;
    public bool Ray = true;
    public bool Mask = true;
    public float AnPositionX;
    public float AnPositionY;
    public float AnPositionMaX;
    public float AnPositionMaY;





    /**

    void Start() {

        ColorImage = pref.transform.GetComponent<Image>().color;
        AnPositionX = pref.GetComponent<RectTransform>().anchoredPosition.x;
        AnPositionX = pref.GetComponent<RectTransform>().sizeDelta.x;
        Collz = pref.GetComponent<BoxCollider>().size.x;
    }

    */
}
