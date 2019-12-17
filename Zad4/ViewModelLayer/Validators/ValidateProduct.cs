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
            bool flag = true;
            flag = p.Name != null;
            flag = p.ProductNumber != null;
            flag = p.Color != null;
            flag = p.SafetyStockLevel != 0;
            flag = p.ReorderPoint != 0;
            flag = p.StandardCost != 0;
            flag = p.ListPrice != 0;
            flag = p.Size != null;
            flag = p.SizeUnitMeasureCode != null;
            flag = p.WeightUnitMeasureCode != null;
            flag = p.Weight != null;
            flag = p.DaysToManufacture >= 0;
            flag = p.ProductLine != null;
            flag = p.Class != null;
            flag = p.Style != null;
            //flag = p.ProductSubcategoryID != 0;
            //flag = p.ProductModelID != 0;
            return flag;
        } 

        public static bool CheckDate(Product p)
        {
            if(p.SellEndDate < p.SellStartDate)
            {
                return false;
            }
            if (p.SellStartDate < DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
}
