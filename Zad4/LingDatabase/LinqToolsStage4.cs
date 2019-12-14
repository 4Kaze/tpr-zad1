using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class LinqToolsStage4
    {
        public static List<Product> GetProductsWithoutCategory(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }



        public static List<Product> GetProductsWithoutCategoryQuery(this List<Product> products)
        {
            List<Product> answer = (from product in products
                                    where product.ProductSubcategory == null
                                    select product).ToList();
            return answer;
        }


        public static List<Product> GetProductsAsPage(this List<Product> products, int pageNumber, int productsNumber)
        {
            return products.Skip(productsNumber * (pageNumber-1)).Take(productsNumber).ToList();
        }

        public static string GetVendorProductList(this List<Product> products, List<ProductVendor> vendors)
        {
            string result = "";
            var answer = (from product in products
                          from vendor in vendors
                          where vendor.ProductID.Equals(product.ProductID)
                          select product.Name + "-" + vendor.Vendor.Name).ToList();
            for(int i = 0; i < answer.Count; i++)
            {
                result += answer[i];
                if (i != answer.Count-1) result += Environment.NewLine;
            }
            return result;

        }

        public static string GetVendorProductListLambda(this List<Product> products, List<ProductVendor> vendors)
        {
            string result = "";
            var answer = products.Join(vendors, product => product.ProductID, vendor => vendor.ProductID, (product, vendor) => product.Name + "-" + vendor.Vendor.Name).ToList();

            for (int i = 0; i < answer.Count; i++)
            {
                result += answer[i];
                if (i != answer.Count - 1) result += Environment.NewLine;
            }
            return result;

        }
    }
}
