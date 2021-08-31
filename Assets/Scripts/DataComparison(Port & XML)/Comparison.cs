using System.Collections.Generic;
using DataFromArduino;
using UnityEngine;
using DataFromXML;
using System.Collections.Concurrent;
using System.Threading;

public class Comparison
{
    private Dictionary<string, bool> _devicesConnection;
    public List<string> IncorrectPosition { get; private set; }

    private bool _areAllDeviceConnected;
    private bool _areAllPositionsCorrectly;

    //время для повторной проверки состояния подключенных устройств
    private int _timeForReCheck = 5000;
    private TimerCallback _tm;
    private Timer _stateTiner;

    public Comparison()
    {
        _areAllDeviceConnected = false;
        _devicesConnection = new Dictionary<string, bool>();
        IncorrectPosition = new List<string>();
    }

    /// <summary>
    /// Создается словарь из списка имен устройств (names) которые необходимо подключить 
    /// Каждому ключу выставляеться значение false
    /// </summary>
    /// <param name="names"></param>
    public void MakeDictFromList(List<string> names)
    {
        for (int i = 0; i < names.Count; i++)
        {
            if (!_devicesConnection.ContainsKey(names[i]))
            {
                _devicesConnection.Add(names[i], false);
            }
        }

        StartText.Instance.ShowStartDeviceConnection(_devicesConnection);
    }

    /// <summary>
    /// Метод принимает имя подключенного устройства (name)
    /// Если оно есть в словаре выставляет ему в словаре значение true
    /// </summary>
    /// <param name="name"></param>
    public void CompareNameFromXMLandDevice(string name)
    {
        if (_devicesConnection.ContainsKey(name))
        {
            _devicesConnection[name] = true;
        }

        CheckAllDevicesConnected();
        StartText.Instance.ReciveDict(_devicesConnection);
    }

    private void CheckAllDevicesConnected()
    {
        foreach (var key in _devicesConnection.Values)
        {
            if (key == false)
            {
                StartConnectionWaiting();
                return;
            }
        }
        _areAllDeviceConnected = true;
    }

    private void StartConnectionWaiting()
    {
        _tm = new TimerCallback(CheckStatus);
        _stateTiner = new Timer(_tm, _areAllDeviceConnected, _timeForReCheck, 0);
    }

    private void CheckStatus(object obj)
    {
        if (!_areAllDeviceConnected)
        {
            StartSceneController.Instance.ReciveStatus(StartSceneController.InitialPositionCheckState.Reconnect);
            StartText.Instance.ReciveReconnectDict(_devicesConnection);
        }

        _stateTiner.Dispose();
    }

    public void CompareInitialPosition(Dictionary<string, int> xmlInitialPosition, ConcurrentDictionary<string, int> devicesInitialPosition, Dictionary<string, int> controllGap)
    {
        CheckCountBetweenDictionary(xmlInitialPosition, devicesInitialPosition);

        _areAllPositionsCorrectly = true;

        foreach (var keyValuePair in xmlInitialPosition)
        {

            if (devicesInitialPosition.ContainsKey(keyValuePair.Key))
            {
                if (devicesInitialPosition[keyValuePair.Key] <= (xmlInitialPosition[keyValuePair.Key] + controllGap[keyValuePair.Key]) &&
                    devicesInitialPosition[keyValuePair.Key] >= (xmlInitialPosition[keyValuePair.Key] - controllGap[keyValuePair.Key]))
                {
                    IncorrectPosition.Remove(keyValuePair.Key);
                } else {
                    SetIncorrectDictionary(keyValuePair);
                    _areAllPositionsCorrectly = false;
                }
            } else
            {
                ErrorNoControllInDictionary(keyValuePair.Key);
            }
        }

        CheckAllComparisonsResult();
    }

    private void SetIncorrectDictionary(KeyValuePair<string, int> keyValuePair)
    {
        if (!IncorrectPosition.Contains(keyValuePair.Key))
        {
            IncorrectPosition.Add(keyValuePair.Key);
        }
    }

    private void CheckAllComparisonsResult()
    {
        if (_areAllPositionsCorrectly && _areAllDeviceConnected)
        {
            StartSceneController.Instance.ReciveStatus(StartSceneController.InitialPositionCheckState.LessonStart);
            DataForComparison.Instance.TrySendDataToInitialScene(true);
        }
        if (!_areAllPositionsCorrectly && _areAllDeviceConnected)
        {
            StartSceneController.Instance.ReciveStatus(StartSceneController.InitialPositionCheckState.InitialSceneStart);
            DataForComparison.Instance.TrySendDataToInitialScene(false);
        }
    }

    public Dictionary<string, bool> GetDevices()
    {
        return _devicesConnection;
    }

    private void CheckCountBetweenDictionary(Dictionary<string, int> xmlCount, ConcurrentDictionary<string, int> deviceCount)
    {
        if (xmlCount.Count > deviceCount.Count)
        {
            foreach (var keyValue in xmlCount)
            {
                if (!deviceCount.ContainsKey(keyValue.Key))
                {
                    Debug.LogError("Количество начальных позиций в XML документе не совпадает " +
                                               "с количеством переданными подключенными устройствами." +
                                               "В данных с устройства отсутствует - " + keyValue.Key);
                }
            }
        }

        if (xmlCount.Count < deviceCount.Count)
        {
            foreach (var keyValue in deviceCount)
            {
                if (!deviceCount.ContainsKey(keyValue.Key))
                {
                    Debug.LogError("Количество начальных позиций в XML документе не совпадает " +
                                               "с количеством переданными подключенными устройствами." +
                                               "В данных XML отсутствует - " + keyValue.Key);
                }
            }
        }
    }

    private void ErrorNoControllInDictionary(string controll)
    {
        Debug.LogError("В начальных позициях с подключенных устройств нет органа урпавления - " + controll +
                       "\n" + "Имя данного органа управления указано " + " XML файле");
    }
}
