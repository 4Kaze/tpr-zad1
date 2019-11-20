using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace SerializationModule
{
    public class OwnSerialization : ISerializator
    {
        private Dictionary<long, Object> deserializedObjects;
        private List<string[]> deserializedData;
        private string serializedData;
        private Char separatorChar = ';';

        public string Version { get; set; }

        public OwnSerialization()
        {
            Version = "1.0";
            deserializedObjects = new Dictionary<long, Object>();
            deserializedData = new List<string[]>();
        }


        public DataContext Deserialize(Stream stream)
        {
            DataContext answerContext = new DataContext();
            StreamReader sr = new StreamReader(stream);
            string line;
            string version = sr.ReadLine();
            Char[] spearator = { separatorChar };
            while ((line = sr.ReadLine()) != null)
            {
                deserializedData.Add(line.Split(spearator));
            }

            DeserializationDecision(answerContext);
            return answerContext;
        }

        public void Serialize(DataContext dataContext, Stream stream)
        {
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            serializedData = Version+"\n";
            foreach(Person person in dataContext.Clients)
            {
                serializedData += person.Serialization(idGenerator) + "\n";
            }

            foreach(KeyValuePair<long, Catalog> book in dataContext.Books)
            {
                serializedData += book.Value.Serialization(idGenerator) + book.Key + separatorChar + "\n";
            }

            foreach (StateDescription description in dataContext.Descriptions)
            {
                serializedData += description.Serialization(idGenerator) + "\n";
            }

            foreach (Event transaction in dataContext.Transactions)
            {
                serializedData += transaction.Serialization(idGenerator) + "\n";
            }

            StreamWriter outputFile = new StreamWriter(stream);
            outputFile.WriteLine(serializedData);
            outputFile.Flush();
        }


        private void DeserializationDecision(DataContext dataContext)
        {
            string dataType = "";
            Dictionary<object, List<long>> requiredPeople = new Dictionary<object, List<long>>();
            Dictionary<object, List<long>> requiredStateDescriptions = new Dictionary<object, List<long>>();
            
            foreach (string[] data in this.deserializedData)
            {
                dataType = data[0];
                switch (dataType)
                {
                    case "Classes.Person":
                        Person person = new Person();
                        person.Deserialization(data, this.deserializedObjects, requiredStateDescriptions);
                        dataContext.Clients.Add(person);
                        this.deserializedObjects.Add(long.Parse(data[1]), person);
                        break;
                    case "Classes.Catalog":
                        Catalog catalog = new Catalog();
                        catalog.Deserialization(data, this.deserializedObjects, null);
                        dataContext.Books.Add(long.Parse(data[data.Length-2]), catalog);
                        this.deserializedObjects.Add(long.Parse(data[1]), catalog);
                        break;
                    case "Classes.BorrowEvent":
                        BorrowEvent borrowEvent = new BorrowEvent();
                        borrowEvent.Deserialization(data, this.deserializedObjects, null);
                        dataContext.Transactions.Add(borrowEvent);
                        this.deserializedObjects.Add(long.Parse(data[1]), borrowEvent);
                        break;
                    case "Classes.ReturnEvent":
                        ReturnEvent returnEvent = new ReturnEvent();
                        returnEvent.Deserialization(data, this.deserializedObjects, null);
                        dataContext.Transactions.Add(returnEvent);
                        this.deserializedObjects.Add(long.Parse(data[1]), returnEvent);
                        break;
                    case "Classes.StateDescription":
                        StateDescription stateDescription = new StateDescription();
                        stateDescription.Deserialization(data, this.deserializedObjects, requiredPeople);
                        dataContext.Descriptions.Add(stateDescription);
                        this.deserializedObjects.Add(long.Parse(data[1]), stateDescription);
                        break;
                    default:
                        break;
                }
            }

            foreach(KeyValuePair<object, List<long>> pair in requiredPeople)
            {
                ((StateDescription)pair.Key).Owner = (Person)deserializedObjects[pair.Value[0]];
            }

            foreach (KeyValuePair<object, List<long>> pair in requiredStateDescriptions)
            {
                foreach(long stateId in pair.Value)
                {
                    ((Person)pair.Key).Books.Add((StateDescription)deserializedObjects[stateId]);
                }
            }

        }
    }
}
