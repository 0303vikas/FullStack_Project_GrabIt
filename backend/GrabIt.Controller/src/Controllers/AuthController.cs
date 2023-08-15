using GrabIt.Service.Dtos;
using GrabIt.Service.src.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> UserLogin([FromBody] UserLoginDto user)
        {
            return Ok(await _authService.Authenticate(user));
        }
    }
}