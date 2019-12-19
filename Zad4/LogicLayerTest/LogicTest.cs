using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            Assert.AreEqual(resolver.Window.Showed, true);
            Assert.AreEqual(((ProductDetailsViewModel)resolver.Window.ViewModel).ProductName, "name");
            Assert.AreEqual(((ProductDetailsViewModel)resolver.Window.ViewModel).ReorderPoint, 12);
            
        }

        [TestMethod]
        public void ShowAddWindowTest()
        {
            ProductListViewModel viewModel = new ProductListViewModel(new TestService());
            TestWindowResolver resolver = new TestWindowResolver();
            viewModel.WindowResolver = resolver;
            viewModel.DisplayAddWindow.Execute(null);
            Assert.AreEqual(resolver.Window.Showed, true);
            Assert.IsNotNull(resolver.Window.ViewModel);
            Assert.IsNotNull(((ProductDetailsViewModel)resolver.Window.ViewModel).Sizes);
        }

        [TestMethod]
        public void DateValidationTest()
        {
            TestService service = new TestService();
            ProductDetailsViewModel viewModel = new ProductDetailsViewModel(service);
            viewModel.SellStartDate = DateTime.Today.AddDays(1);
            viewModel.SellEndDate = DateTime.Today;
            viewModel.DisplayErrorMessage = (s) => { };
            viewModel.CloseWindow = () => { };
            viewModel.AddItemToDataBase.Execute(null);
            Assert.IsNull(service.AddedProduct);
            viewModel.SellEndDate = viewModel.SellEndDate?.AddDays(3);
            viewModel.AddItemToDataBase.Execute(null);
            Assert.IsNotNull(service.AddedProduct);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            TestService service = new TestService();
            ProductListViewModel viewModel = new ProductListViewModel(service);
            Product product = new Product();
            product.ProductID = 11;
            viewModel.Product = product;
            viewModel.RemoveEntity.Execute(null);
            Assert.AreEqual(service.DeletedProductID, product.ProductID);
        }

        [TestMethod]
        public void ShowMessageTest()
        {
            TestService service = new TestService();
            ProductDetailsViewModel viewModel = new ProductDetailsViewModel(service);
            Boolean invoked = false;
            viewModel.DisplayErrorMessage = (a) => invoked = true;
            viewModel.DisplayMessage.Execute(null);
            Assert.IsTrue(invoked);
        }
        [TestMethod]
        public void ProductServiceUpdateTest()
        {
            IProductService productService = new ProductService();

            List<Product> products = productService.GetAllProducts();
            Product product = products[0];
            Assert.AreEqual(product.Name, "Adjustabl");

            product.Name = "testowy";
            Assert.AreEqual(product.Name, "testowy");

            productService.Update(product);
        }




        [TestMethod]
        public void ProductServiceTestGets()
        {
               IProductService productService = new ProductService();

            //Classes
            Assert.AreEqual(productService.GetProductClasses().Count, 4);

            //Colors
            Assert.AreEqual(productService.GetProductColors().Count, 10);

            //Lines
            Assert.AreEqual(productService.GetProductLines().Count, 5);

            //Models
            Assert.AreEqual(productService.GetProductModels().Count, 119);

            //Sizes
            Assert.AreEqual(productService.GetProductSizes().Count, 19);

            //Subcategories
            Assert.AreEqual(productService.GetProductStyles().Count, 4);
            
            //Subcategories
            Assert.AreEqual(productService.GetProductSubcategories().Count, 37);

            //WeigthUnits
            Assert.AreEqual(productService.GetWeightUnits().Count, 3);

            //SizeUnits
            Assert.AreEqual(productService.GetSizeUnits().Count, 2);

            //ClassID
            Assert.AreEqual(productService.GetSubcategoryIDByName("Mountain Bikes"), 1);

            //ModelID
            Assert.AreEqual(productService.GetModelIDByName("Classic Vest"), 1);

            //ClassName
            Assert.AreEqual(productService.GetSubcategoryNameByID(1), "Mountain Bikes");

            //ModelName
            Assert.AreEqual(productService.GetModelNameByID(1), "Classic Vest");
        }
    }
}
