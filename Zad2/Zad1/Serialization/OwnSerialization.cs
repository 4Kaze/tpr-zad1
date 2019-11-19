﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Classes.Serialization
{
    public class OwnSerialization : Serializator
    {
        private Dictionary<long, Object> DeserializedObjects { get; set; }
        public List<string[]> DeserializedData { get; set; }
        private string SerializedData { get; set; }
        public string DeserializedString { get; set; }
        public string Path { get; set; }
        

        public OwnSerialization()
        {
            DeserializedObjects = new Dictionary<long, Object>();
            DeserializedData = new List<string[]>();
        }


        public DataContext Deserialize()
        {
            DataContext answerContext = new DataContext();
            using (StreamReader sr = new StreamReader(Path + ".txt"))
            {
                DeserializedString = "";
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    DeserializedString += line;
                    String[] spearator = { ";" };
                    Int32 count = 7;
                    DeserializedData.Add(line.Split(spearator, count, StringSplitOptions.RemoveEmptyEntries));
                }

            }
            DeserializationDecision(answerContext);
            return answerContext;
        }

        public void Serialize(DataContext dataContext)
        {
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            SerializedData = PrepareSerialization(dataContext, idGenerator);

            using (StreamWriter outputFile = new StreamWriter(Path + ".txt"))
            {
                outputFile.WriteLine(SerializedData);
            }
        }


        private void DeserializationDecision(DataContext dataContext)
        {
            string dataType = "";
            foreach (string[] data in this.DeserializedData)
            {
                try
                {
                    dataType = data[0];
                }
                catch (System.IndexOutOfRangeException exception)
                {
                    dataType = "";
                }
                switch (dataType)
                {
                    case "Classes.Person":
                        Person person = new Person();
                        person.Deserialization(data, this.DeserializedObjects);
                        dataContext.Clients.Add(person);
                        this.DeserializedObjects.Add(long.Parse(data[1]), person);
                        break;
                    case "Classes.Catalog":
                        Catalog catalog = new Catalog();
                        catalog.Deserialization(data, this.DeserializedObjects);
                        dataContext.Books.Add(catalog.Code, catalog);
                        this.DeserializedObjects.Add(long.Parse(data[1]), catalog);
                        break;
                    case "Classes.BorrowEvent":
                        BorrowEvent borrowEvent = new BorrowEvent();
                        borrowEvent.Deserialization(data, this.DeserializedObjects);
                        dataContext.Transactions.Add(borrowEvent);
                        this.DeserializedObjects.Add(long.Parse(data[1]), borrowEvent);
                        break;
                    case "Classes.ReturnEvent":
                        ReturnEvent returnEvent = new ReturnEvent();
                        returnEvent.Deserialization(data, this.DeserializedObjects);
                        dataContext.Transactions.Add(returnEvent);
                        this.DeserializedObjects.Add(long.Parse(data[1]), returnEvent);
                        break;
                    case "Classes.StateDescription":
                        StateDescription stateDescription = new StateDescription();
                        stateDescription.Deserialization(data, this.DeserializedObjects);
                        dataContext.Descriptions.Add(stateDescription);
                        this.DeserializedObjects.Add(long.Parse(data[1]), stateDescription);
                        break;
                    default:
                        break;
                }
            }
        }


        public string PrepareSerialization(DataContext dataContext, ObjectIDGenerator idGenerator)
        {
            String stringStream = "";
            foreach (Person person in dataContext.Clients)
            {
                stringStream += person.Serialization(idGenerator) + "\n";
            }

            foreach (KeyValuePair<long, Catalog> book in dataContext.Books)
            {
                stringStream += book.Value.Serialization(idGenerator) + "\n";
            }

            foreach (StateDescription description in dataContext.Descriptions)
            {
                stringStream += description.Serialization(idGenerator) + "\n";
            }

            foreach (Event transaction in dataContext.Transactions)
            {
                stringStream += transaction.Serialization(idGenerator) + "\n";
            }
            return stringStream;
        }
    }
}