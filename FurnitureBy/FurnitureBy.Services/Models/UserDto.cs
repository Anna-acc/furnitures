using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля.
        /// </summary>
        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [Required(ErrorMessage = "Не указана дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
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
