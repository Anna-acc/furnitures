using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FurnitureBy.Data.Entities;
using FurnitureBy.Data.Interfaces;
using FurnitureBy.Services.Interfaces;
using FurnitureBy.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureBy.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _order;
        private readonly IBaseRepository<OrderProducts> _orderProducts;

        public OrderService(IBaseRepository<Order> order, IBaseRepository<OrderProducts> orderProducts)
        {
            _order = order;
            _orderProducts = orderProducts;
        }

        public async Task AddNewBasket(string userId)
        {
            var basket = new Order()
            {
                NumberOrder = "Z"+ DateTime.Now.ToString("fffssmmHHddMMyyyy"),
                Status = 0,
                IdUser = userId
            };

            await _order.Add(basket);
        }

        public async Task<bool> AddToBasket(string productCode, string userLogin)
        {
            var basket = await _order.Get(filter: x => x.User.Login == userLogin && x.Status == 0);

            if (basket != null && (await _orderProducts.Get(filter: x => x.CodeProduct == productCode && x.NumberOrder == basket.NumberOrder)) == null)
            {
                await _orderProducts.Add(new OrderProducts() { NumberOrder = basket.NumberOrder, CodeProduct = productCode, Count = 1 });
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
