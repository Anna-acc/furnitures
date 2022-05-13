using System;
using System.Collections.Generic;

namespace FurnitureBy.Services.Models
{
    public class UserDto
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Признак активности пользователя.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Признак подтверждения пользователя.
        /// </summary>
        public bool IsConfirm { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public int RoleId { get; set; }
        public virtual RoleDto Role { get; set; }

        /// <summary>
        /// Заказы пользователя.
        /// </summary>
        public virtual ICollection<OrderDto> Orders { get; set; }
    }
}
