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
        /// ����������� ��������  LessonNumber, �������� ��� ������ ����� Awake
        /// ���� ���������� �� ����� Awake ������� ������ �������� LessonNumber ������� � ���� null
        /// 
        /// ��� �� ����� ����������� �� ������� NumberRecived ���� NumberHandler
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

                Debug.Log("<color=red> ������ � XML ����� " + xmlName  + ".xml. " +
                               "���� ������ ��������� ������������ ������� " + xmlElement +
                               ", �������  " + xmlAttribute + ", �������� �������� ����� �������.</color>");

            }


            */
        }
    }
}