using FurnitureBy.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureBy.Services.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Добавляет пользователю заказ-корзину
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        Task AddNewBasket(string userId);

        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        /// <param name="productCode">Код товара</param>
        /// <param name="userLogin">Логин пользователя</param>
        /// <returns></returns>
        Task<bool> AddToBasket(string productCode, string userLogin);

        /// <summary>
        /// Получает текущую корзину пользователя
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <returns>Объект корзины</returns>
        Task<OrderDto> GetBasket(string userLogin);

        /// <summary>
        /// Метод для оформления заказа
        /// </summary>
        /// <param name="orderDto">Объект заказа</param>
        Task PlaceOrder(OrderDto orderDto);

        /// <summary>
        /// Получает все заказы для пользователя
        /// </summary>
        /// <param name="isNotClient">Является ли запрашивающий клиентом</param>
        /// <param name="userName">Логин пользователя</param>
        /// <returns>Список заказов</returns>
        Task<IList<OrderDto>> GetAllOrders(bool isNotClient, string userName);

        /// <summary>
        /// Изменяет количество товара в заказе
        /// </summary>
        /// <param name="productOrderId">Код состава товара</param>
        /// <param name="count">Добавляемое количество</param>
        Task ChangeCount(string productOrderId, int count);

        /// <summary>
        /// Устанавливает статус заказу
        /// </summary>
        /// <param name="numberOrder">Номер заказа</param>
        /// <param name="status">Статус</param>
        Task SetStatus(string numberOrder, int status);

        /// <summary>
        /// Получает заказ по номеру заказа
        /// </summary>
        /// <param name="orderNumber">Номер заказа</param>
        /// <returns>Объект заказа</returns>
        Task<OrderDto> GetOrder(string orderNumber);
    }
}
