using System.Collections.Generic;

namespace FurnitureBy.Services.Models
{
    public class CategoryDto
    {
        /// <summary>
        /// Идентификатор раздела.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Название раздела.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание раздела.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Родительская категория
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Признак показа раздела.
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// Товары в разделе.
        /// </summary>
        public virtual ICollection<ProductCategoriesDto> Products { get; set; }
    }
}
