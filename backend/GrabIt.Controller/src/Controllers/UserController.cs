using GrabIt.Core.src.Entities;
using GrabIt.Core.src.Shared;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    // [Authorize]
    public class UserController : GenericBaseController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _baseService;
        public UserController(IUserService baseService) : base(baseService)
        {
            _baseService = baseService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createAdmin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto user)
        {
            return CreatedAtAction(nameof(CreateAdmin), await _baseService.CreateAdmin(user));
        }

        [Authorize]
        [HttpPut("updatePassword/{userId:Guid}")]
        public async Task<ActionResult<UserReadDto>> UpdatePassword([FromRoute] Guid userId, [FromBody] UserPasswordUpdateDto password)
        {
            var updateResult = await _baseService.UpdatePassword(userId, password);
            if (updateResult == null) return NotFound();
            return Ok(updateResult);
        }

        [Authorize]
        public override async Task<ActionResult> DeleteOneById([FromRoute] Guid id)
        {
            return await base.DeleteOneById(id);
        }

        [Authorize]
        public override async Task<ActionResult<UserReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] UserUpdateDto updateData)
        {
            return await base.UpdateOneById(id, updateData);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            return await base.GetAll(options);
        }
    }
}