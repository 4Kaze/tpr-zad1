using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SerializationModule;

namespace Classes
{
    [Serializable]
    public abstract class Event : ICloneable, IOwnSerializable
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
        public Person Causer { get; set; }
        public StateDescription BookState { get; set; }
        public DateTimeOffset Date { get; set; }

        public Event(Person causer, StateDescription bookState, DateTimeOffset date)
        {
            Code = getNextID();
            Causer = causer;
            BookState = bookState;
            Date = date;
        }

        public Event()
        {

        }

        public override string ToString()
        {
            return "Event id: " + this.Code + " causer: " + this.Causer.Code + ", book state" + this.BookState.Code + ", date: " + this.Date + ".";
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Event)) return false;
            return ((Event)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (19 * 29) ^ Code.GetHashCode();
            }
        }

        public static long getNextID()
        {
            return nextID++;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public virtual string Serialization(ObjectIDGenerator idGenerator)
        {
            string serializedData = "";
            serializedData += this.GetType().FullName + ";";
            serializedData += idGenerator.GetId(this, out bool firstTime).ToString() + ";";
            serializedData += this.Code.ToString() + ";";
            serializedData += idGenerator.GetId(this.Causer, out firstTime).ToString() + ";";
            serializedData += idGenerator.GetId(this.BookState, out firstTime).ToString() + ";";
            serializedData += this.Date + ";";
            return serializedData;
        }

        public void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects, Dictionary<object, List<long>> r) 
        {
            this.Code = long.Parse(data[2]);
            this.Causer = (Person)deserializedObjects[long.Parse(data[3])];
            this.BookState = (StateDescription)deserializedObjects[long.Parse(data[4])];
            this.Date = DateTimeOffset.Parse(data[5]);
        }
    }
}
