using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Содержимое заказа.
    /// </summary>
    public class OrderProducts
    {
        public OrderProducts()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        [ForeignKey(nameof(Order))]
        public string NumberOrder { get; set; }
        public virtual Order Order { get; set; }

        /// <summary>
        /// Товар.
        /// </summary>
        [ForeignKey(nameof(Product))]
        public string CodeProduct { get; set; }
        public virtual Product Product { get; set; }

        /// <summary>
        /// Количество товара в заказе.
        /// </summary>
        public int Count { get; set; }
    }
}
