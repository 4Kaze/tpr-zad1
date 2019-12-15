using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Service
{
    public class ServiceProvider
    {
        public static IProductService ProductService { get; set; }

        public static void Initialize()
        {
            ProductService = new ProductService();
        }
    }
}
