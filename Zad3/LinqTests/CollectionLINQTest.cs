using System;
using System.Collections.Generic;
using LingDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqTests
{
    [TestClass]
    public class CollectionLINQTest
    {
        

        [TestMethod]
        public void NameContainsGet()
        {
            using(DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dbContext);
                List<MyProduct> products = dataContext.GetProductsByName("ball");
                Assert.AreEqual(products.Count, 3);
                products = dataContext.GetProductsByName("Ball");
                Assert.AreEqual(products.Count, 3);
            }
        }

        [TestMethod]
        public void NProductsFromCategory()
        {
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dbContext);
                List<MyProduct> products = dataContext.GetNProductsFromCategory("Bikes", 5);
                Assert.AreEqual(products.Count, 5);
                foreach (Product product in products)
                    Assert.AreEqual(product.ProductSubcategory.ProductCategory.Name, "Bikes");
            }
        }

        [TestMethod]
            public void ProductsWithNReviews()
        {
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dbContext);
                List<MyProduct> products = dataContext.GetProductsWithNRecentReviews(1);
                Assert.AreEqual(products.Count, 2);
                Assert.IsNotNull(products.Find(product => product.ProductID == 709));
                Assert.IsNotNull(products.Find(product => product.ProductID == 798));
            }
        }

        [TestMethod]
        public void ProductsWithNReviews2()
        {
            using (DataClasses1DataContext dbContext = new DataClasses1DataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(dbContext);
                List<MyProduct> products = dataContext.GetProductsWithNRecentReviews(2);
                Assert.AreEqual(products.Count, 1);
                Assert.IsNotNull(products.Find(product => product.ProductID == 937));
            }
        }
    }
}
