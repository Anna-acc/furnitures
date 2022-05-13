using System;
using System.Collections.Generic;

namespace FurnitureBy.Services.Models
{
    public class OrderDto
    {
        /// <summary>
        /// Номер заказа.
        /// </summary>
        public string NumberOrder { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Общая стоимость.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Дата осуществления заказа.
        /// </summary>
        public DateTime? DateOrder { get; set; }

        /// <summary>
        /// Адресс.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// ФИО Получателя.
        /// </summary>
        public string NamePerson { get; set; }

        /// <summary>
        /// Пользователь, от которого был сделан заказ.
        /// </summary>
        public string IdUser { get; set; }
        public virtual UserDto User { get; set; }

        /// <summary>
        /// Товары, входящие в заказ.
        /// </summary>
        public virtual ICollection<OrderProductsDto> Products { get; set; }
    }
}
