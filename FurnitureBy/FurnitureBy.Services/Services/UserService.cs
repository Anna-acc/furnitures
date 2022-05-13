using System.Threading.Tasks;
using AutoMapper;
using FurnitureBy.Data.Entities;
using FurnitureBy.Data.Interfaces;
using FurnitureBy.Services.Interfaces;
using FurnitureBy.Services.Models;

namespace FurnitureBy.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CheckUser(string login, string password)
        {
            return _mapper.Map<UserDto>(await _userRepository.Get(filter: x => x.Login == login && x.Password == password));
        }
    }
}
