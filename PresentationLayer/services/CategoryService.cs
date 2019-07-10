using BussinesLayer;
using DataLayer.Entityes;
using PresentationLayer.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.services
{
    public class CategoryService
    {
        public DataManager _dataManager;
        private ProductService _productService;
        public CategoryService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _productService = new ProductService(dataManager);
        }
        public List<CategoryViewModel> GetCategoryList()
        {
            var dir = _dataManager.Category.GetAllCategories();
            List<CategoryViewModel> _modelList = new List<CategoryViewModel>();
            foreach(var d in dir)
            {
                _modelList.Add(CategoryDBToViewModelById(d.Id));
            }
            return _modelList;
        }

        public CategoryViewModel CategoryDBToViewModelById(int categoryId)
        {
            var _category = _dataManager.Category.GetCategoryById(categoryId, true);
            List<ProductViewModel> _productsViewModelList = new List<ProductViewModel>();
                foreach (var item in _category.Product)
                {
                    _productsViewModelList.Add(_productService.ProductDBModelToView(item.Id));
                }
            return new CategoryViewModel() { Category = _category, Products = _productsViewModelList };
        }
        public CategoryEditModel GetCategoryEdetModel(int categoryid = 0)
        {
            if (categoryid != 0)
            {
                var _categoryDB = _dataManager.Category.GetCategoryById(categoryid);
                var _categoryEditModel = new CategoryEditModel()
                {
                    Id = _categoryDB.Id,
                    Name = _categoryDB.Name,
                    Title = _categoryDB.Title,

                };
                return _categoryEditModel;
            }
            else { return new CategoryEditModel() { }; }
        }
        public CategoryViewModel SaveCategoryEditModelToDb(CategoryEditModel categoryEditModel)
        {
            Category _categoryDbModel;
            if (categoryEditModel.Id != 0)
            {
                _categoryDbModel = _dataManager.Category.GetCategoryById(categoryEditModel.Id);
            }
            else
            {
                _categoryDbModel = new Category();
            }
            _categoryDbModel.Name = categoryEditModel.Name;
            _categoryDbModel.Title = categoryEditModel.Title;


            _dataManager.Category.SaveCategory(_categoryDbModel);

            return CategoryDBToViewModelById(_categoryDbModel.Id);
        }

        public CategoryEditModel CreateNewCategoryEditModel()
        {
            return new CategoryEditModel() { };
        }
    }
}
