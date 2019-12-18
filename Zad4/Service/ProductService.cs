using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        public event VoidHandler CollectionChanged;

        public void Delete(int productID)
        {
            //LinqTools.RemoveProduct(productID);
            Product product = LinqTools.GetProductById(productID);
            product.DiscontinuedDate = DateTime.Today;
            LinqTools.UpdateProduct(product);
            CollectionChanged?.Invoke();
        }

        public void Insert(Product product)
        {
            LinqTools.AddNewProduct(product);
            CollectionChanged?.Invoke();
        }

        public void Update(Product product)
        {
            LinqTools.UpdateProduct(product);
            CollectionChanged?.Invoke();
        }

        public void Upsert(Product product)
        {
            if (LinqTools.GetProductById(product.ProductID) != null)
                LinqTools.UpdateProduct(product);
            else
                LinqTools.AddNewProduct(product);

            CollectionChanged?.Invoke();
        }

        public List<Product> GetAllProducts()
        {
            return (List<Product>) LinqTools.GetAllProducts().Where(product => !product.DiscontinuedDate.HasValue).ToList();
        }

        public List<Product> GetDeletedProducts()
        {
            return (List<Product>)LinqTools.GetAllProducts().Where(product => product.DiscontinuedDate.HasValue).ToList();
        }

        public List<string> GetProductClasses()
        {
            return LinqTools.SelectDistinctClasses();
        }

        public List<string> GetProductColors()
        {
            return LinqTools.SelectDistinctColors();
        }

        public List<string> GetProductLines()
        {
            return LinqTools.SelectDistinctProductLines();
        }

        public List<string> GetProductModels()
        {
            return LinqTools.SelectDistinctModels();
        }

        public List<string> GetProductSizes()
        {
            return LinqTools.SelectDistinctSizes();
        }

        public List<string> GetProductStyles()
        {
            return LinqTools.SelectDistinctStyles();
        }

        public List<string> GetProductSubcategories()
        {
            return LinqTools.SelectDistinctSubcategories();
        }

        public List<string> GetWeightUnits()
        {
            return LinqTools.SelectDistinctWeightUnits();
        }

        public List<string> GetSizeUnits()
        {
            return LinqTools.SelectDistinctSizesUnits();
        }

        public int GetSubcategoryIDByName(string name)
        {
            return LinqTools.SelectSubcategoryId(name);
        }

        public int GetModelIDByName(string name)
        {
            return LinqTools.SelectModelId(name);
        }

        public string GetSubcategoryNameByID(int id)
        {
            return LinqTools.SelectSubcategoryName(id);
        }

        public string GetModelNameByID(int id)
        {
            return LinqTools.SelectModelName(id);
        }
    }
}
