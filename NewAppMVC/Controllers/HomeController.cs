using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewAppMVC.Models;
using PresentationLayer;
using PresentationLayer.models;

namespace NewAppMVC.Controllers
{
    public class HomeController : Controller
    {
       // private EFDBContext _context;
        private DataManager _dataManager;
        private ServicesManager _servicesManager;
        public HomeController(/*EFDBContext context*/ DataManager dataManager) {
            //  _context = context;
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }
        public IActionResult Index()
        {
            MyHelloModel _model = new MyHelloModel() { HelloMessage = "Hey, Alexander!" };
            //List<Directory> _dirs = _context.Directories.Include(x=>x.Materials).ToList();
           // List<Directory> _dirs = _dataManager.Directory.GetAllDirectories(true).ToList();
            List<CategoryViewModel> _dirs = _servicesManager.Categories.GetCategoryList();
            return View(_dirs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
