using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureBy.Services.Models
{
    public class ProductDto
    {
        /// <summary>
        /// Код товара.
        /// </summary>
        [Required(ErrorMessage = "Не указа код товара")]
        public string Code { get; set; }

        /// <summary>
        /// Наименование товара.
        /// </summary>
        [Required(ErrorMessage = "Не указано наименование товара")]
        public string Name { get; set; }

        /// <summary>
        /// Описание товара.
        /// </summary>
        [Required(ErrorMessage = "Не указо описание товара товара")]
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
        public virtual ICollection<ProductCategoriesDto> Categories { get; set; }

        /// <summary>
        /// Заказы, в которые входит товар.
        /// </summary>
        public virtual ICollection<OrderProductsDto> Orders { get; set; }

        public ICollection<CategoryDto> AllCategories { get; set; }

        public List<string> CategoryIds { get; set; } = new List<string>();
    }
}
