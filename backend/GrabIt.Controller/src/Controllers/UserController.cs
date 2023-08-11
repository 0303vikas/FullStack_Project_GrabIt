using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericBaseController<User, UserDto>
    {
        public UserController(IUserService baseRepo) : base(baseRepo)
        {
        }

    }
}