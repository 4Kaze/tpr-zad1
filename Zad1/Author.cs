using System;

namespace Zad1
{
    public class Author : ICloneable
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
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset DateOfBirth { get; }

        
        public Author(string name, string surname, DateTimeOffset dateOfBirth)
        {
            Code = getNextID();
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }



        public Author(Author author)
        {
            Code = author.Code;
            Name = author.Name;
            Surname = author.Surname;
            DateOfBirth = author.DateOfBirth;
        }


        public override string ToString()
        {
            return "Author id " + this.Code + " name: " + this.Name + " " + this.Surname + ", Date of Birth: " + this.DateOfBirth + ".";
        }


        public override bool Equals(Object obj)
        {
            if (!(obj is Author)) return false;
            return ((Author)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (11 * 13) ^ Code.GetHashCode();
            }
        }

        public static long getNextID()
        {
            return nextID++;
        }

        public object Clone()
        {
            return new Author(this);
        }
    }
}
