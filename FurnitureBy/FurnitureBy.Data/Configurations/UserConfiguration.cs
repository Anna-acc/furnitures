using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FurnitureBy.Data.Entities;
using FurnitureBy.Domain.Enums;

namespace FurnitureBy.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User[]
                {
                    new User { 
                        Id = "2F0D1327-8965-4D21-BC2E-3012348C8008",
                        Login = "Admin",
                        Password = "1111",
                        Surname = "Admin",
                        Name = "Admin",
                        IsActive = true,
                        IsConfirm = true,
                        RoleId = (int)UserRoleEnum.Administrator
                    }
                }
            );
        }
    }
}
