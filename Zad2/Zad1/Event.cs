using System;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    [XmlRoot("EventRoot")]
    public class Event : ICloneable
    {
        [XmlElement]
        private static long nextID = 0;
        [XmlElement]
        private long code;
        [XmlElement]
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
        [XmlElement]
        public Person Causer { get; }
        [XmlElement]
        public StateDescription BookState { get; }
        [XmlElement]
        public DateTimeOffset BorrowDate { get; }
        [XmlElement]
        public DateTimeOffset ReturnDate { get; }
        [XmlElement]
        public EventType Type { get; }
        public enum EventType { Borrow, Return };

        public Event(Person causer, StateDescription bookState, EventType type, DateTimeOffset date)
        {
            Code = getNextID();
            Causer = causer;
            Type = type;
            BookState = bookState;

            if(type == EventType.Borrow)
            {
                BorrowDate = date;
            } else
            {
                BookState = bookState;
            }
        }

        public Event(Event hapenning)
        {
            Code = hapenning.Code;
            Causer = hapenning.Causer;
            BookState = hapenning.BookState;
            BorrowDate = hapenning.BorrowDate;
            ReturnDate = hapenning.ReturnDate;
        }

        public override string ToString()
        {
            return "Event id " + this.Code + " causer: " + this.Causer + ", book state" + this.BookState + ", borrow date: " + this.BorrowDate + ".";
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
            return new Event(this);
        }
    }
}
