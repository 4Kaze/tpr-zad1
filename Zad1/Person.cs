using System;

namespace Zad1
{
    public class Person
    {
        
        public long Code { get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Adress { set; get; }

        public Person(long code, string name, string surname, string adress = null)
        {
            this.Code = code;
            this.Name = name;
            this.Surname = surname;
            this.Adress = adress;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Person)) return false;
            return ((Person)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (31 * 5) ^ Code.GetHashCode();
            }
        }

    }
}
