using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Validators
{
    public static class ValidateProduct
    {
        public static bool CheckDate(Product p)
        {
            if(p.SellEndDate != null && p.SellEndDate < p.SellStartDate)
            {
                return false;
            }
            return true;
        }
    }
}
