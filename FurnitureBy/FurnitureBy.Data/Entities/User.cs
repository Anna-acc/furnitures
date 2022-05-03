using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        /// <summary>
        /// Заказы пользователя.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}
