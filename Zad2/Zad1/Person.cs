using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SerializationModule;

namespace Classes
{
    [Serializable]
    public class Person : ICloneable, IOwnSerializable
    {
        private static long nextID = 0;
        private long code;
        public long Code
        {
            get { return code; }
            set
            {
                if (value > nextID)
                    nextID = value + 1;
                code = value;
            }
        }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Adress { set; get; }
        public List<StateDescription> Books { get; }

        public Person(string name, string surname, string adress = null)
        {
            this.Code = getNextID();
            this.Name = name;
            this.Surname = surname;
            this.Adress = adress;
            this.Books = new List<StateDescription>();
        }


        public Person(Person person)
        {
            this.Code = person.Code;
            this.Name = person.Name;
            this.Surname = person.Surname;
            this.Adress = person.Adress;
            this.Books = new List<StateDescription>();
            foreach(StateDescription sd in person.Books) {
                this.Books.Add(sd);
            }
        }
        
        public Person() {
            this.Books = new List<StateDescription>();
        }


        public override string ToString()
        {
            string books = "{";
            foreach (StateDescription sd in Books)
            {
                books += sd.Code;
                if (Books.IndexOf(sd) != Books.Count - 1) books += ", ";
            }
            books += "}";
            return "Person id: " + this.Code + " name: " + this.Name + " " + this.Surname + ", adress: " + this.Adress + ", books: " + books + ".";
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Person)) return false;
            return ((Person)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (31 * 5) ^ Code.GetHashCode();
            }
        }

        public static long getNextID()
        {
            return nextID++;
        }

        public object Clone()
        {
            return new Person(this);
        }

        public string Serialization(ObjectIDGenerator idGenerator)
        {
            string serializedData = "";
            serializedData += this.GetType().FullName + ";";
            serializedData += idGenerator.GetId(this, out bool firstTime).ToString() + ";";
            serializedData += this.Code.ToString() + ";";
            serializedData += this.Name.ToString() + ";";
            serializedData += this.Surname.ToString() + ";";
            serializedData += this.Adress + ";";

            if (this.Books.Count == 0)
                return serializedData + ";";

            foreach (StateDescription book in Books)
            {
                serializedData += idGenerator.GetId(book, out firstTime);
                if (Books.IndexOf(book) != Books.Count - 1) serializedData += ","; 
            }
            return serializedData + ";";
        }

        public void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects, Dictionary<object, List<long>> requiredStateDescriptions)
        {
            this.Code = long.Parse(data[2]);
            this.Name = data[3];
            this.Surname = data[4];
            this.Adress = data[5];
            string[] ids = data[6].Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (ids.Length == 0)
                return;
            requiredStateDescriptions.Add(this, new List<long>());
            foreach (string id in ids)
            {
                long sdId = long.Parse(id);
                if(deserializedObjects.ContainsKey(sdId))
                {
                    this.Books.Add((StateDescription)deserializedObjects[sdId]);
                } else
                {
                    requiredStateDescriptions[this].Add(sdId);
                }
                
            }
        }
    }
}
