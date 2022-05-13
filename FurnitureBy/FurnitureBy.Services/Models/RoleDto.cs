using System.Collections.Generic;

namespace FurnitureBy.Services.Models
{
    public class RoleDto
    {
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название роли.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пользователи с указанной ролью.
        /// </summary>
        public virtual ICollection<UserDto> Users { get; set; }
    }
}
