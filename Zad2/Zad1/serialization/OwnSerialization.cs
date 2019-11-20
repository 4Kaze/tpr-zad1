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
        private Dictionary<long, Object> DeserializedObjects { get; set; }
        public List<string[]> DeserializedData { get; set; }
        private string SerializedData { get; set; }

        private Char separatorChar = ';';

        public OwnSerialization()
        {
            DeserializedObjects = new Dictionary<long, Object>();
            DeserializedData = new List<string[]>();
        }


        public DataContext Deserialize(Stream stream)
        {
            DataContext answerContext = new DataContext();
            StreamReader sr = new StreamReader(stream);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Char[] spearator = { separatorChar };
                DeserializedData.Add(line.Split(spearator));
            }

            DeserializationDecision(answerContext);
            return answerContext;
        }

        public void Serialize(DataContext dataContext, Stream stream)
        {
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            SerializedData = "";
            foreach(Person person in dataContext.Clients)
            {
                SerializedData += person.Serialization(idGenerator) + "\n";
            }

            foreach(KeyValuePair<long, Catalog> book in dataContext.Books)
            {
                SerializedData += book.Value.Serialization(idGenerator) + book.Key + separatorChar + "\n";
            }

            foreach (StateDescription description in dataContext.Descriptions)
            {
                SerializedData += description.Serialization(idGenerator) + "\n";
            }

            foreach (Event transaction in dataContext.Transactions)
            {
                SerializedData += transaction.Serialization(idGenerator) + "\n";
            }

            StreamWriter outputFile = new StreamWriter(stream);
            outputFile.WriteLine(SerializedData);
            outputFile.Flush();
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
                catch (System.IndexOutOfRangeException e)  // CS0168
                {
                    dataType = "";
                    Console.WriteLine("oststni element");
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
                        dataContext.Books.Add(long.Parse(data[data.Length-2]), catalog);
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
    }
}
