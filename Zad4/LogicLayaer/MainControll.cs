using Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayaer.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModelLayaer
{
    public class MainControll : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //Static Data
        public ObservableCollection<Product> products;


        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged("products");
            }
        }
        public Product Product { get; set; }

        //Actions
        public Action<string> MessageBoxShowDelegate { get; set; }

        //CommandsData
        public string ActionText { get; set; }
        public Window Window { get; set; }

        //Commands
        public OwnCommand DisplayMessage { get; set; }
        public OwnCommand DisplayAddWindow { get; set; }
        public OwnCommand RemoveEntity { get; set; }


        public MainControll()   
        {
            this.Products = new ObservableCollection<Product>(LinqTools.GetAllProducts());
            this.ActionText = "Message.";
            this.DisplayMessage = new OwnCommand(ShowPopupWindow);
            this.DisplayAddWindow = new OwnCommand(ShowAddWindow);
            this.RemoveEntity = new OwnCommand(RemoveProduct);
        }

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(Product.Name + " " + Product.ProductID);
        }

        private void ShowAddWindow()
        {
            Window.Show();
        }

        private void RemoveProduct()
        {
            int flag = LinqTools.RemoveProduct(Product.ProductID);
        }
    }
}
