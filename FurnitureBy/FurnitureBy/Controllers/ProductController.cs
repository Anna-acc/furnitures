using FurnitureBy.Services.Interfaces;
using FurnitureBy.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureBy.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProductController(IProductService productService, IWebHostEnvironment appEnvironment)
        {
            _productService = productService;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> AllProducts()
        {
            var listProducts = await _productService.GetAllProducts();

            return View(listProducts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Mode = "Add";

            var model = new ProductDto();
            model.AllCategories = await _productService.GetAllCategories();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto, IFormFile Image)
        {
            if (Image == null)
            {
                ModelState.AddModelError("Image", "Не выбрано изображение товара");
            }
            if (await _productService.CheckCodeProduct(productDto.Code))
            {
                ModelState.AddModelError("Code", "Товар с таким кодом уже имеется в системе");
            }
            if (productDto.IsAvaible && !productDto.Price.HasValue)
            {
                ModelState.AddModelError("Price", "Для товара, имеющегося в наличии должна быть указана цена");
            }
            if (ModelState.IsValid)
            {
                await _productService.AddProduct(productDto);

                using (var fileStream = new FileStream($"{_appEnvironment.WebRootPath}/ImagesProduct/{productDto.Code}.jpg", FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                return RedirectToAction("AllProducts", "Product");
            }

            ViewBag.Mode = "Add";

            productDto.AllCategories = await _productService.GetAllCategories();
            return View("Edit", productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string code)
        {
            ViewBag.Mode = "Edit";

            var model = await _productService.Get(code);
            model.AllCategories = await _productService.GetAllCategories();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto productDto, IFormFile Image)
        {
            if (productDto.IsAvaible && !productDto.Price.HasValue)
            {
                ModelState.AddModelError("Price", "Для товара, имеющегося в наличии должна быть указана цена");
            }
            if (ModelState.IsValid)
            {
                await _productService.EditProduct(productDto);

                if (Image != null)
                {
                    using (var fileStream = new FileStream($"{_appEnvironment.WebRootPath}/ImagesProduct/{productDto.Code}.jpg", FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }
                }

                return RedirectToAction("AllProducts", "Product");
            }

            ViewBag.Mode = "Edit";

            productDto.AllCategories = await _productService.GetAllCategories();
            return View("Edit", productDto);
        }
    }
}
