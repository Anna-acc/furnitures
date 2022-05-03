using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FurnitureBy.Data.Entities;
using FurnitureBy.Domain.Enums;

namespace FurnitureBy.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role[] 
                {
                    new Role{ Id = (int)UserRoleEnum.Administrator, Name = "Администратор" },
                    new Role{ Id = (int)UserRoleEnum.Moderator,     Name = "Модератор" },
                    new Role{ Id = (int)UserRoleEnum.Client,        Name = "Клиент" }

                }
            );
        }
    }
}
