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
            List<Product> answer = products.GetWithoutCategoryProducts();
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
    }
}