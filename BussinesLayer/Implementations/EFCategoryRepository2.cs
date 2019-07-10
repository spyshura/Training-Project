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
    public class EFCategoryRepository3 : ICategoryRepository
    {
        public void DeleteCategory(Category arhieve)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories(bool includeProducts = false)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int directoryId, bool includeProducts = false)
        {
            throw new NotImplementedException();
        }

        public void SaveCategory(Category arhieve)
        {
            throw new NotImplementedException();
        }
    }
}
