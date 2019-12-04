using System;
using System.Collections.Generic;
using LingDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Linq;

namespace LinqTests
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void ListProducts()
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            List<Product> products = dataContext.GetTable<Product>().ToList();
            List<Product> answer = products.GetProductsWithoutCategory();
            Assert.AreEqual(answer[0].ProductSubcategory, null);
            Assert.AreEqual(answer.Count, 209);
        }

        [TestMethod]
        public void ListProductVendor()
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            List<Product> products = dataContext.GetTable<Product>().ToList();
            List<ProductVendor> vendors = dataContext.GetTable<ProductVendor>().ToList();
            string answer = products.GetVendorProductList(vendors);
        }

        [TestMethod]
        public void ProductsPagination()
        {
            DataClasses1DataContext dataContext = new DataClasses1DataContext();
            List<Product> products = dataContext.GetTable<Product>().ToList();
            List<Product> answer = products.GetProductsAsPage(1, 10);
            Assert.AreEqual(answer.Count, 10);
            answer = products.GetProductsAsPage(3, 10);
            Assert.AreEqual(answer.Count, 10);
            int count = products.Count;
            answer = products.GetProductsAsPage(count / 10 + 1, 10);
            Assert.AreEqual(answer.Count, count % 10);
        }
    }
}