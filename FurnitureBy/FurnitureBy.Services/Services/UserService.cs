using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FurnitureBy.Data.Entities;
using FurnitureBy.Data.Interfaces;
using FurnitureBy.Domain.Enums;
using FurnitureBy.Services.Interfaces;
using FurnitureBy.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureBy.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Role> _roleRepository;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> userRepository, IBaseRepository<Role> roleRepository, IOrderService orderService, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<UserDto> CheckUser(string login, string password)
        {
            return _mapper.Map<UserDto>(await _userRepository.Get(filter: x => x.Login == login && x.Password == password && x.IsActive));
        }

        public async Task<UserDto> GetUser(string login)
        {
            var include = new Func<IQueryable<User>, IQueryable<User>>[]
                {
                    x => x.Include(y => y.Role)
                };
            return _mapper.Map<UserDto>(await _userRepository.Get(filter: x => x.Login == login, includes: include));
        }

        public async Task AddUser(UserDto userDto)
        {
            using (var transaction = await _userRepository.BeginTransaction())
            {
                var user = _mapper.Map<User>(userDto);
                await _userRepository.Add(user);
                if (user.RoleId == (int)UserRoleEnum.Client)
                {
                    await _orderService.AddNewBasket(user.Id);
                }

                await transaction.CommitAsync();
            }
        }

        public async Task EditUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.Update(user);
        }

        public async Task<IList<UserDto>> GetAllUsers()
        {
            var include = new Func<IQueryable<User>, IQueryable<User>>[]
                {
                    x => x.Include(y => y.Role)
                };

            return _mapper.Map<IList<UserDto>>(await _userRepository.GetFilter(includes: include));
        }

        public async Task<IList<RoleDto>> GetAllRoles()
        {
            return _mapper.Map<IList<RoleDto>>(await _roleRepository.GetFilter());
        }
    }
}
