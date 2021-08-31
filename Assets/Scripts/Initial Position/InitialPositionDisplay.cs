using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Concurrent;

namespace StartPosition
{
    public class InitialPositionDisplay : MonoBehaviour
    {
        public ControllsData AllInitialData;

        public DevicesImageDisplay DevicesImageDisplay;
        public InitialScene InitialScene;

        public List<GameObject> DevicesPrefabs;
        public GameObject controllNameAndPosition;

        public Sprite PositionSprite;
        public Color CorrectColor;
        public Color IncorrectColor;

        private int _hierarchyDistance = 0;

        private ConcurrentDictionary<string, bool> _deviceCorrectPosition = new ConcurrentDictionary<string, bool>();
        private List<Transform> _prefabCotrolls = new List<Transform>();
        private List<GameObject> _currentDevices = new List<GameObject>();

        private string _parentName;

        private bool _isFirstIncorrectDevice;

        private void Start()
        {
            DisplayDevices(DevicesPrefabs);
        }

        /// <summary>
        /// функция отображения по нажатию
        /// </summary>
        /// <param name="deviceName"></param>
        public void DisplayDevice(string deviceName)
        {
            foreach (var device in _currentDevices)
            {
                if (device.name == deviceName)
                {
                    device.SetActive(true);
                } else
                {
                    device.SetActive(false);
                }
            }
        }

        private void DisplayDevices(List<GameObject> displayObjects)
        {
            foreach (var gameObject in displayObjects)
            {
                _hierarchyDistance = 0;
                //имена прибора с устрйоства должы совпадать с именем перфаба
                if (AllInitialData.Devices.ContainsKey(gameObject.name))
                {
                    _parentName = gameObject.name;
                    SendDevicePrefab(gameObject);
                    FindComposits(gameObject);
                }
            }
        }

        private void DisplayHierarchyDevice(List<GameObject> displayObjects)
        {
            foreach (var gameObject in displayObjects)
            {
                SendDevicePrefab(gameObject);
                FindComposits(gameObject);
            }
        }

        //каждый составной объект должен иметь CompositDevice
        private void FindComposits(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<CompositDevice>(out CompositDevice compositDevice))
            {
                var compositDevices = compositDevice.CompositPrefabs;
                _hierarchyDistance++;
                DisplayHierarchyDevice(compositDevices);
            }
        }

        //дочерние объекты префаба должны содержать Canvas в котором располагается Image
        private void SendDevicePrefab(GameObject gameObject)
        {
            var deviceCanvas = gameObject.transform.Find("Canvas");
            var deviceSprite = deviceCanvas.transform.Find("Image");

            DevicesImageDisplay.DisplayPrefabs(_hierarchyDistance, deviceSprite.GetComponent<Image>().sprite, gameObject.name);
            _deviceCorrectPosition.TryAdd(gameObject.name, true);
            _currentDevices.Add(gameObject);
            CollectControlls(deviceSprite);
        }

        private void CollectControlls(Transform deviceSprite)
        {
            for (int i = 0; i < deviceSprite.childCount; i++)
            {
                var newControllName = _parentName + deviceSprite.GetChild(i).transform.name;
                deviceSprite.GetChild(i).transform.name = newControllName;

                //добавлять в список органы управления прописанные в XML документе
                if (AllInitialData.XMLPositions.ContainsKey(newControllName))
                {
                    _prefabCotrolls.Add(deviceSprite.GetChild(i));
                    deviceSprite.GetChild(i).GetComponent<Image>().sprite = PositionSprite;
                } else
                {
                    deviceSprite.GetChild(i).gameObject.SetActive(false);
                }
            }
            SetControllAction();
            SetColorToControlls();
        }

        private void SetControllAction()
        {
            foreach (var cnotroll in _prefabCotrolls)
            {
                cnotroll.GetComponent<Button>().onClick.AddListener(ShowRealDataText);
            }
        }

        private void ShowRealDataText()
        {
            var selectedControll = EventSystem.current.currentSelectedGameObject.name;

            var controllName = AllInitialData.ControllsRealName[selectedControll];
            var controllPosition = AllInitialData.ControllsRealPosition[selectedControll];

            controllNameAndPosition.GetComponent<TextMeshProUGUI>().text = controllName + "\n" + controllPosition;
        }

        /// <summary>
        /// проверка статуса сравнения начальных положений
        /// </summary>
        /// <param name="status"></param>
        public void CheckDeviceComparionStatus(bool status)
        {
            SetColorToControlls();
            InitialScene.ShowStartLessonButton(status);
        }

        private void SetColorToControlls()
        {
            foreach (var cnotroll in _prefabCotrolls)
            {
                if (AllInitialData.IncorrectPosition.Contains(cnotroll.name))
                {
                    cnotroll.GetComponent<Image>().color = IncorrectColor;

                    //поиск главного родительского объекта parent.parent.parent, структура префабов не должна меняться
                    if (_deviceCorrectPosition.ContainsKey(cnotroll.parent.parent.parent.gameObject.name))
                    {
                        _deviceCorrectPosition[cnotroll.parent.parent.parent.gameObject.name] = false;
                        if (!_isFirstIncorrectDevice) {
                            cnotroll.parent.parent.parent.gameObject.SetActive(true);
                            _isFirstIncorrectDevice = true;
                        }
                    }

                } else
                {
                    cnotroll.GetComponent<Image>().color = CorrectColor;
                }
            }
            DevicesImageDisplay.SetColorOnFrame(_deviceCorrectPosition);
            SetCorrectStatusToDevices();
        }

        private void SetCorrectStatusToDevices()
        {
            foreach (var key in _deviceCorrectPosition.Keys)
            {
                _deviceCorrectPosition[key] = true;
            }
        }
    }
}
