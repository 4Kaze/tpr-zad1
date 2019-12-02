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
            List<Product> products = LinqTools.GetProductsByName("ball");
            Assert.AreEqual(products.Count, 3);
            products = LinqTools.GetProductsByName("Ball");
            Assert.AreEqual(products.Count, 3);
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
            List<String> productsName = LinqTools.GetProductNamesByVendorName("Litware, Inc.");
            Assert.AreEqual(productsName[0], "Adjustable Race");
        }


        [TestMethod]
        public void VendorNameByProduct()
        {
            String productsName = LinqTools.GetProductVendorByProductName("Adjustable Race");
            Assert.AreEqual(productsName, "Litware, Inc.");
        }
        [TestMethod]
        public void ProductsWithNReviews()
        {
            List<Product> products = LinqTools.GetProductsWithNRecentReviews(4);
            Assert.AreEqual(products.Count, 4);
        }


        [TestMethod]
        public void NProductsByReviews()
        {
            List<Product> products = LinqTools.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(products.Count, 3);
            Assert.AreEqual(products[0].Name, "HL Mountain Pedal");
            Assert.AreEqual(products[1].Name, "Road-550-W Yellow, 40");
            Assert.AreEqual(products[2].Name, "HL Mountain Pedal");
        }


        [TestMethod]
        public void NProductsFromCategory()
        {
            List<Product> products = LinqTools.GetNProductsFromCategory("Bikes", 5);
            Assert.AreEqual(products.Count, 5);
            Assert.AreEqual(products[0].Name, "Mountain-100 Silver, 38");
            Assert.AreEqual(products[1].Name, "Mountain-100 Silver, 42");
            Assert.AreEqual(products[2].Name, "Mountain-100 Silver, 44");
            Assert.AreEqual(products[3].Name, "Mountain-100 Silver, 48");
            Assert.AreEqual(products[4].Name, "Mountain-100 Black, 38");
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