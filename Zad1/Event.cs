using System;

namespace Zad1
{
    public class Event : ICloneable
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
        public Person Causer { get; }
        public StateDescription BookState { get; }
        public DateTimeOffset BorrowDate { get; }
        public DateTimeOffset ReturnDate { get; }
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
