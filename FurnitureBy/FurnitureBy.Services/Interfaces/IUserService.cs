using FurnitureBy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureBy.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Получает пользователя по логину и паролю.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Пользователя</returns>
        Task<UserDto> CheckUser(string login, string password);

        /// <summary>
        /// Получает пользователя по логину.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <returns>Пользователя</returns>
        Task<UserDto> GetUser(string login);

        /// <summary>
        /// Добавляет пользователя
        /// </summary>
        /// <param name="userDto">Модель пользователя</param>
        Task AddUser(UserDto userDto);

        /// <summary>
        /// Сохраняет изменения пользователя
        /// </summary>
        /// <param name="userDto">Модель пользователя</param>
        Task EditUser(UserDto userDto);

        /// <summary>
        /// Возвращает всех имеющихся пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        Task<IList<UserDto>> GetAllUsers();

        /// <summary>
        /// Возвращает все имеющиеся в системе роли
        /// </summary>
        /// <returns>Список ролей</returns>
        Task<IList<RoleDto>> GetAllRoles();

        /// <summary>
        /// Проверяет, есть ли в системе пользователь с соовествующим логином
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Истина/Ложь</returns>
        Task<bool> CheckLogin(string login);
    }
}
