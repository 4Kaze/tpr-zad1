using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Catalog
    {
        public long Code { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }

        public Catalog(long code, string title, string description, Author author)
        {
            Code = code;
            Title = title;
            Description = description;
            Author = author;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Catalog)) return false;
            return ((Catalog)obj).Code == Code;
        }

    }
}
