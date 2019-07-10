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
    public class EFCategoryRepository : ICategoryRepository
    {
        private EFDBContext _context;
        public EFCategoryRepository(EFDBContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Category> GetAllCategories(bool includeProducts = false)
        {
            if (includeProducts)
                return _context.Set<Category>().Include(x => x.Product
                ).AsNoTracking().ToList();
            else
                return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId, bool includeProducts = false)
        {
            if (includeProducts)
                return _context.Set<Category>().Include(x => x.Product).AsNoTracking().FirstOrDefault(x => x.Id == categoryId);
            else
                return _context.Categories.FirstOrDefault(x => x.Id == categoryId);
        }

        public void SaveCategory(Category arhieve)
        {
            if (arhieve.Id == 0)
                _context.Categories.Add(arhieve);
            else
                _context.Entry(arhieve).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteCategory(Category arhieve)
        {
            _context.Categories.Remove(arhieve);
            _context.SaveChanges();
        }
    }
}
