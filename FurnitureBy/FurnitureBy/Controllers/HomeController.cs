using FurnitureBy.Models;
using FurnitureBy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureBy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService; 

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public async Task<IActionResult> Categories(int mainCategoryId)
        {
            var model = await _productService.GetCategoriesFromMainCategory(mainCategoryId);

            if (mainCategoryId == 4)
            {
                ViewBag.AdditionalCategory = await _productService.GetCategoriesFromMainCategory(5);
            }
            else
            {
                ViewBag.AdditionalCategory = null;
            }

            return View(model);
        }

        public async Task<IActionResult> ProductInCategories(string id, string nameCategory)
        {
            var model = await _productService.GetProductsByCategory(id);

            ViewBag.NameCategory = nameCategory;

            return View(model);
        }

        public async Task<IActionResult> Product(string code)
        {
            var model = await _productService.Get(code);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
