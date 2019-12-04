using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingDatabase
{
    public class MyProduct : Product
    {
        public int Modification { get; set; }

        public MyProduct(Product product, int modification)
        {
            foreach (var property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(product));
            }
                
            this.Modification = modification;
        }
    }
}
