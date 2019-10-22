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


            List<string> authorsData = new List<string>();
            List<string> booksData = new List<string>();
            List<string> eventsData = new List<string>();
            List<string> personData = new List<string>();
            List<string> statesData = new List<string>();

            string enviromentFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileName1 = enviromentFolder + @"\Files\Authors.xml";
            string fileName2 = enviromentFolder + @"\Files\Books.xml";
            string fileName3 = enviromentFolder + @"\Files\Events.xml";
            string fileName4 = enviromentFolder + @"\Files\Persons.xml";
            string fileName5 = enviromentFolder + @"\Files\StateDescription.xml";

            this.ReadXmlData(authorsData, fileName1);
            this.ReadXmlData(booksData, fileName2);
            this.ReadXmlData(eventsData, fileName3);
            this.ReadXmlData(personData, fileName4);
            this.ReadXmlData(statesData, fileName5);

            List<Author> authors = new List<Author>();

            string[] separator = { "," };
            Int32 count = 4;


            string[] answer1;
            string[] answer2;
            string[] answer3;
            string[] answer4;
            string[] answer5;



            for (int k = 0; k < authorsData.Count; k++)
            {
                answer1 = authorsData[k].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                answer2 = booksData[k].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                answer3 = eventsData[k].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                answer4 = personData[k].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                answer5 = statesData[k].Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                

                authors.Add(new Author(answer1[0], answer1[1], System.DateTimeOffset.ParseExact(answer1[2], "dd/MM/yyyy", null)));
                dataContext.Books.Add(k, new Catalog(answer1[0], answer1[1], authors[k]));
                dataContext.Clients.Add(new Person(answer4[0], answer4[1], answer4[2]));
                dataContext.Descriptions.Add(new StateDescription(dataContext.Books[k], System.DateTimeOffset.ParseExact(answer5[0], "dd/MM/yyyy", null), answer5[1]));
                dataContext.Transactions.Add(new Event(dataContext.Clients[k], dataContext.Descriptions[k], System.DateTimeOffset.ParseExact(answer3[0], "dd/MM/yyyy", null)));
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
