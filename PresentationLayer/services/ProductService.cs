using BussinesLayer;
using DataLayer.Entityes;
using PresentationLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.services
{
    public class ProductService
    {
        private DataManager _dataManager;
        public ProductService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ProductViewModel ProductDBModelToView(int productId)
        {
            var _model = new ProductViewModel()
            {
                Product = _dataManager.Product.GetProductById(productId),
            };
            var _dir = _dataManager.Category.GetCategoryById(_model.Product.CategoryId, true);

            if (_dir.Product.IndexOf(_dir.Product.FirstOrDefault(x => x.Id == _model.Product.Id)) != _dir.Product.Count() - 1)
            {
                _model.NextProduct = _dir.Product.ElementAt(_dir.Product.IndexOf(_dir.Product.FirstOrDefault(x => x.Id == _model.Product.Id)) + 1);
            }
            return _model;
        }

        public ProductEditModel GetProductEdetModel(int productId) //приведение edet к модели
        {
            var _dbModel = _dataManager.Product.GetProductById(productId);
            var _editModel = new ProductEditModel()
            {
                Id = _dbModel.Id = _dbModel.Id,
                CategoryId = _dbModel.CategoryId,
                Name = _dbModel.Name,
                Title = _dbModel.Title,
                Price = _dbModel.Price
            };
            return _editModel;
        }

        public ProductViewModel SaveProductEditModelToDb(ProductEditModel editModel)
        {
            Product product;
            if (editModel.Id != 0)
            {
                product = _dataManager.Product.GetProductById(editModel.Id);
            }
            else
            {
                product = new Product();
            }
            product.Name = editModel.Name;
            product.Title = editModel.Title;
            product.Price = editModel.Price;
            product.CategoryId = editModel.CategoryId;
            _dataManager.Product.SaveProduct(product);
            return ProductDBModelToView(product.Id);
        }
        public ProductEditModel CreateNewProductEditModel(int categoryId)
        {
            return new ProductEditModel() { CategoryId = categoryId };
        }
    }
}
