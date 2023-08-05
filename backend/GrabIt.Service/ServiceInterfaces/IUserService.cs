using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IUserService
    {
        UserDto GetProfile();
        UserDto CreateAdmin(User user);

    }
}