using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTest
{

    class TestService : IProductService
    {
        public event VoidHandler CollectionChanged;
        public Product AddedProduct { get; set; }
        public int DeletedProductID { get; set; }

        public void Delete(int productID)
        {
            DeletedProductID = productID;
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>();
        }

        public int GetModelIDByName(string name)
        {
            return 0;
        }

        public string GetModelNameByID(int id)
        {
            return "";
        }

        public List<string> GetProductClasses()
        {
            return new List<string>();
        }

        public List<string> GetProductColors()
        {
            return new List<string>();
        }

        public List<string> GetProductLines()
        {
            return new List<string>();
        }

        public List<string> GetProductModels()
        {
            return new List<string>();
        }

        public List<string> GetProductSizes()
        {
            return new List<string>();
        }

        public List<string> GetProductStyles()
        {
            return new List<string>();
        }

        public List<string> GetProductSubcategories()
        {
            return new List<string>();
        }

        public List<string> GetSizeUnits()
        {
            return new List<string>();
        }

        public int GetSubcategoryIDByName(string name)
        {
            return 0;
        }

        public string GetSubcategoryNameByID(int id)
        {
            return "";
        }

        public List<string> GetWeightUnits()
        {
            return new List<string>();
        }

        public void Insert(Product product)
        {
            
        }

        public void Update(Product product)
        {
            
        }

        public void Upsert(Product product)
        {
            AddedProduct = product;
        }
    }
}
