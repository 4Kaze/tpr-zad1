using System;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    [XmlRoot("DescriptionRoot")]
    public class StateDescription : ICloneable
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
        public Catalog Book { set; get; }
        [XmlElement]
        public bool Availabile { set; get; }
        [XmlElement]
        public DateTimeOffset PurchaseDate { get; }
        [XmlElement]
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
    }
}
