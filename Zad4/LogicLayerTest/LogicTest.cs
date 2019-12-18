using System;
using System.Collections.Generic;
using LogicLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Service;
using ViewModelLayer;

namespace LogicLayerTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void TestCRUD()
        {
        //    IProductService productService = new ProductService();
        //    List<Product> products = productService.GetAllProducts();
        //    int length = products.Count;

        //    Product product = new Product();
        //    product.rowguid = new Guid();
        //    product.Name = "Testowy";
        //    product.ProductNumber = "TX-1111";
        //    product.MakeFlag = true;
        //    product.FinishedGoodsFlag = true;
        //    product.Color = null;
        //    product.SafetyStockLevel = 100;
        //    product.ReorderPoint = 100;
        //    product.StandardCost = 100;
        //    product.ListPrice = 100;
        //    product.Size = "S";
        //    product.SizeUnitMeasureCode = "CM";
        //    product.WeightUnitMeasureCode = "LB";
        //    product.Weight = 100;
        //    product.DaysToManufacture = 100;
        //    product.ProductLine = "M";
        //    product.Class = "H";
        //    product.Style = "M";
        //    product.ProductSubcategoryID = 1;
        //    product.ProductModelID = 1;
        //    product.SellStartDate = DateTime.Today;
        //    product.SellEndDate = DateTime.Today.AddDays(1);
        //    product.ModifiedDate = DateTime.Today;

        //    productService.Upsert(product);
        //    products = productService.GetAllProducts();
        //    Assert.AreEqual(length + 1, products.Count);

            //productService.Delete(product.ProductID);
            //Assert.AreEqual(length, products.Count);
        }

        [TestMethod]
        public void ShowWindowDetailsTest()
        {
            ProductListViewModel viewModel = new ProductListViewModel(new TestService());
            Product product = new Product();
            product.Name = "name";
            product.ReorderPoint = 12;
            viewModel.Product = product;
            TestWindowResolver resolver = new TestWindowResolver();
            viewModel.WindowResolver = resolver;
            viewModel.DisplayDetails.Execute(null);
            Assert.AreEqual(((ProductDetailsViewModel)resolver.Window.ViewModel).ProductName, "name");
            Assert.AreEqual(((ProductDetailsViewModel)resolver.Window.ViewModel).ReorderPoint, 12);
            Assert.AreEqual(resolver.Window.Showed, true);
        }
    }
}
