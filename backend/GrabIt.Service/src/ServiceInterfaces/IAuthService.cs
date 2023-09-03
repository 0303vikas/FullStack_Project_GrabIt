using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.src.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(UserLoginDto credentials);
        Task<User> AbstractClaims(string token);
    }
}