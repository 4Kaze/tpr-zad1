using System;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    [XmlRoot("EventRoot")]
    public abstract class Event : ICloneable
    {
        [XmlElement("nextId")]
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
        [XmlElement("causer")]
        public Person Causer { get; set; }
        [XmlElement("book")]
        public StateDescription BookState { get; set; }
        [XmlElement("date")]
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
            return "Event id " + this.Code + " causer: " + this.Causer + ", book state" + this.BookState + ", date: " + this.Date + ".";
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
    }
}
