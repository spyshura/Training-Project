using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool includeCategories = false);
        Product GetProductById(int productId, bool includeCategories = false);
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
    }
}
