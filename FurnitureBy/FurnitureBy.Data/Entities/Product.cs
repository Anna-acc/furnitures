using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Товар.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Код товара.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        /// <summary>
        /// Наименование товара.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Длина.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Цвет.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Материал.
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Механизм.
        /// </summary>
        public string Gear { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Признак "Есть в наличии".
        /// </summary>
        public bool IsAvaible { get; set; }

        /// <summary>
        /// Признак активности.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Категории товара.
        /// </summary>
        public virtual ICollection<ProductCategories> Categories { get; set; }

        /// <summary>
        /// Заказы, в которые входит товар.
        /// </summary>
        public virtual ICollection<OrderProducts> Orders { get; set; }
    }
}
