using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Catalog
    {
        public Catalog( string NewCode, string Name)
        {
            Code = NewCode;
            ProductName = Name;
            Details = "";
        }
        public string Code { get; }
        public string Details { get; set; }
        public string ProductName { get; }
    }
}
