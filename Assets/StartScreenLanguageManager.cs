using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartScreenLanguageManager : MonoBehaviour
{
    public static StartScreenLanguageManager Instance;
    public GameObject DictionaryLang;
    void Start()
    {
        
       
    }

    private void Awake()
    {
        if (Instance == null) {

            Instance = this;
        }

            DictionaryLang = GameObject.Find("LanguageDictionary");
        }






}
