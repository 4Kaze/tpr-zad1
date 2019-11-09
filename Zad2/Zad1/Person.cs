using System;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    [XmlRoot("PersonRoot")]
    public class Person : ICloneable
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
        public string Name { set; get; }
        [XmlElement]
        public string Surname { set; get; }
        [XmlElement]
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
        
        public Person()
        {

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
