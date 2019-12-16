﻿using Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LogicLayer.Interfaces;
using Service;
using LogicLayer.Service;

namespace ViewModelLayer
{
    public class ProductListViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //Static Data
        public List<Product> products;


        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged("Products");
            }
        }
        public Product Product { get; set; }

        //Actions
        public Action<string> MessageBoxShowDelegate { get; set; }

        //CommandsData
        public string ActionText { get; set; }
        public IWindowResolver WindowResolver { get; set; }

        //Commands
        public OwnCommand DisplayMessage { get; set; }
        public OwnCommand DisplayAddWindow { get; set; }
        public OwnCommand RemoveEntity { get; set; }
        public OwnCommand DisplayDetails { get; set; }

        public IProductService ProductService { get; set; }
        public Action CloseWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ProductListViewModel()   
        {
            this.ProductService = ServiceProvider.ProductService;
            this.Products = ProductService.GetAllProducts();
            this.ActionText = "Message.";
            this.DisplayMessage = new OwnCommand(ShowPopupWindow);
            this.DisplayAddWindow = new OwnCommand(ShowAddWindow);
            this.RemoveEntity = new OwnCommand(RemoveProduct);
            this.DisplayDetails = new OwnCommand(ShowDetails);

            this.ProductService.CollectionChanged += OnProductsChanged;
        }

        private void OnProductsChanged()
        {
            this.Products = ProductService.GetAllProducts();
        }

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(Product.Name + " " + Product.ProductID);
        }

        private void ShowAddWindow()
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel();
            IOperationWindow window = WindowResolver.GetWindow();
            window.BindViewModel(productDetailsViewModel);
            window.Show();
        }

        private void RemoveProduct()
        {
            int flag = LinqTools.RemoveProduct(Product.ProductID);
        }

        private void ShowDetails()
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel(Product);
            IOperationWindow window = WindowResolver.GetWindow();
            window.BindViewModel(productDetailsViewModel);
            window.Show();
        }
    }
}