using BussinesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer
{
    public class DataManager
    {
        private ICategoryRepository _categoryRepository;
        private Func<string, ICategoryRepository> _func;
        private IProductRepository _productRepository;

        // public DataManager(IDirectoryRepository directoryRepository, IMaterialRepository materialRepository)
        public DataManager(Func<string, ICategoryRepository> func, IProductRepository productRepository)
        {
            _func = func;
            _categoryRepository = _func("A");
            _productRepository = productRepository;
        }

        public ICategoryRepository Category { get { return _categoryRepository; } }
        public IProductRepository Product { get {return _productRepository; } }
    }
}
