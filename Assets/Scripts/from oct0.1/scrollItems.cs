using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollItems : MonoBehaviour
{

    public RectTransform prefarb;
    public Text countText;
    public RectTransform content;

    public xmlManager xmlMan;

    private GameObject[] gameObjectBlocksForSleep;

    public void UpdateItems(int Table)
    {

        //Debug.Log(xmlMan.Project);

        var modelsCount = 999;
        //var newtest = xmlMan.GetComponent<xmlManager>();
        //Debug.Log("------    "+newtest.Table1.ItemList.Count);
        switch (xmlMan.Project.ToString())
        {
            case "KPA":

                switch (Table)
                {
                    default:

                        modelsCount = xmlMan.TableKPA.Blocks.Count;
                        break;
                }

                break;

            case "OCT":
                switch (Table)
                {
                    case 1:
                        modelsCount = xmlMan.Table1.Blocks.Count;
                        break;
                    case 2:
                        modelsCount = xmlMan.Table2.Blocks.Count;
                        break;
                    case 3:
                        modelsCount = xmlMan.Table3.Blocks.Count;
                        break;
                    case 4:
                        modelsCount = xmlMan.Table4.Blocks.Count;
                        break;

                }

                break;


        }

        //int modelsCount = xmlMan.TableKPA.Blocks.Count;
        //Debug.Log("------    " + modelsCount);


        //int modelsCount = newtest.Table1.ItemList.Count;
        //int.TryParse(countText.text, out modelsCount);


        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results), 1));

    }

    [System.Obsolete]
    public void sleepBeforeActivate(GameObject obj)
    {
        gameObjectBlocksForSleep = GameObject.FindGameObjectsWithTag("blocks");
        Debug.Log("sleepBeforeActivate");
        // вместо for можно использовать for (var go in gameObjects) 
        for (int i = 0; i < gameObjectBlocksForSleep.Length; ++i)
        {
            if (gameObjectBlocksForSleep[i].active && obj!= gameObjectBlocksForSleep[i])
            gameObjectBlocksForSleep[i].SetActive(false);
            Debug.Log("just setActive -- false for all blocks");
        }

    }

    void OnReceivedModels(TestItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefarb.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, TestItemModel model)
    {
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.titleText.text = model.title;
        view.blockObj = model.block;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickButton.onClick.AddListener(
            () =>
            {
                Debug.Log("is clicked --- '" + view.titleText.text + "'");

                
                //ShowBlockImage(view.titleText.text);
                GameObject obj = GameObjectExtension.Find(view.blockObj.name);
                if (obj)
                {
                    Debug.Log("Find --- " + obj.name);
                    sleepBeforeActivate(obj);
                    obj.SetActive(true);
                    

                }
                else
                {
                    Debug.Log("nope");
                }

            }
        );
    }

     public void ShowBlockImage(string BlockName) {

        GameObject obj = GameObjectExtension.Find(BlockName);
        if (obj)
        {
            Debug.Log("Find --- " + obj.name);
            obj.SetActive(true);
            Debug.Log("Find --- "+obj.name);
        }
        else
        {
            Debug.Log("nope");
        }

    }

    /*класс аккумуляции всех объекто, чтобы отключать выключенные*/
    public static class GameObjectExtension
    {
        public static Object Find(string name, System.Type type)
        {
            Object[] objects = Resources.FindObjectsOfTypeAll(type);
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

    IEnumerator GetItems(int count, System.Action<TestItemModel[]> callback, int Table)
    {
        yield return new WaitForSeconds(0f);
        var results = new TestItemModel[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new TestItemModel();
            results[i].title = "Item " + i;
            results[i].buttonText = "Button " + i;

            results[i].title = xmlMan.TableKPA.Blocks[i].TextRu;
            results[i].block = xmlMan.TableKPA.Blocks[i].obj;
            results[i].NamePrefab = xmlMan.TableKPA.Blocks[i].Name;

        }

        callback(results);
    }

    public class TestItemView
    {
        public Text titleText;
        public Button clickButton;
        public GameObject blockObj;
       

        public TestItemView(Transform rootView)
        {
            titleText = rootView.Find("TitleText").GetComponent<Text>();
            clickButton = rootView.Find("ClickButton").GetComponent<Button>();
            
        }
    }

    public class TestItemModel
    {
        public string title;
        public string buttonText;
        public GameObject block;
        public string NamePrefab;
    }
}