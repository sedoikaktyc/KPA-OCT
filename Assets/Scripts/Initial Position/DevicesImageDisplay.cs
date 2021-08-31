using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Concurrent;

namespace StartPosition
{
    public class DevicesImageDisplay : MonoBehaviour
    {
        public GameObject DeviceForScroll;
        public GameObject ContentOfPrefabs;

        public InitialPositionDisplay InitialPositionDisplay;

        private const int HierarchyTab = 40;

        private Sprite _deviceSprite;
        private GameObject _device;
        private Dictionary<string, Transform> _devicesFrame = new Dictionary<string, Transform>();

        /// <summary>
        /// отоборжение иерархии подключенных устрйоств на которых необходимо выставить начальные условия
        /// </summary>
        /// <param name="depthHierarchy"> параметр глубины иерархии зависящий от количества составных частей основного прибора который подключается</param>
        /// <param name="deviceSprite">картинка для кнопки в иеррахичной структуре</param>
        /// <param name="name">имя прибора</param>
        public void DisplayPrefabs(int depthHierarchy, Sprite deviceSprite, string name)
        {
            _device = Instantiate(DeviceForScroll, ContentOfPrefabs.transform, false);
            _deviceSprite = deviceSprite;


            SetName(name);
            MovePrefab(depthHierarchy);
            SetImage();
            SetButtonAction();
        }


        /// <summary>
        /// если префаб прибора содержит не правильно выставленный элемент , рамка кнопки будет окрашена в красный цвет
        /// </summary>
        /// <param name="devicesStatus"></param>
        public void SetColorOnFrame(ConcurrentDictionary<string, bool> devicesStatus)
        {
            foreach (var item in _devicesFrame)
            {
                if (devicesStatus[item.Key])
                {
                    _devicesFrame[item.Key].GetComponent<Image>().color = InitialPositionDisplay.CorrectColor;
                } else {
                    _devicesFrame[item.Key].GetComponent<Image>().color = InitialPositionDisplay.IncorrectColor;
                }
            }
        }

        private void SetButtonAction()
        {
            _device.GetComponent<Button>().onClick.AddListener(ShowDevice);
        }

        private void ShowDevice()
        {
            var selectedDevice = EventSystem.current.currentSelectedGameObject.name;
            InitialPositionDisplay.DisplayDevice(selectedDevice);
        }

        private void SetName(string name)
        {
            var deviceName = _device.transform.Find("Name");
            deviceName.GetComponent<Text>().text = name;
            _device.name = name;
        }

        private void SetImage()
        {
            var deviceImage = _device.transform.Find("Device");
            deviceImage.GetComponent<Image>().sprite = _deviceSprite;
            var deviceFrame = _device.transform.Find("Frame");

            _devicesFrame.Add(_device.name, deviceFrame);
        }

        private void MovePrefab(int depthHierarchy)
        {
            var rectOfDevice = _device.GetComponent<RectTransform>();
            rectOfDevice.sizeDelta = new Vector2(rectOfDevice.sizeDelta.x + depthHierarchy * HierarchyTab,
                                                 rectOfDevice.sizeDelta.y);
        }
    }
}