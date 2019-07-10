using BussinesLayer;
using PresentationLayer.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private CategoryService _categoryService;
        private ProductService _productService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _categoryService = new CategoryService(_dataManager);
            _productService = new ProductService(_dataManager);
        }

        public CategoryService Categories { get { return _categoryService; } }
        public ProductService Products { get { return _productService; } }
    }
}
