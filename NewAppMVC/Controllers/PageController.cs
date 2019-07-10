using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.models;
using static DataLayer.Enum.PageEnums;

namespace NewAppMVC.Controllers
{
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _serviceManager;

        public PageController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(dataManager);
        }

        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel _pageViewModel;
            switch (pageType)
            {
                case PageType.Category: _pageViewModel = _serviceManager.Categories.CategoryDBToViewModelById(pageId); break;
                case PageType.Product: _pageViewModel = _serviceManager.Products.ProductDBModelToView(pageId); break;
                default: _pageViewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_pageViewModel);
        }

        [HttpGet]
        public IActionResult PageEditor(int pageId, PageType pageType, int categoryId = 0)
        {
            PageEditModel _editModel;
            switch (pageType)
            {
                case PageType.Category:
                    if (pageId != 0) _editModel = _serviceManager.Categories.GetCategoryEdetModel(pageId);
                    else _editModel = _serviceManager.Categories.CreateNewCategoryEditModel();
                    break;
                case PageType.Product:
                    if (pageId != 0) _editModel = _serviceManager.Products.GetProductEdetModel(pageId);
                    else _editModel = _serviceManager.Products.CreateNewProductEditModel(categoryId);
                    break;
                default: _editModel = null;
                    break;
            }
            ViewBag.PageType = pageType;
            return View(_editModel);
        }

        [HttpPost]
        public IActionResult SaveDirectory(CategoryEditModel model)
        {
            _serviceManager.Categories.SaveCategoryEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, PageType.Category });
        }

        [HttpPost]
        public IActionResult SaveMaterial(ProductEditModel model)
        {
            _serviceManager.Products.SaveProductEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, PageType.Product });
        }
    }
}