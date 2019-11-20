using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    public class ReturnEvent : Event
    {
        public ReturnEvent(Person causer, StateDescription bookState, DateTimeOffset date) : base(causer, bookState, date)
        {

        }

        public ReturnEvent(ReturnEvent happening)
        {
            Code = happening.Code;
            Causer = happening.Causer;
            BookState = happening.BookState;
            Date = happening.Date;
        }

        public ReturnEvent() { }

        public override string ToString()
        {
            return "[Return] " + base.ToString();
        }

        public object Clone()
        {
            return new ReturnEvent(this);
        }

    }
}
