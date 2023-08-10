using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IUserService : IBaseService<User, UserDto>
    {
        Task<UserDto> GetProfile(Guid id);
        Task<UserDto> CreateAdmin(User user);
        Task<OrderProductDto> CreateOne(OrderProductDto createData);

    }
}