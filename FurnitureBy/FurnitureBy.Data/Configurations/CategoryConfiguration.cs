using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FurnitureBy.Data.Entities;
using FurnitureBy.Domain.Enums;

namespace FurnitureBy.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category[]
                {
                    new Category {
                        Id = "967ED34D-3E98-4DEC-B108-A76561478E77",
                        Name = "Столы-транформеры",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "08EA2E88-D576-4008-9070-EA21CC91067E",
                        Name = "Столы обеденные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "6351A626-BB4A-43DA-994A-3A9F5A9F7B0C",
                        Name = "Столы компьютерные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "DD6A604D-118F-4DE6-AA4B-F1EF9AEE3A1B",
                        Name = "Столы-книги",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "7F2C5637-A686-44C2-BD52-B48ECE418CC4",
                        Name = "Столы журнальные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "0FFC296E-8DA3-415F-9EC1-2EF0C164A15F",
                        Name = "Столы для сада",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "915AB52E-9E7B-4536-ACBB-AEB4CC4720D2",
                        Name = "Столы туалетные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Tables,
                        IsShow = true
                    },
                    new Category {
                        Id = "CE0EB21A-B1DD-41A7-8DDC-B44364A4BA3E",
                        Name = "Стулья обеденные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "47F4AC2C-68DA-4E17-A557-1C56630877CE",
                        Name = "Табуреты",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "B09F0A09-0D6C-47BD-94E1-4C1BF0382C30",
                        Name = "Стулья компьютерные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "3D8BDA65-0354-45F1-AEFE-D8C8DF0E6CF8",
                        Name = "Барные стулья",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "0C5549DB-2EE2-46F1-B0BC-3568FA1F9C32",
                        Name = "Подушка для стула",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "F7B6F7DC-84EB-4D24-9CFD-E4FD27AA15EA",
                        Name = "Стулья для сада",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "C2FDC337-1567-4B04-8827-E639725BB929",
                        Name = "Стулья классические",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Chairs,
                        IsShow = true
                    },
                    new Category {
                        Id = "5FD132AF-DF42-4D16-B099-8F639BE6B4AB",
                        Name = "2-местные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Bads,
                        IsShow = true
                    },
                    new Category {
                        Id = "3E095A2A-E65D-4889-B239-F95F7C8A8723",
                        Name = "1-местные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Bads,
                        IsShow = true
                    },
                    new Category {
                        Id = "7CDACD63-E07E-470D-B59A-3111C5B31CC3",
                        Name = "Детские",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Bads,
                        IsShow = true
                    },
                    new Category {
                        Id = "C1627F62-7006-4993-8ACB-786F4321370F",
                        Name = "2-ярусные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Bads,
                        IsShow = true
                    },
                    new Category {
                        Id = "C1681BE4-9A9D-4C83-9ECC-44978186BDBF",
                        Name = "Угловые",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Sofas,
                        IsShow = true
                    },
                    new Category {
                        Id = "4451E155-8F35-483C-8A4A-2C15B8DCFD67",
                        Name = "Модульные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Sofas,
                        IsShow = true
                    },
                    new Category {
                        Id = "C6FFCD65-2284-4778-9976-9A380BA22784",
                        Name = "Софы",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Sofas,
                        IsShow = true
                    },
                    new Category {
                        Id = "27B09768-FC8F-49C5-B298-EA6986B74FC6",
                        Name = "Кровати",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Sofas,
                        IsShow = true
                    },
                    new Category {
                        Id = "AB01742F-413A-420B-8D7C-416F31753AA2",
                        Name = "Купе",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Closets,
                        IsShow = true
                    },
                    new Category {
                        Id = "EE175C2A-F427-4E33-B2A2-D202D7F8C831",
                        Name = "Для одежды",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Closets,
                        IsShow = true
                    },
                    new Category {
                        Id = "99322F12-450D-488D-AFC2-E1EC06CFBC9D",
                        Name = "Кухонные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Closets,
                        IsShow = true
                    },
                    new Category {
                        Id = "CB0326CE-F5FB-42F3-8977-08383E9B5DAF",
                        Name = "Книжные",
                        Description = "",
                        ParentId = (int)MainCategoryEnum.Closets,
                        IsShow = true
                    }
                }
            );
        }
    }
}
