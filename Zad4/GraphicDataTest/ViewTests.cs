using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModelLayer;
using Service;
using System.Windows;
using ViewLayer.DI;

namespace GraphicDataTest
{
    [TestClass]
    public class ViewModelTests
    {

        //text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
        [TestMethod]
        public void ProductDetailsViewModelCtorTest()
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel(new ProductService());
            Assert.IsNotNull(productDetailsViewModel.DisplayMessage);
            Assert.IsNotNull(productDetailsViewModel.AddItemToDataBase);
            Assert.IsNotNull(productDetailsViewModel.Colors);
            Assert.IsNotNull(productDetailsViewModel.Sizes);
            Assert.IsNotNull(productDetailsViewModel.SizesUnits);
            Assert.IsNotNull(productDetailsViewModel.WeightUnits);
            Assert.IsNotNull(productDetailsViewModel.Flags);
            Assert.IsNotNull(productDetailsViewModel.ProductLines);
            Assert.IsNotNull(productDetailsViewModel.Classes);
            Assert.IsNotNull(productDetailsViewModel.Styles);
            Assert.IsNotNull(productDetailsViewModel.ProductSubCategories);
            Assert.IsNotNull(productDetailsViewModel.ModelIds);
        }


        [TestMethod]
        public void ProductListViewModelCtorTest()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(new ProductService());
            Assert.IsNotNull(productListViewModel.ProductService);
            Assert.IsNotNull(productListViewModel.Products);
            Assert.IsNotNull(productListViewModel.ActionText);
            Assert.IsNotNull(productListViewModel.DisplayAddWindow);
            Assert.IsNotNull(productListViewModel.RemoveEntity);
            Assert.IsNotNull(productListViewModel.DisplayDetails);
        }

        [TestMethod]
        public void ProductListViewModelCommandsTest()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(new ProductService());
            productListViewModel.MessageBoxShowDelegate = text => MessageBox.Show("Button interaction");
            productListViewModel.WindowResolver = new ProductDetailsResolver();
            Assert.IsNotNull(productListViewModel.MessageBoxShowDelegate);
            Assert.IsNotNull(productListViewModel.WindowResolver);
            productListViewModel.ShowAddWindowTest();
        }


        public void ProductDetailsViewModelCommandsTest()
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel(new ProductService());
            productDetailsViewModel.DisplayErrorMessage = text => MessageBox.Show("Button interaction");
            productDetailsViewModel.CloseWindow = () => { };
            Assert.IsNotNull(productDetailsViewModel.DisplayErrorMessage);
            Assert.IsNotNull(productDetailsViewModel.CloseWindow);
        }
    }
}
