using FurnitureBy.Services.Models;
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
    }
}
