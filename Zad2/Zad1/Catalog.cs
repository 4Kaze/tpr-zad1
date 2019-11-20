using SerializationModule;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    public class Catalog : ICloneable, IOwnSerializable
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

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<Event> Events { set; get; }

        public Catalog(string title, string description, string author)
        {
            Code = getNextID();
            Title = title;
            Description = description;
            Author = author;
            Events = new List<Event>();
        }

        public Catalog(Catalog catalog)
        {
            Code = catalog.Code;
            Title = catalog.Title;
            Description = catalog.Description;
            Author = catalog.Author;
            Events = new List<Event>();
            foreach (Event e in catalog.Events)
                Events.Add(e);
        }

        public Catalog() { Events = new List<Event>(); }

        public override string ToString()
        {
            string events = "{";
            foreach (Event e in Events)
            {
                events += e.Code;
                if (Events.IndexOf(e) != Events.Count - 1) events += ", ";
            }
            events += "}";
            return "Book id: " + this.Code + ", title: " + this.Title + ", description: " + this.Description + ", author: " + this.Author + ", events: " + events;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Catalog)) return false;
            return ((Catalog)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (7 * 17) ^ Code.GetHashCode();
            }
        }

        public static long getNextID()
        {
            return nextID++;
        }

        public object Clone()
        {
            return new Catalog(this);
        }

        public string Serialization(ObjectIDGenerator idGenerator)
        {
            string serializedData = "";
            serializedData += this.GetType().FullName + ";";
            serializedData += idGenerator.GetId(this, out bool firstTime).ToString() + ";";
            serializedData += this.Code.ToString() + ";";
            serializedData += this.Title + ";";
            serializedData += this.Description + ";";
            serializedData += this.Author + ";";
            if (this.Events.Count == 0)
                return serializedData + ";";

            foreach (Event e in Events)
            {
                serializedData += idGenerator.GetId(e, out firstTime);
                if (Events.IndexOf(e) != Events.Count - 1) serializedData += ",";
            }
            return serializedData + ";";
        }

        public void Deserialization(string[] data, Dictionary<long, Object>  deserializedObjects, Dictionary<object, List<long>> requiredObjects)
        {
            this.Code = long.Parse(data[2]);
            this.Title = data[3];
            this.Description = data[4];
            this.Author = data[5];

            string[] ids = data[6].Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (ids.Length == 0)
                return;
            requiredObjects.Add(this, new List<long>());
            foreach (string id in ids)
            {
                long sdId = long.Parse(id);
                if (deserializedObjects.ContainsKey(sdId))
                {
                    this.Events.Add((Event)deserializedObjects[sdId]);
                }
                else
                {
                    requiredObjects[this].Add(sdId);
                }

            }
        }
    }
}
