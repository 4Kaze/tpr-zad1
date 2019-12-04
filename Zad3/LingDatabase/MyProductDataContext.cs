using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingDatabase
{
    public class MyProductDataContext
    {
        public List<MyProduct> products { get; private set; }

        public MyProductDataContext(DataClasses1DataContext dataContext)
        {
            int i = 0;
            this.products = dataContext.Products.AsEnumerable().Select(product => new MyProduct(product, i++)).ToList();
        }

        public List<MyProduct> GetProductsByName(string nameContains)
        {
            return (from product in products
                    where product.Name.ToLower().Contains(nameContains.ToLower())
                    select product).ToList();
        }


        public List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            return (from product in products
                    where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select product).Take(n).ToList();
        }


        public List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return (from product in products
                    where product.ProductReviews.Count == howManyReviews
                    select product).ToList();
        }
    }
}
