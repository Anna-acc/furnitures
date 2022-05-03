using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Отношение товаров к разделам.
    /// </summary>
    public class ProductCategories
    {
        public ProductCategories()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        /// <summary>
        /// Товар.
        /// </summary>
        [ForeignKey(nameof(Product))]
        public string CodeProduct { get; set; }
        public virtual Product Product { get; set; }

        /// <summary>
        /// Раздел.
        /// </summary>
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
