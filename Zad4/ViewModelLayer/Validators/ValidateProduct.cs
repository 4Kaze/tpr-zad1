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
        public static bool CheckProduct(Product p)
        {
            return true;
            return !string.IsNullOrEmpty(p.Name) && !string.IsNullOrEmpty(p.ProductNumber) && p.SafetyStockLevel >= 0 && p.ReorderPoint >= 0
                && p.ListPrice >= 0 && p.DaysToManufacture >= 0 && p.SellStartDate != null;
        } 

        public static bool CheckDate(Product p)
        {
            if(p.SellEndDate != null && p.SellEndDate < p.SellStartDate)
            {
                return false;
            }
            if (p.DiscontinuedDate != null && p.DiscontinuedDate < p.SellStartDate)
            {
                return false;
            }
            return true;
        }
    }
}
