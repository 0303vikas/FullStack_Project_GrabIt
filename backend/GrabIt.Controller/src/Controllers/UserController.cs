using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace GrabIt.Controller.src.Controllers
{
    [Authorize]
    public class UserController : GenericBaseController<User, UserDto>
    {
        public UserController(IUserService baseRepo) : base(baseRepo)
        {
        }

    }
}