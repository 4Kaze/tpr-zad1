using System;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    [XmlRoot("CatalogRoot")]
    public class Catalog : ICloneable
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
        public string Title { get; set; }
        [XmlElement]
        public string Description { get; set; }
        [XmlElement]
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
    }
}
