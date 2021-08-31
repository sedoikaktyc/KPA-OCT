using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DataFromArduino;
using System.Collections.Concurrent;
using Utils;

public class StartSceneController : MonoBehaviour
{
    public enum InitialPositionCheckState
    {
        HideAll,
        LessonStart,
        InitialSceneStart,
        Reconnect
    }

    public static StartSceneController Instance;

    [SerializeField]
    private GameObject _startLessButton;

    [SerializeField]
    private GameObject _initialPositionButton;

    [SerializeField]
    private GameObject _reloadButton;

    private ConcurrentQueue<InitialPositionCheckState> m_queuedLogs = new ConcurrentQueue<InitialPositionCheckState>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void LoadStartScene()
    {
        ReloadObjects();
        SceneManager.LoadScene(1);
    }
    public void LoadLoginScene()
    {
        ReloadObjects();
        SceneManager.LoadScene(0);
    }

    //TODO name
    private static void ReloadObjects()
    {
        Destroy(DataForComparison.Instance.gameObject);
        //объекты стартового экрана должны удаляться до его повторной загрузки
        PrephabController.instance.DestroySerialPortPrefabs();
        DataForComparison.Instance.Unsubscribe();
        StartText.Instance.ReloadUiText();
        DevicesManager.DisconnectDevice();
    }

    public void LoadDisconnectScreen()
    {
        ReloadObjects();
        SceneManager.LoadScene(4);
    }

    public void LoadLessScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadInitScene()
    {
        SceneManager.LoadScene(3);
    }

    private void ControllStartSceneButton(InitialPositionCheckState state)
    {
        if (state == InitialPositionCheckState.LessonStart)
        {
            _startLessButton.SetActive(true);
            _initialPositionButton.SetActive(false);
        }

        if (state == InitialPositionCheckState.InitialSceneStart)
        {
           // _startLessButton.SetActive(false);
            _initialPositionButton.SetActive(true);
        }

        if (state == InitialPositionCheckState.HideAll)
        {
            //TODO включить на релизе
          //  _startLessButton.SetActive(false);
            _initialPositionButton.SetActive(false);
        }

        if (state == InitialPositionCheckState.Reconnect)
        {
            _reloadButton.SetActive(true);
        }
    }

    public void ReciveStatus(InitialPositionCheckState showButton)
    {
        m_queuedLogs.Enqueue(showButton);
    }


    private void Update()
    {
        while (m_queuedLogs.TryDequeue(out InitialPositionCheckState deviceStatus))
        {
            ControllStartSceneButton(deviceStatus);
        }
    }
}
