using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace DataFromXML
{
    public class XML
    {
        private XDocument _xml;
        /// <summary>
        /// Параметр по умолчанию путь /XML.
        /// Задаваемый параметр имя XML файла.
        /// XML должен храниться в Assets/Resources/ + pathPart
        /// </summary>
        /// <param name="path"></param>
        /// <returns>XDocument</returns>
        public XDocument LoadXML(string name, string pathPart = "XML/")
        {
            TextAsset file = Resources.Load<TextAsset>(pathPart + name);
            _xml = XDocument.Parse(file.text);
            return _xml;

        }

    }

}