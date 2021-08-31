using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapterOCT : MonoBehaviour
{

    public RectTransform prefarb;
    public Text countText;
    public RectTransform content;



    private GameObject hand;
    private GameObject hand2;
    private GameObject hand3;

    public void UpdateItems()
    {
        int modelsCount = 0;
        int.TryParse(countText.text, out modelsCount);
        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results)));
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
            //var instance = GameObject.Instantiate(prefarb.gameObject);
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, TestItemModel model)
    {
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.titleText.text = model.title;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickButton.onClick.AddListener(
            () =>
            {
                Debug.Log(view.titleText.text + " is clicked--- ! --- ");

                hand = GameObject.Find("Блок 1");
                hand.SetActive(false);
                Debug.Log(view.titleText.text + " is clicked--- ! --- 2");
                hand2 = GameObject.Find("Блок 2");
                hand2.SetActive(false);
                Debug.Log(view.titleText.text + " is clicked--- ! --- 3");
                hand3 = GameObject.Find(view.titleText.text);
                hand3.SetActive(true);

            }
        );
    }

    IEnumerator GetItems(int count, System.Action<TestItemModel[]> callback)
    {
        yield return new WaitForSeconds(1f);
        var results = new TestItemModel[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = new TestItemModel();
            results[i].title = "Item " + i;
            results[i].buttonText = "Button " + i;
        }

        callback(results);
    }

    public class TestItemView
    {
        public Text titleText;
        public Button clickButton;

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
    }
}