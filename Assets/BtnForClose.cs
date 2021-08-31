using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataFromArduino;
using UnityEngine.SceneManagement;


public class BtnForClose : MonoBehaviour
{
    private GameObject ArduinoManager;
    void Start()
    {
        

    }


    public void ClosePorts() {
        ArduinoManager = GameObject.Find("LanguageDictionary");
        try
        {
            Destroy(ArduinoManager);  
        }
        catch {
            Debug.LogError("LanguageDictionary doesnt initialized");        
        }
        StartSceneController.Instance.LoadLoginScene();
    }
}
