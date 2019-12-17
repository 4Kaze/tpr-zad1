using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System;

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


        public static void AddNewProduct(Product product)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                product.ModifiedDate = DateTime.Today;
                product.rowguid = Guid.NewGuid();
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

        public static Product GetProductById(int productId)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                try
                {
                    return dataContext.GetTable<Product>().Single(t => t.ProductID == productId);
                }
                catch
                {
                    return null;
                }
                
            }

        }

        public static void UpdateProduct(Product product)
        {
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Product originalProduct = dataContext.GetTable<Product>().Single(t => t.ProductID == product.ProductID);
                originalProduct.Name = product.Name;
                originalProduct.ProductNumber = product.ProductNumber;
                originalProduct.MakeFlag = product.MakeFlag;
                originalProduct.FinishedGoodsFlag = product.FinishedGoodsFlag;
                originalProduct.Color = product.Color;
                originalProduct.SafetyStockLevel = product.SafetyStockLevel;
                originalProduct.ReorderPoint = product.ReorderPoint;
                originalProduct.StandardCost = product.StandardCost;
                originalProduct.ListPrice = product.ListPrice;
                originalProduct.Size = product.Size;
                originalProduct.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                originalProduct.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                originalProduct.Weight = product.Weight;
                originalProduct.DaysToManufacture = product.DaysToManufacture;
                originalProduct.ProductLine = product.ProductLine;
                originalProduct.Class = product.Class;
                originalProduct.Style = product.Style;
                originalProduct.ProductSubcategoryID = product.ProductSubcategoryID;
                originalProduct.ProductModelID = product.ProductModelID;
                originalProduct.SellStartDate = product.SellStartDate;
                originalProduct.SellEndDate = product.SellEndDate;
                originalProduct.DiscontinuedDate = product.DiscontinuedDate;
                originalProduct.ModifiedDate = DateTime.Today;
                dataContext.SubmitChanges();
            }
        }

        //Distincts



        public static List<string> SelectDistinctColors()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Color).Select(g => g.First()).ToList();
                foreach(Product p in products)
                {
                    answer.Add(p.Color);
                }

            }
            return answer;
        }




        public static List<string> SelectDistinctSizes()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Size).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.Size);
                }

            }
            return answer;
        }




        public static List<string> SelectDistinctSizesUnits()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.SizeUnitMeasureCode).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.SizeUnitMeasureCode);
                }

            }
            return answer;
        }




        public static List<string> SelectDistinctWeightUnits()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.WeightUnitMeasureCode).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.WeightUnitMeasureCode);
                }

            }
            return answer;
        }




        public static List<string> SelectDistinctProductLines()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.ProductLine).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.ProductLine);
                }

            }
            return answer;
        }




        public static List<string> SelectDistinctClasses()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Class).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.Class);
                }

            }
            return answer;
        }




        public static List<string> SelectDistinctStyles()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                List<Product> products = dataContext.Products.GroupBy(x => x.Style).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.Style);
                }

            }
            return answer;
        }



        public static int SelectSubcategoryId(string subcategoryName)
        {
            if (subcategoryName == null)
                return 0;
            int answer = 0;
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                answer = (from product in products
                          where product.ProductSubcategory.Name == subcategoryName
                          select product.ProductSubcategory.ProductSubcategoryID).First();
                return answer;
            }
        }


        public static int SelectModelId(string modelName)
        {
            if (modelName == null)
                return 0;
            int answer = 0;
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                answer = (from product in products
                          where product.ProductModel.Name == modelName
                          select product.ProductModel.ProductModelID).First();

            }
            return answer;
        }




        public static string SelectSubcategoryName(int? subcategoryName)
        {
            if (subcategoryName == 0)
                return  "";
            string answer = "";
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                answer = (from product in products
                          where product.ProductSubcategoryID == subcategoryName
                          select product.ProductSubcategory.Name).First();
                return answer;
            }
        }


        public static string SelectModelName(int? modelName)
        {
            if (modelName == 0)
                return "";
            string answer = "";
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                answer = (from product in products
                          where product.ProductModelID == modelName
                          select product.ProductModel.Name).First();

            }
            return answer;
        }

        public static List<string> SelectDistinctSubcategories()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                answer = (from product in products
                          where product.ProductSubcategory != null
                          select product.ProductSubcategory.Name).Distinct().ToList();
                return answer;
            }
        }




        public static List<string> SelectDistinctModels()
        {
            List<string> answer = new List<string>();
            using (DataClasses1DataContext dataContext = new DataClasses1DataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                answer = (from product in products
                          where product.ProductModel != null
                          select product.ProductModel.Name).Distinct().ToList();

            }
            return answer;
        }
    }
}
