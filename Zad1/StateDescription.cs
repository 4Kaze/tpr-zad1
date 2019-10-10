using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class StateDescription
    {
        public long Code { get; }
        public Catalog Book { set; get; }
        public bool Availabile { set; get; }
        public DateTimeOffset PurchaseDate { get; }
        public string Location { set; get; }

        public StateDescription(long code, Catalog book, DateTimeOffset purchaseDate, string location)
        {
            Code = code;
            Book = book;
            Availabile = true;
            PurchaseDate = purchaseDate;
            Location = location;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is StateDescription)) return false;
            return ((StateDescription)obj).Code == Code;
        }

    }
}
