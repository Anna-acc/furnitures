using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Раздел товаров.
    /// </summary>
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Идентификатор раздела.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public virtual ICollection<ProductCategories> Products { get; set; }
    }
}
