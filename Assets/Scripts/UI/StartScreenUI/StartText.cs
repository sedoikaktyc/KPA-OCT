using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataFromArduino;
using DataFromXML;
using System.Collections.Concurrent;
using LanguageSettings;

public class StartText : MonoBehaviour
{
    public static StartText Instance { get; private set; }

    private Text startText;

    [SerializeField]
    private GameObject connectionLayout;

    [SerializeField]
    private GameObject connectionStatus;

    private List<GameObject> allDeviceStatus =  new List<GameObject>();

    private ConcurrentQueue<Dictionary<string,bool>> _deviceConnectStatus = new ConcurrentQueue<Dictionary<string, bool>>();
    private ConcurrentQueue<Dictionary<string,bool>> _deviceReconnectStatus = new ConcurrentQueue<Dictionary<string, bool>>();

    private string _noDeviceText = "Нет подключенных устройств.\n Подключите УЛМ.";
    private string _deviceConnectText = "УЛМ подключен.";
    private string _deviceDisconnectText = "Устроство УЛМ было отключено.\n Повторное подключение.";

    private string _reconnectionText = " - не был подключён, произвидите подключение(в случае если устройство подключено, переподключите его) и нажмите кнопку 'Переподключить устройства'.";

    private string _noDeviceInPortText = "Ни одно устрйоство не подключено, произвидите подключение(в случае если устройство подключено, переподключите его) и нажмите кнопку 'Переподключить устройства'.";

    private void Awake()
    {
        startText = GetComponent<Text>();
        Instance = this;

        


        SerialPorts.DevicesNotFound += ShowNoDeviceMess;
        DeviceName.NamesRecived += GetDeviceNames;
    }


    private void Start()
    {
        connectionStatus.GetComponent<Text>().text = StartScreenLanguageManager.Instance.DictionaryLang.GetComponent<LanguageXML>().TakeText("status");
        

        _noDeviceText = StartScreenLanguageManager.Instance.DictionaryLang.GetComponent<LanguageXML>().TakeText("messageDoesNotAnyYLM") + "\n" + StartScreenLanguageManager.Instance.DictionaryLang.GetComponent<LanguageXML>().TakeText("messageDoesNotAnyYLM2");
        _deviceConnectText = StartScreenLanguageManager.Instance.DictionaryLang.GetComponent<LanguageXML>().TakeText("messageYLMConnect");

    }
    private void GetDeviceNames(List<string> deviceNames)
    {
        //LanguageXML.Instance.TakeText("login");

        //StartScreenLanguageManager.Instance.DictionaryLang.GetComponent<LanguageXML>().TakeText("wait");
       //Debug.Log(StartScreenLanguageManager.Instance);
        GetComponent<Text>().text = StartScreenLanguageManager.Instance.DictionaryLang.GetComponent<LanguageXML>().TakeText("wait"); 

        foreach (var item in deviceNames)
        {
            var StatusConnectionText = Instantiate(connectionStatus, connectionLayout.transform,false);

            allDeviceStatus.Add(StatusConnectionText);
        }
    }

    public void ShowStartDeviceConnection(Dictionary<string, bool> dict)
    {
        var deviceCount = 0;

        foreach (var item in dict)
        {
            allDeviceStatus[deviceCount].GetComponent<Text>().text = item.Key + " - ожидание подключения";
            
            deviceCount++;
        }
    }

    private void ShowReconnection(Dictionary<string, bool> dict)
    {
        var deviceCount = 0;

        foreach (var item in dict)
        {
            if (item.Value == false)
            {
                allDeviceStatus[deviceCount].GetComponent<Text>().text = item.Key + _reconnectionText;
            }

            deviceCount++;
        }
    }

    public void ReciveDict(Dictionary<string, bool> dict)
    {
        _deviceConnectStatus.Enqueue(dict);
    }

    public void ReciveReconnectDict(Dictionary<string, bool> dict)
    {
        _deviceReconnectStatus.Enqueue(dict);
    }

    private void ShowDeviceConnectionStatus(Dictionary<string, bool> deviceStatus)
    {
        var deviceCount = 0;

        foreach (var item in deviceStatus)
        {
            if (item.Value == true)
            {
                allDeviceStatus[deviceCount].GetComponent<Text>().text = item.Key + " - подключён";
            }
            
            deviceCount++;
        }
    }

    private void Update()
    {
        while (_deviceConnectStatus.TryDequeue(out Dictionary<string, bool> dict))
        {
            ShowDeviceConnectionStatus(dict);
        }

        while (_deviceReconnectStatus.TryDequeue(out Dictionary<string, bool> dict))
        {
            ShowReconnection(dict);
        }
    }

    public void ShowNoDeviceInPortMessage()
    {
        for (int i = 0; i < allDeviceStatus.Count; i++)
        {
            if (i == 0)
            {
                allDeviceStatus[i].GetComponent<Text>().text = _noDeviceInPortText;
            } else {

                allDeviceStatus[i].GetComponent<Text>().text = "";
            }
        }
    }

    public void ShowMess(string Mess)
    {
        startText.text = Mess;
    }

    public void ShowNoDeviceMess()
    {
        startText.text = _noDeviceText;
    }

    public void ShowDeviceConnectMess()
    {
        startText.text = _deviceConnectText;
    }

    public void ShowDeviceDisconnectMess()
    {
        startText.text = _deviceDisconnectText;
    }

    public void ReloadUiText()
    {
        SerialPorts.DevicesNotFound -= ShowNoDeviceMess;
        DeviceName.NamesRecived -= GetDeviceNames;
    }

}
