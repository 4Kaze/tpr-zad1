using System;

namespace Zad1
{
    public class Catalog
    {
        private static long nextID = 0;
        public long Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }

        public Catalog(string title, string description, Author author)
        {
            Code = getNextID();
            Title = title;
            Description = description;
            Author = author;
        }


        public override string ToString()
        {
            return "Book id " + this.Code + " Title: " + this.Title + ", description: " + this.Description + ", author: " + this.Author;
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

        public static long getNextID()
        {
            return nextID++;
        }

    }
}
