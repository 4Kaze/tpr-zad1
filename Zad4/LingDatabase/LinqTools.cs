using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

namespace Model
{
    public static class LinqTools
    {


        public static IList<Product> GetAllProducts()
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                IQueryable<Product> answer = (from product in products
                                        select product);
                return answer.ToList();
            }
        }
        

        public static List<Product> GetProductsByName(string nameContains)
        {
            using(DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                List<Product> answer = (from product in products
                                        where product.Name.Contains(nameContains)
                                        select product).ToList();
                return answer;
            }
        }


        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<Product> answer = (from productVendor in productsVendors
                                        where productVendor.Vendor.Name.Equals(vendorName)
                                        select productVendor.Product).ToList();
                return answer;
            }
        }


        public static List<string>  GetProductNamesByVendorName(string vendorName)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<string> answer = (from productVendor in productsVendors
                                       where productVendor.Vendor.Name.Equals(vendorName)
                                       select productVendor.Product.Name).ToList();
                return answer;
            }
        }


        public static string GetProductVendorByProductName(string productName)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<ProductVendor> productsVendors = dataContext.GetTable<ProductVendor>();
                List<string> answer = (from productVendor in productsVendors
                                       where productVendor.Product.Name.Equals(productName)
                                       select productVendor.Vendor.Name).ToList();
                return answer[0];
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                Table<ProductReview> reviewes = dataContext.GetTable<ProductReview>();

                List<Product> answer = (from product in products
                                        where product.ProductReviews.Count == howManyReviews
                                        select product).ToList();
                return answer;
            }
        }


        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<ProductReview> reviewes = dataContext.GetTable<ProductReview>();
                List<Product> answer = (from review in reviewes
                                        orderby review.ReviewDate descending
                                        group review.Product by review.ProductID into p
                                        select p.First()).Take(howManyProducts).ToList();
                return answer;
            }
        }


        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            Table<Product> products = dataContext.GetTable<Product>();
            List<Product> answer = (from product in products
                                    where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                    select product).Take(n).ToList();
            return answer;
        }


        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>(); ;
                decimal answer = (from product in products
                                  where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                                  select product.StandardCost).ToList().Sum();
                return (int)answer;
            }
        }


        public static void AddNeProduct(Product product)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                dataContext.Products.InsertOnSubmit(product);
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
        }




        public static int RemoveProduct(int productId)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                var answer = dataContext.GetTable<Product>().Single(t => t.ProductID == productId); 
                dataContext.Products.DeleteOnSubmit(answer);
                dataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                if(answer != null)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
