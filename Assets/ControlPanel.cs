using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Language;

public class ControlPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject contentField;

    [SerializeField]
    private Text Label;
    private string LabelText;
    private string LabelText2;


    public static ControlPanel Instance;

    public void Awake()
    {
        Instance = this;
        LanguageManager.Message += setText;


    }

    private void Start()
    {

    }

    private void setText()
    {

        //Debug.Log("LOADED");
        LabelText = LanguageManager.Instance.Controls[0].RU;
        LabelText2 = LanguageManager.Instance.Controls[1].RU;

    }



    public void ChangeText(string str)
    {

        Label.text = LabelText + " " + str + " " + LabelText2;

    }


    public void DestroyAllChilds()
    {

        foreach (Transform Item in contentField.transform)
        {

            Destroy(Item.gameObject);


        }

        ChangeText("0");

    }

    public void OnReceivedModels(string txt, GameObject Obj, GameObject ObjBlock)
    {
        /*
        foreach (Transform child in contentField.transform)
        {
            Destroy(child.gameObject);
        }
        */
        var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
        Color newColorStart = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        instance.GetComponent<Image>().DOColor(newColorStart, 0.0f);
        instance.transform.SetParent(contentField.transform, false);
        instance.GetComponent<controlItemProps>().ElementString = txt;
        instance.transform.GetChild(1).GetComponent<Text>().text = txt;
        instance.GetComponent<controlItemProps>().StepObj = Obj;
        instance.GetComponent<controlItemProps>().StepObjBlock = ObjBlock;


        Color newColorStart2 = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        instance.GetComponent<Image>().DOColor(newColorStart2, 0.3f);



        instance.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(
            () =>
            {
                AllSceneMetods.SceneMetods.FindObjAndUNcheked(ObjBlock, Obj);
                AllSceneMetods.SceneMetods.DelControlElement(Obj);
                Debug.Log("is clicked --- ");
                instance.GetComponent<Image>().DOColor(newColorStart, 0.2f);
                instance.transform.DOMoveX((instance.transform.position.x + 6), 0.2f).OnComplete(delegate () { Destroy(instance); });
                //Destroy(instance);


            }
        );


        ChangeText(contentField.transform.childCount.ToString());
    }



    public void delinstance(GameObject Obj, GameObject ObjBlock)
    {
        foreach (Transform Item in contentField.transform)
        {
            if ((Item.GetComponent<controlItemProps>().StepObjBlock == ObjBlock) && (Item.GetComponent<controlItemProps>().StepObj == Obj))
            {
                Destroy(Item.gameObject);
                break;
            }
        }
        ChangeText((contentField.transform.childCount - 1).ToString());
    }


}
