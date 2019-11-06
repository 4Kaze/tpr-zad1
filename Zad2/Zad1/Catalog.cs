using System;
using System.Runtime.Serialization;

namespace Zad1
{
    [Serializable]
    public class Catalog : ICloneable, ISerializable
    {
        private static long nextID = 0;
        private long code;
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
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public Catalog(string title, string description, string author)
        {
            Code = getNextID();
            Title = title;
            Description = description;
            Author = author;
        }

        public Catalog(Catalog catalog)
        {
            Code = catalog.Code;
            Title = catalog.Title;
            Description = catalog.Description;
            Author = catalog.Author;
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

        public object Clone()
        {
            return new Catalog(this);
        }

        protected Catalog(SerializationInfo info, StreamingContext context)
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
