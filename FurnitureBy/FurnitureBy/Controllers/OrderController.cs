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
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [Authorize(Roles = "3")]
        [HttpPost]
        public async Task<IActionResult> AddToBasket(string productCode)
        {
            var result = await _orderService.AddToBasket(productCode, User.Identity.Name);

            return Json(result);
        }

        [Authorize(Roles = "3")]
        [HttpGet]
        public async Task<IActionResult> Basket()
        {
            var basket = await _orderService.GetBasket(User.Identity.Name);
            return View(basket);
        }

        [Authorize(Roles = "3")]
        public async Task<IActionResult> PlaceOrder(OrderDto order)
        {
            if (ModelState.IsValid)
            {
                if (order.Price == 0)
                {
                    ModelState.AddModelError("", "Нельзя оформить пустой заказ");
                }
                else
                {
                    await _orderService.PlaceOrder(order);

                    return RedirectToAction("AllOrders");
                }
            }

            var basket = await _orderService.GetBasket(User.Identity.Name);
            basket.Address = order.Address;
            basket.NamePerson = order.NamePerson;

            return View("Basket", basket);
        }

        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            var model = await _orderService.GetAllOrders(!User.IsInRole("3"), User.Identity.Name);
            return View(model);
        }

        [Authorize(Roles = "3")]
        [HttpGet]
        public async Task<IActionResult> ChangeCount(string productOrderId, int count)
        {
            await _orderService.ChangeCount(productOrderId, count);

            return RedirectToAction("Basket");
        }

        [Authorize(Roles = "3")]
        [HttpGet]
        public async Task<IActionResult> DeleteFromBasket(string productCode)
        {
            await _orderService.DeleteFromBasket(User.Identity.Name, productCode);

            return RedirectToAction("Basket");
        }

        [HttpGet]
        public async Task<IActionResult> SetStatus(string numberOrder, int status)
        {
            await _orderService.SetStatus(numberOrder, status);

            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        public async Task<IActionResult> ShowOrder(string numberOrder)
        {
            var order = await _orderService.GetOrder(numberOrder);

            return View(order);
        }
    }
}
