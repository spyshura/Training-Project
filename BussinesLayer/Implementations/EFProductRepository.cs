using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLayer.Implementations
{
    public class EFProductRepository : IProductRepository
    {
        private EFDBContext _context;
        public EFProductRepository(EFDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts(bool includeCategories = false)
        {
            if (includeCategories)
                return _context.Set<Product>().Include(x => x.Category).AsNoTracking().ToList();
            else
                return _context.Products.ToList();
        }

        public Product GetProductById(int productlId, bool includeCategories = false)
        {
            if (includeCategories)
                return _context.Set<Product>().Include(x => x.Category).AsNoTracking().FirstOrDefault(x => x.Id == productlId);
            else
                return _context.Products.FirstOrDefault(x => x.Id == productlId);
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
                _context.Products.Add(product);
            else
                _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
