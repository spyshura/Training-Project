using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories(bool includeProducts = false);
        Category GetCategoryById(int categoryId, bool includeProducts = false);
        void SaveCategory(Category arhieve);
        void DeleteCategory(Category arhieve);
    }
}
