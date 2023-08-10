

using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto> CreateAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderProductDto> CreateOne(OrderProductDto createData)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}