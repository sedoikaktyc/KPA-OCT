using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class OnSelectedController : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update

    public void OnSelect(BaseEventData eventData)
    {
        /*
        if ((File.Exists(Application.dataPath + "/Resources/XML/log.xml"))){
            try
            {
                File.Delete(Application.dataPath + "/Resources/XML/log.xml");
            }
            catch {
                Debug.LogError("file not availeable");
            }
        }
        else {
            Debug.LogError("file doesnt found");
        }
        */
    }


    void Start()

    {
        
    }


}
