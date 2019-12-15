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
            LinqTools.RemoveProduct(productID);
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
            return (List<Product>) LinqTools.GetAllProducts();
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
    }
}
