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
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Catalog()
        {
            return View();
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> ProductInCategories(string id, string nameCategory, string description)
        {
            var model = await _productService.GetProductsByCategory(id);

            ViewBag.NameCategory = nameCategory;
            ViewBag.Description = description;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Product(string code)
        {
            var model = await _productService.Get(code);

            if (User.IsInRole("3"))
            {
                ViewBag.IsInBasket = await _orderService.CheckProductInBasket(User.Identity.Name, code);
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
