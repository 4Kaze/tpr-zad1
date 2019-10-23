using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using Zad1;

namespace App
{
    public class FillFileData : IFillInterface
    {
        public void FillData(DataContext dataContext)
        {
            string enviromentFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string bookFile = enviromentFolder + @"\Files\Books.xml";
            string eventFile = enviromentFolder + @"\Files\Events.xml";
            string personFile = enviromentFolder + @"\Files\Persons.xml";
            string stateDescFile = enviromentFolder + @"\Files\StateDescription.xml";


        }
        
        private void loadBooks(string filename, DataContext dataContext)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
               // Catalog catalog = new Catalog()
            }
        }


        public void ReadXmlData(List<string> neededData, string fileName)
        {
            string helper = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    helper += child.InnerText + ",";
                }
                neededData.Add(helper);
                helper = "";
            }
        }
    }
}
