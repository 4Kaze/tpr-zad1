using DataLayaer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayaer
{
    public class MainControll
    {
        public List<Product> Products { get; set; }

        public MainControll()
        {
            Products = LinqTools.GetAllProducts();
        }
    }
}
