using Backend.Dtos;
using Backend.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Auth")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService auth)
        {
            _authService=auth;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            return Ok(await _authService.Login(user));
        }
       
        
    }
}