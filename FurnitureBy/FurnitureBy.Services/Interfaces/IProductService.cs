using FurnitureBy.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureBy.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Получает все имеющиеся в БД товары
        /// </summary>
        /// <returns>Список товаров</returns>
        Task<IList<ProductDto>> GetAllProducts();

        /// <summary>
        /// Получает все имеющиеся в БД разделы
        /// </summary>
        /// <returns>Список разделов</returns>
        Task<IList<CategoryDto>> GetAllCategories();

        /// <summary>
        /// Получает объект товара по его коду.
        /// </summary>
        /// <param name="code">Код товара</param>
        /// <returns>Объект товара</returns>
        Task<ProductDto> Get(string code);

        /// <summary>
        /// Добавляет товар в БД
        /// </summary>
        /// <param name="productDto">Объект товара</param>
        Task AddProduct(ProductDto productDto);

        /// <summary>
        /// Редактирует товар в БД
        /// </summary>
        /// <param name="productDto">Объект товара</param>
        Task EditProduct(ProductDto productDto);
    }
}
