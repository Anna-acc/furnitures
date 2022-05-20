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
        private readonly IMapper _mapper;

        public OrderService(IBaseRepository<Order> order, IBaseRepository<OrderProducts> orderProducts, IMapper mapper)
        {
            _order = order;
            _orderProducts = orderProducts;
            _mapper = mapper;
        }

        public async Task AddNewBasket(string userId)
        {
            var basket = new Order()
            {
                NumberOrder = "Z" + DateTime.Now.ToString("fffssmmHHddMMyyyy"),
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

        public async Task<OrderDto> GetBasket(string userLogin)
        {
            var include = new Func<IQueryable<Order>, IQueryable<Order>>[]
                {
                    x => x.Include(y => y.Products).ThenInclude(y => y.Product)
                };
            var basket = await _order.Get(filter: x => x.User.Login == userLogin && x.Status == 0, includes: include);
            basket.Price = basket.Products?.Sum(x => x.Product.Price * x.Count);

            return _mapper.Map<OrderDto>(basket);
        }

        public async Task PlaceOrder(OrderDto orderDto)
        {
            using (var transaction = await _order.BeginTransaction())
            {
                var order = _mapper.Map<Order>(orderDto);
                order.DateOrder = DateTime.Now;
                order.Status = 1;

                await _order.Update(order);
                await AddNewBasket(order.IdUser);

                await transaction.CommitAsync();
            }
        }

        public async Task<IList<OrderDto>> GetAllOrders(bool isNotClient, string userName)
        {
            var include = new Func<IQueryable<Order>, IQueryable<Order>>[]
               {
                    x => x.Include(y => y.Products).ThenInclude(y => y.Product)
               };

            return _mapper.Map<IList<OrderDto>>(await _order.GetFilter(includes: include, filter: x => x.Status != 0 && (isNotClient || x.User.Login == userName)));
        }

        public async Task ChangeCount(string productOrderId, int count)
        {
            var productOrder = await _orderProducts.Get(productOrderId);
            productOrder.Count += count;

            if (productOrder.Count == 0)
            {
                return;
            }

            await _orderProducts.Update(productOrder);
        }

        public async Task SetStatus(string numberOrder, int status)
        {
            var order = await _order.Get(numberOrder);
            order.Status = status;

            await _order.Update(order);
        }

        public async Task<OrderDto> GetOrder(string orderNumber)
        {
            var include = new Func<IQueryable<Order>, IQueryable<Order>>[]
                {
                    x => x.Include(y => y.Products).ThenInclude(y => y.Product)
                };
            var order = await _order.Get(filter: x => x.NumberOrder == orderNumber, includes: include);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> CheckProductInBasket(string userLogin, string codeProduct)
        {
            return (await _order.GetFilter(filter: x => x.User.Login == userLogin && x.Status == 0 && x.Products.Any(y => y.CodeProduct == codeProduct))).Any();
        }

        public async Task DeleteFromBasket(string userLogin, string codeProduct)
        {
            var orderProducts = (await _orderProducts.GetFilter(filter: x => x.Order.User.Login == userLogin && x.Order.Status == 0 && x.CodeProduct == codeProduct)).ToList();

            await _orderProducts.RemoveRange(orderProducts);
        }
    }
}
