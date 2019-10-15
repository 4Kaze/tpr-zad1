using System;
using System.Xml;
using Zad1;

namespace App
{
    public class FillFileData : IFillInterface
    {
        public void FillData(DataContext dataContext)
        {
            string[] personData = new string[3];
            int i = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Users\btmik\Desktop\kopier i pieroły\Semestr 5\Technoligie programowanie\Authors.xml");
            foreach(XmlNode node in xmlDoc.DocumentElement)
            {
                foreach(XmlNode child in node.ChildNodes)
                {
                    personData[i] += child.InnerText + ","; 
                }
                i++;
            }


            string[] separator = { "," };
            Int32 count = 3;
            string[] answer;
            for(int k = 0; k < 3; k++)
            {
                answer = personData[k].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                dataContext.Clients.Add(new Person(answer[0], answer[1], answer[2]));
            }
        }
    }
}
