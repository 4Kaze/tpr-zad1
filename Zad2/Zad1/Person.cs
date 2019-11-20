using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SerializationModule;

namespace Classes
{
    [Serializable]
    [XmlRoot("PersonRoot")]
    public class Person : ICloneable, IOwnSerializable
    {
        private static long nextID = 0;
        [XmlIgnore]
        private long code;
        [XmlElement("code")]
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
        [XmlElement("name")]
        public string Name { set; get; }
        [XmlElement("surname")]
        public string Surname { set; get; }
        [XmlElement("address")]
        public string Adress { set; get; }

        public Person(string name, string surname, string adress = null)
        {
            this.Code = getNextID();
            this.Name = name;
            this.Surname = surname;
            this.Adress = adress;
        }


        public Person(Person person)
        {
            this.Code = person.Code;
            this.Name = person.Name;
            this.Surname = person.Surname;
            this.Adress = person.Adress;
        }
        
        public Person() { }


        public override string ToString()
        {
            return "Person id " + this.Code + " name: " + this.Name + " " + this.Surname + ", with adress: " + this.Adress + ".";
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
            return serializedData;
        }

        public void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects)
        {
            this.Code = long.Parse(data[2]);
            this.Name = data[3];
            this.Surname = data[4];
            this.Adress = data[5];
        }
    }
}
