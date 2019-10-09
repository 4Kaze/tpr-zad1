using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Client
    {
        
        public string Code { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Adress { set; get; }



        public Client(string Code, string Name, string Surname, string Adress)
        {
            this.Code = Code;
            this.Name = Name;
            this.Surname = Surname;
            this.Adress = Adress;
        }


        public Client(string Code, string Name, string Surname)
        {
            this.Code = Code;
            this.Name = Name;
            this.Surname = Surname;
            this.Adress = "";
        }

    }
}
