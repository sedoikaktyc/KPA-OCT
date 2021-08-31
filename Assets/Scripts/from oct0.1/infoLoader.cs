using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoLoader : MonoBehaviour
{
    public GameObject InfoBox;
    public GameObject BlurPrefab;

    public void LoadInfoBox(string TextToInfo)
    {

        var instance = GameObject.Instantiate(BlurPrefab.gameObject) as GameObject;

        var renderBlur = findBlurRenderPref.Find("Blur");
        renderBlur.SetActive(true);
        GameObject obj = Instantiate(InfoBox) as GameObject;
        obj.GetComponent<destroyInfo>().ErrorOrInfoText = TextToInfo;
        obj.GetComponent<destroyInfo>().BlurPrefab = instance;
    }

    public void LoadEtapBox()
    {

        var instance = GameObject.Instantiate(BlurPrefab.gameObject) as GameObject;

        var renderBlur = findBlurRenderPref.Find("Blur");
        renderBlur.SetActive(true);
        GameObject obj = Instantiate(InfoBox) as GameObject;
       
        obj.GetComponent<destroyInfo>().BlurPrefab = instance;
    }


    public static class findBlurRenderPref
    {

        public static GameObject Find(string Tag)
        {
            GameObject objectobj = GameObject.FindGameObjectWithTag(Tag);

            return objectobj;

        }

    }

}
