﻿using FurnitureBy.Services.Models;
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

        /// <summary>
        /// Получает разделы для отображениия по главному разделу
        /// </summary>
        /// <param name="mainCategoryId">Код главного раздела</param>
        /// <returns>Список разделов</returns>
        Task<IList<CategoryDto>> GetCategoriesFromMainCategory(int mainCategoryId);

        /// <summary>
        /// Получает все товары в заданной категории
        /// </summary>
        /// <param name="categoryId">Id категории</param>
        /// <returns>Список товаров</returns>
        Task<IList<ProductDto>> GetProductsByCategory(string categoryId);

        /// <summary>
        /// Проверяет, есть ли товар с указанным кодом товара
        /// </summary>
        /// <param name="codeProduct">Код товара</param>
        /// <returns>Истина/Ложь</returns>
        Task<bool> CheckCodeProduct(string codeProduct);
    }
}
