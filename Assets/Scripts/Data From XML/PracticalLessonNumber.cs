using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;


namespace DataFromXML
{
    public class PracticalLessonNumber : MonoBehaviour
    {
        private const string xmlElement = "PZI";
        private const string xmlAttribute = "number";
        private const string xmlName = "log";

        private XDocument log;
        private XML xml = new XML();

        /// <summary>
        /// статическое свойство  LessonNumber, доступно для чтения после Awake
        /// если обратиться во время Awake данного класса значение LessonNumber вернётся в виде null
        /// 
        /// так же можно подписаться на событие NumberRecived типа NumberHandler
        /// </summary>
        public static string LessonNumber { get; private set; }

        private void Start()
        {
            log = xml.LoadXML(xmlName);
            ReceiveLessonNumber();

        }

        private void ReceiveLessonNumber()
        {



            LessonNumber = LessonNameList.Instatiate.Lesson_Name;

            /*
            
            bool hasElement = log.Descendants(xmlElement).Any();
            if (hasElement)
            {
                foreach (XElement deviceElement in log.Elements(xmlElement))
                {

                    XAttribute name = deviceElement.Attribute(xmlAttribute);
                    LessonNumber = name.Value;

                    GetComponent<DeviceName>().ReceiveDeviceName(LessonNumber);

                }

            } else {

                Debug.Log("<color=red> Ошибка в XML файле " + xmlName  + ".xml. " +
                               "Файл должен содержать родительский элемент " + xmlElement +
                               ", атрибут  " + xmlAttribute + ", значение которого номер занятия.</color>");

            }


            */
        }
    }
}