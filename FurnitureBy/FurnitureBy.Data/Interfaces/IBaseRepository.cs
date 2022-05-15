using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureBy.Data.Interfaces
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    /// <typeparam name="T">Класс для объекта БД.</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Добавляет сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        Task Add(T entity);

        /// <summary>
        /// Добавляет набор сущностей в БД.
        /// </summary>
        /// <param name="entities">Набор сущностей.</param>
        /// <returns></returns>
        Task AddRange(List<T> entities);

        /// <summary>
        /// Редактирует сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        Task Update(T entity);

        /// <summary>
        /// Редактирует набор сущностей в БД.
        /// </summary>
        /// <param name="entities">Набор сущностей.</param>
        Task UpdateRange(List<T> entities);

        /// <summary>
        /// Удаляет сущность в БД.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        Task Remove(T entity);

        /// <summary>
        /// Удаляет набор сущностей в БД.
        /// </summary>
        /// <param name="entities">Набор сущностей.</param>
        Task RemoveRange(List<T> entities);

        /// <summary>
        /// Получает сущность по уникальному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Сущность.</returns>
        Task<T> Get(string id);

        /// <summary>
        /// Возвращает первую сущность по параметрам.
        /// </summary>
        /// <param name="includes">Включения таблиц.</param>
        /// <param name="filter">Фильтры.</param>
        /// <param name="orderBy">Сортировка.</param>
        /// <returns>Коллекция сущностей.</returns>
        Task<T> Get(Func<IQueryable<T>, IQueryable<T>>[] includes = null,
                                 Expression<Func<T, bool>> filter = null,
                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        /// <summary>
        /// Возвращает коллекцию сущностей по параметрам.
        /// </summary>
        /// <param name="includes">Включения таблиц.</param>
        /// <param name="filter">Фильтры.</param>
        /// <param name="orderBy">Сортировка.</param>
        /// <returns>Коллекция сущностей.</returns>
        Task<IEnumerable<T>> GetFilter(Func<IQueryable<T>, IQueryable<T>>[] includes = null,
                                       Expression<Func<T, bool>> filter = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        
        /// <summary>
        /// Начинает транзакцию
        /// </summary>
        /// <returns>Объект транзакции</returns>
        Task<IDbContextTransaction> BeginTransaction();
    }
}
