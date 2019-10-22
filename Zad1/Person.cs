using System;

namespace Zad1
{
    public class Person : ICloneable
    {

        private static long nextID = 0;
        public long Code { get; set; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Adress { set; get; }

        public Person(string name, string surname, string adress = null)
        {
            this.Code = getNextID();
            this.Name = name;
            this.Surname = surname;
            this.Adress = adress;
        }


        public Person(Person person)
        {
            this.Code = person.Code;
            this.Name = person.Name;
            this.Surname = person.Surname;
            this.Adress = person.Adress;
        }
        


        public override string ToString()
        {
            return "Person id " + this.Code + " name: " + this.Name + " " + this.Surname + ", with adress: " + this.Adress + ".";
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

        public static long getNextID()
        {
            return nextID++;
        }

        public object Clone()
        {
            return new Person(this);
        }
    }
}
