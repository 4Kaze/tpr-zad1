using System;
using System.Collections.Generic;
using LingDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqTests
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void NameContainsGet()
        {
            List<Product> products = LinqTools.GetProductsByName("Ball");
            Assert.AreEqual(products.Count, 3);
            foreach (Product product in products)
                Assert.IsTrue(product.Name.Contains("Ball"));
        }


        [TestMethod]
        public void ProductByVendor()
        {
            List<Product> products = LinqTools.GetProductsByVendorName("Litware, Inc.");
            Assert.AreEqual(products.Count, 1);
        }


        [TestMethod]
        public void ProductNameByVendor()
        {
            List<string> productsName = LinqTools.GetProductNamesByVendorName("Litware, Inc.");
            Assert.AreEqual(productsName.Count, 1);
        }


        [TestMethod]
        public void VendorNameByProduct()
        {
            string productsName = LinqTools.GetProductVendorByProductName("Adjustable Race");
            Assert.AreEqual(productsName, "Litware, Inc.");
        }

        [TestMethod]
        public void ProductsWithNReviews()
        {
            List<Product> products = LinqTools.GetProductsWithNRecentReviews(1);
            Assert.AreEqual(products.Count, 2);
            Assert.IsNotNull(products.Find(product => product.ProductID == 709));
            Assert.IsNotNull(products.Find(product => product.ProductID == 798));
        }

        [TestMethod]
        public void ProductsWithNReviews2()
        {
            List<Product> products = LinqTools.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(products.Count, 1);
            Assert.IsNotNull(products.Find(product => product.ProductID == 937));
        }


        [TestMethod]
        public void NProductsFromCategory()
        {
            List<Product> products = LinqTools.GetNProductsFromCategory("Bikes", 5);
            Assert.AreEqual(products.Count, 5);
            foreach (Product product in products)
                Assert.AreEqual(product.ProductSubcategory.ProductCategory.Name, "Bikes");
        }


        [TestMethod]
        public void NProductsByReviews()
        {
            List<Product> products = LinqTools.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(products.Count, 3);
            Assert.AreEqual(products[0].Name, "HL Mountain Pedal");
            Assert.AreEqual(products[1].Name, "Road-550-W Yellow, 40");
            Assert.AreEqual(products[2].Name, "Mountain Bike Socks, M");
        }



        [TestMethod]
        public void TotalStandardCostByCategory()
        {
            ProductCategory product = new ProductCategory();
            product.Name = "Bikes";
            int total = LinqTools.GetTotalStandardCostByCategory(product);
            Assert.AreEqual(total, 92092);
        }
    }
}