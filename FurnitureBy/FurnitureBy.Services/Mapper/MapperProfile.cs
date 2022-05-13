using AutoMapper;

using FurnitureBy.Data.Entities;
using FurnitureBy.Services.Models;

namespace FurnitureBy.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<OrderProducts, OrderProductsDto>().ReverseMap();
            CreateMap<ProductCategories, ProductCategoriesDto>().ReverseMap();
        }
    }
}
