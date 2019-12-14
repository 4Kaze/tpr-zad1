using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public string SafetyStockLevel { get; set; }
        public string ReorderPoint { get; set; }
        public string StandardCost { get; set; }
        public string ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public string Weight { get; set; }
        public string DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductSubCategorie { get; set; }
        public string ModelId { get; set; }
        //public string ProductSubCategorie { get; set; }
        //public string ProductSubCategorie { get; set; }
        //public string ProductSubCategorie { get; set; }

        //Display Data
        public List<string> Colors { get; set; }
        public List<bool> Flags { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> SizesUnits { get; set; }
        public List<string> WeightUnits { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubCategories { get; set; }
        public List<string> ModelIds { get; set; }

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
            this.Colors = LinqTools.SelectDistinctColors();
            this.Sizes = LinqTools.SelectDistinctSizes();
            this.SizesUnits = LinqTools.SelectDistinctSizesUnits();
            this.WeightUnits = LinqTools.SelectDistinctWeightUnits();
            this.Flags = new List<bool> { true, false };
            this.ProductLines = LinqTools.SelectDistinctProductLines();
            this.Classes = LinqTools.SelectDistinctClasses();
            this.Styles = LinqTools.SelectDistinctStyles();
            this.ProductSubCategories = LinqTools.SelectDistinctSubcategories();
            this.ModelIds = LinqTools.SelectDistinctModels();
        }
        

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(MakeFlag + " " + FinishedGoodsFlag);
        }

        private void AddItem()
        {
            Product product = new Product();
            product.Name = this.ProductName;
            product.ProductNumber = this.ProductNumber;
            product.MakeFlag = this.MakeFlag;
            product.FinishedGoodsFlag = this.FinishedGoodsFlag;
            product.Color = this.Color;
            product.SafetyStockLevel = Int16.Parse(this.SafetyStockLevel); ;
            product.ReorderPoint = Int16.Parse(this.ReorderPoint);
            product.StandardCost = Decimal.Parse(this.StandardCost);
            product.ListPrice = Decimal.Parse(this.ListPrice);
            product.Size = this.Size;
            product.SizeUnitMeasureCode = this.SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = this.WeightUnitMeasureCode;
            product.Weight = Decimal.Parse(this.Weight);
            product.DaysToManufacture = Int32.Parse(this.DaysToManufacture);
            product.ProductLine = this.ProductLine;
            product.Class = this.Class;
            product.Style = this.Style;
            product.ProductSubcategoryID = Int32.Parse(this.ProductSubCategorie);
            product.ProductModelID = Int32.Parse(this.ModelId);
            product.SellStartDate = DateTime.Today;
            product.SellEndDate = DateTime.Today;
            product.DiscontinuedDate = DateTime.Today;
            product.ModifiedDate = DateTime.Today;
            product.rowguid = Guid.NewGuid();
            LinqTools.AddNeProduct(product);
            this.ProductName = "";
            this.ProductNumber = "";
            this.StandardCost = "";
            this.SafetyStockLevel = "";
            CloseWindow();
        //            public string ProductName { get; set; }
        //public string ProductNumber { get; set; }
        //public bool MakeFlag { get; set; }
        //public bool FinishedGoodsFlag { get; set; }
        //public string Color { get; set; }
        //public string SafetyStockLevel { get; set; }
        //public string ReorderPoint { get; set; }
        //public string StandardCost { get; set; }
        //public string ListPrice { get; set; }
        //public string Size { get; set; }
        //public string SizeUnitMeasureCode { get; set; }
        //public string WeightUnitMeasureCode { get; set; }
        //public string Weight { get; set; }
        //public string DaysToManufacture { get; set; }
        //public string ProductLine { get; set; }
        //public string Class { get; set; }
        //public string Style { get; set; }
        //public string ProductSubCategorie { get; set; }
        //public string ModelId { get; set; }

    }
    }
}
