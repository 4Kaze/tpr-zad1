using System;

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

        public override int GetHashCode()
        {
            unchecked
            {
                return (7 * 17) ^ Code.GetHashCode();
            }
        }

    }
}
