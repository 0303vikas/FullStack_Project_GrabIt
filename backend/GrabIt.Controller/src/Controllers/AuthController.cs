using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.src.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> UserLogin([FromBody] UserLoginDto user)
        {
            return Ok(await _authService.Authenticate(user));
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<User>> UserAuthorization()
        {
            var token = HttpContext.Request.Headers.TryGetValue("Authorization", out var accessToken);
            if (!token) return NotFound("Authroization token not found.");
            return Ok(await _authService.AbstractClaims(accessToken.ToString().Replace("Bearer ", "")));
        }
    }
}