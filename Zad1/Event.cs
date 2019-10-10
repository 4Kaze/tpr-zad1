using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Event
    {
        public long Code { get; }
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

        public override bool Equals(Object obj)
        {
            if (!(obj is Event)) return false;
            return ((Event)obj).Code == Code;
        }
    }
}
