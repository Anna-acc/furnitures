namespace FurnitureBy.Services.Models
{
    public class OrderProductsDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public string NumberOrder { get; set; }
        public virtual OrderDto Order { get; set; }

        /// <summary>
        /// Товар.
        /// </summary>
        public string CodeProduct { get; set; }
        public virtual ProductDto Product { get; set; }

        /// <summary>
        /// Количество товара в заказе.
        /// </summary>
        public int Count { get; set; }
    }
}
