using System;

namespace Zad1
{
    public class Author
    {
        public long Code { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset DateOfBirth { get; }

        public Author(long code, string name, string surname, DateTimeOffset dateOfBirth)
        {
            Code = code;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
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
    }
}
