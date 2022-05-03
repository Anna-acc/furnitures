using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBy.Data.Entities
{
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        [Key,  DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Название роли.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пользователи с указанной ролью.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
