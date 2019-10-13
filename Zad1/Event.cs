using System;

namespace Zad1
{
    public class Event
    {
        public long Code { get; set;  }
        public Person Causer { get; }
        public StateDescription BookState { get; }
        public DateTimeOffset BorrowDate { get; }
        public DateTimeOffset ReturnDate { get; set; }
        
        public Event(long code, Person causer, StateDescription bookState, DateTimeOffset borrowDate)
        {
            Code = code;
            Causer = causer;
            BookState = bookState;
            BorrowDate = borrowDate;
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
    }
}
