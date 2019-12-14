using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayaer.Commands;

namespace ViewModelLayaer
{
    public class AddingControllcs
    {
        //Static Data
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string StandardCost { get; set; }
        public string SafetyStockLevel { get; set; }

        //Actions
        public Action<string> MessageBoxShowDelegate { get; set; }
        public Action CloseWindow { get; set; }

        //CommandsData
        public string ActionText { get; set; }

        //Commands
        public OwnCommand DisplayMessage { get; set; }
        public OwnCommand DisplayAddWindow { get; set; }
        public OwnCommand AddItemToDataBase { get; set; }


        public AddingControllcs()
        {
            this.DisplayMessage = new OwnCommand(ShowPopupWindow);
            this.AddItemToDataBase = new OwnCommand(AddItem);
        }
        

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(ProductName + ProductNumber + Color + StandardCost + SafetyStockLevel);
        }

        private void AddItem()
        {
            Product product = new Product();
            product.Name = this.ProductName;
            product.ProductNumber = this.ProductNumber;
            product.rowguid = Guid.NewGuid();
            product.Color = this.Color;
            product.StandardCost = Decimal.Parse(this.StandardCost);
            product.SafetyStockLevel = Int16.Parse(this.SafetyStockLevel);
            product.SellStartDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            product.SellEndDate = DateTime.Now;
            product.ReorderPoint = 1;
            product.Size = null;
            LinqTools.AddNeProduct(product);
            CloseWindow();
        }
    }
}
