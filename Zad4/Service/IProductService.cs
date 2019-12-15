using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        event VoidHandler CollectionChanged;

        void Insert(Product product);
        void Upsert(Product product);
        void Update(Product product);
        void Delete(int productID);

        List<Product> GetAllProducts();

        List<string> GetProductColors();
        List<string> GetProductSizes();
        List<string> GetWeightUnits();
        List<string> GetProductLines();
        List<string> GetProductClasses();
        List<string> GetProductStyles();
        List<string> GetProductSubcategories();
        List<string> GetProductModels();
        List<string> GetSizeUnits();
    }

    public delegate void VoidHandler();
}
