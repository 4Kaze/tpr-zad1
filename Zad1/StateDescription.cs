using System;

namespace Zad1
{
    public class StateDescription
    {
        private static long nextID = 0;
        public long Code { get; set; }
        public Catalog Book { set; get; }
        public bool Availabile { set; get; }
        public DateTimeOffset PurchaseDate { get; }
        public string Location { set; get; }

        public StateDescription(Catalog book, DateTimeOffset purchaseDate, string location)
        {
            Code = getNextID();
            Book = book;
            Availabile = true;
            PurchaseDate = purchaseDate;
            Location = location;
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
    }
}
