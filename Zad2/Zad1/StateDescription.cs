using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SerializationModule;

namespace Classes
{
    [Serializable]
    [XmlRoot("DescriptionRoot")]
    public class StateDescription : ICloneable, IOwnSerializable
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
        [XmlElement("book")]
        public Catalog Book { set; get; }
        [XmlElement("avaliable")]
        public bool Availabile { set; get; }
        [XmlElement("purchaseDate")]
        public DateTimeOffset PurchaseDate { get; set; }
        [XmlElement("location")]
        public string Location { set; get; }

        public StateDescription(Catalog book, DateTimeOffset purchaseDate, string location)
        {
            Code = getNextID();
            Book = book;
            Availabile = true;
            PurchaseDate = purchaseDate;
            Location = location;
        }

        public StateDescription(StateDescription description)
        {
            Code = description.Code;
            Book = description.Book;
            Availabile = description.Availabile;
            PurchaseDate = description.PurchaseDate;
            Location = description.Location;
        }

        public StateDescription() { }

        public override string ToString()
        {
            return "StateDescription id " + this.Code + " catalog: " + this.Book + ", purchase date: " + this.PurchaseDate + ", where " + this.Location + ".";
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is StateDescription)) return false;
            return ((StateDescription)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (23 * 37) ^ Code.GetHashCode();
            }
        }

        public static long getNextID()
        {
            return nextID++;
        }

        public object Clone()
        {
            return new StateDescription(this);
        }
        
        public string Serialization(ObjectIDGenerator idGenerator)
        {
            string serializedData = "";
            serializedData += this.GetType().FullName + ";";
            serializedData += idGenerator.GetId(this, out bool firstTime).ToString() + ";";
            serializedData += this.Code.ToString() + ";";
            serializedData += idGenerator.GetId(this.Book, out firstTime).ToString() + ";";
            serializedData += this.Availabile.ToString() + ";";
            serializedData += this.PurchaseDate.ToString() + ";";
            serializedData += this.Location + ";";
            return serializedData;
        }

        public void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects)
        {
            this.Code = long.Parse(data[2]);
            this.Book = (Catalog)deserializedObjects[long.Parse(data[3])]; 
            this.Availabile = bool.Parse(data[4]);
            this.PurchaseDate = DateTimeOffset.Parse(data[5]);
            this.Location = data[6];
        }
    }
}
