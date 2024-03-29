using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IUserService : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<UserReadDto> CreateAdmin(UserCreateDto user);
        Task<UserReadDto> UpdatePassword(Guid userId, string password);
        Task<bool> CheckEmailAvailability(Guid id, string email);
    }
}