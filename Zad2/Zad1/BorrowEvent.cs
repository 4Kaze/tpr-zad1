using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    [XmlRoot("Borrow")]
    public class BorrowEvent : Event
    {
        public BorrowEvent(Person causer, StateDescription bookState, DateTimeOffset date) : base(causer, bookState, date)
        {

        }

        public BorrowEvent(BorrowEvent happening)
        {
            Code = happening.Code;
            Causer = happening.Causer;
            BookState = happening.BookState;
            Date = happening.Date;
        }

        public BorrowEvent() { }

        public override string ToString()
        {
            return "[Borrow] " + base.ToString();
        }

        public object Clone()
        {
            return new BorrowEvent(this);
        }

    }
}
