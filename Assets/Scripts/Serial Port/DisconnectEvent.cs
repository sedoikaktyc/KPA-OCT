using DataFromArduino;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class DisconnectEvent : MonoBehaviour
{

    private ConcurrentQueue<bool> restatStartSceenQuen = new ConcurrentQueue<bool>();

    public static DisconnectEvent instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    private void LoadDisconnectScreen()
    {
        PrephabController.instance.DestroySerialPortPrefabs();
        DataForComparison.Instance.Unsubscribe();
        StartText.Instance.ReloadUiText();
        DevicesManager.DisconnectDevice();
        UnsubscribeLessonScene();
        SceneManager.LoadScene(4);
    }

    public void ReciveRestart()
    {
        restatStartSceenQuen.Enqueue(true);
    }

    private void Update()
    {
        while (restatStartSceenQuen.TryDequeue(out bool DisconncetStatus))
        {
            LoadDisconnectScreen();
        }
    }

    private void UnsubscribeLessonScene()
    {
        var lessScene = FindObjectOfType<AllSceneMetods>();
        if (lessScene != null)
        {
            lessScene.UnsubscribeFromChecking();
        }

    }
}
