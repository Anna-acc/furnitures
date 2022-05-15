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

    }
}
