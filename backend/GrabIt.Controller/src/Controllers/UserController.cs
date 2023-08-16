using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    // [Authorize]
    [AllowAnonymous]
    public class UserController : GenericBaseController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _baseRepo;
        public UserController(IUserService baseRepo) : base(baseRepo)
        {
            _baseRepo = baseRepo;
        }
        [HttpPost("createAdmin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] User user)
        {
            return CreatedAtAction(nameof(CreateAdmin), await _baseRepo.CreateAdmin(user));

        }
        [HttpPut("userId:Guid")]
        public async Task<ActionResult<UserReadDto>> UpdatePassword([FromQuery] Guid userId, [FromBody] string password)
        {
            return Ok(await _baseRepo.UpdatePassword(userId, password));
        }
    }
}