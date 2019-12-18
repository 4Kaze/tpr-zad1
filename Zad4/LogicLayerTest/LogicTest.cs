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
    }
}
