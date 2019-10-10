using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
