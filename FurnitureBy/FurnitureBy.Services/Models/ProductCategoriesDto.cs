namespace FurnitureBy.Services.Models
{
    public class ProductCategoriesDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Товар.
        /// </summary>
        public string CodeProduct { get; set; }
        public virtual ProductDto Product { get; set; }

        /// <summary>
        /// Раздел.
        /// </summary>
        public string CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }
    }
}
