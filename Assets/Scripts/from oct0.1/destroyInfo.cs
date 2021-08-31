using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyInfo : MonoBehaviour
{
    public float TimeToDestroy = 0.1f;
    public float TimeToDestroyEtapBox = 0.0f;
    public GameObject guiTextLink;
    public string ErrorOrInfoText;
    public GameObject BlurPrefab;
    public GameObject label;
    public string StringForLabel;

    void Start()
    {


        //var text = Canvas.GetComponentInChildren<Text>();
        // text.text = "Новый текст";
        if (guiTextLink != null)
        {
            guiTextLink.GetComponent<Text>().text = ErrorOrInfoText;
        }

        if (StringForLabel != "") {
            label.GetComponent<Text>().text = StringForLabel;
}


    }

    public void Destroy()
    {

        Destroy(BlurPrefab, TimeToDestroy);
        Destroy(this.gameObject, TimeToDestroy);
    }

    public void ChangeEtap(int Etap) {
        AllSceneMetods.SceneMetods.ChangeEtap(Etap);
        Destroy(BlurPrefab, TimeToDestroyEtapBox);
        Destroy(this.gameObject, TimeToDestroyEtapBox);
    }


}
