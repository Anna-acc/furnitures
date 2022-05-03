using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Номер заказа.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        [ForeignKey(nameof(User))]
        public string IdUser { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// Товары, входящие в заказ.
        /// </summary>
        public virtual ICollection<OrderProducts> Products { get; set; }
    }
}
