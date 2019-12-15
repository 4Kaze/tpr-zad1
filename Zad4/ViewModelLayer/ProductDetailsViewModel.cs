using LogicLayer.Interfaces;
using LogicLayer.Service;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Commands;

namespace ViewModelLayer
{
    public class ProductDetailsViewModel : IViewModel
    {
        //Static Data
        private int _productID { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ModelId { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        
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
        public Action CloseWindow { get; set; }

        //CommandsData
        public string ActionText { get; set; }

        //Commands
        public OwnCommand DisplayMessage { get; set; }
        public OwnCommand DisplayAddWindow { get; set; }
        public OwnCommand AddItemToDataBase { get; set; }

        public IProductService ProductService { get; set; }

        public ProductDetailsViewModel()
        {
            this.ProductService = ServiceProvider.ProductService;
            this.DisplayMessage = new OwnCommand(ShowPopupWindow);
            this.AddItemToDataBase = new OwnCommand(SaveProduct);
            this.Colors = ProductService.GetProductColors();
            this.Sizes = ProductService.GetProductSizes();
            this.SizesUnits = ProductService.GetSizeUnits();
            this.WeightUnits = ProductService.GetWeightUnits();
            this.Flags = new List<bool> { true, false };
            this.ProductLines = ProductService.GetProductLines();
            this.Classes = ProductService.GetProductClasses();
            this.Styles = ProductService.GetProductStyles();
            this.ProductSubCategories = ProductService.GetProductSubcategories();
            this.ModelIds = ProductService.GetProductModels();
        }

        public ProductDetailsViewModel(Product product) : this()
        {
            ProductName = product.Name;
            ProductNumber = product.ProductNumber;
            MakeFlag = product.MakeFlag;
            FinishedGoodsFlag = product.FinishedGoodsFlag;
            Color = product.Color;
            SafetyStockLevel = product.SafetyStockLevel;
            ReorderPoint = product.ReorderPoint;
            StandardCost = product.StandardCost;
            ListPrice = product.ListPrice;
            Size = product.Size;
            SizeUnitMeasureCode = product.SizeUnitMeasureCode;
            WeightUnitMeasureCode = product.WeightUnitMeasureCode;
            Weight = product.Weight;
            DaysToManufacture = product.DaysToManufacture;
            ProductLine = product.ProductLine;
            Class = product.Class;
            Style = product.Style;
            ProductSubcategoryID = product.ProductSubcategoryID;
            ModelId = product.ProductModelID;
            _productID = product.ProductID;
            this.SellStartDate = product.SellStartDate;
            this.SellEndDate = product.SellEndDate;
            this.DiscontinuedDate = product.DiscontinuedDate;
        }
        

        private void ShowPopupWindow()
        {
            
        }

        private void SaveProduct()
        {
            Product product = GetProduct();
            ProductService.Upsert(product);
            CloseWindow();
        }

        private Product GetProduct()
        {
            Product product = new Product();
            product.Name = this.ProductName;
            product.ProductNumber = this.ProductNumber;
            product.MakeFlag = this.MakeFlag;
            product.FinishedGoodsFlag = this.FinishedGoodsFlag;
            product.Color = this.Color;
            product.SafetyStockLevel = this.SafetyStockLevel;
            product.ReorderPoint = this.ReorderPoint;
            product.StandardCost = this.StandardCost;
            product.ListPrice = this.ListPrice;
            product.Size = this.Size;
            product.SizeUnitMeasureCode = this.SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = this.WeightUnitMeasureCode;
            product.Weight = this.Weight;
            product.DaysToManufacture = this.DaysToManufacture;
            product.ProductLine = this.ProductLine;
            product.Class = this.Class;
            product.Style = this.Style;
            product.ProductSubcategoryID = this.ProductSubcategoryID;
            product.ProductModelID = this.ModelId;
            product.SellStartDate = DateTime.Today;//this.SellStartDate;
            product.SellEndDate = null;// this.SellEndDate;
            product.DiscontinuedDate = null;// this.DiscontinuedDate;
            product.ProductID = _productID;
            return product;
        }
    }
}
