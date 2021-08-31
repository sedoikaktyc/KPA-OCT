using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LanguageSettings;

public class LoginAndPassController : MonoBehaviour
{

    public static LoginAndPassController Instance;

    
    private Text _login;
    [SerializeField]
    private Text _password;
    [SerializeField]
    private Text _signBtn;
    [SerializeField]
    private Text _Label;
    [SerializeField]
    private Text _signBtn2;
    [SerializeField]
    private Text _label1;
    [SerializeField]
    private Text _label2;

    private void Awake()
    {
        Instance = this;
        UIDropdownLanguages.LanguageChangeNow += RefreshText;
    }

    private void OnEnable()
    {
        _login = GameObject.Find("Login Text").GetComponent<Text>();
        Debug.Log(_login.text);
    }

    private void Start()
    {

    }


    public void RefreshText() {
        _login = GameObject.Find("Login Text").GetComponent<Text>();
        _login.text = LanguageXML.Instance.TakeText("login");
        _password = GameObject.Find("Password Text").GetComponent<Text>();
        _password.text = LanguageXML.Instance.TakeText("password");
        _signBtn = GameObject.Find("ButtonSign").GetComponentInChildren<Text>();
        _signBtn.text = LanguageXML.Instance.TakeText("signBtn");
        _Label = GameObject.Find("LabelText").GetComponent<Text>();
        _Label.text = LanguageXML.Instance.TakeText("loginLabel");
        _signBtn2 = GameObject.Find("_signBtn2").GetComponentInChildren<Text>();
        _signBtn2.text = LanguageXML.Instance.TakeText("runLabel");
        _label1 = GameObject.Find("Text#1").GetComponent<Text>();
        _label1.text = LanguageXML.Instance.TakeText("label1");
        _label2 = GameObject.Find("Text#2").GetComponent<Text>();
        _label2.text = LanguageXML.Instance.TakeText("label2");
        

    }




}