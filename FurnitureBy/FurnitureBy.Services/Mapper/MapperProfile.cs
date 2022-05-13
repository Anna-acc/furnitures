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
        }
    }
}
