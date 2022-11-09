using Backend.Dtos;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Services.AuthService;
using Backend.Services.UserService;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        IAuthService _authService;
        
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IAuthService auth)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _authService=auth;
        }
        [HttpPost("AddEditor")]
        public async Task<ActionResult> AddEditor(AddEditorDto user)
        {
            IdentityResult result;
            
            if (ModelState.IsValid)
            {
                var editor = new User { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, UserName = user.UserName };
                result = await _userManager.CreateAsync(editor, user.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(editor, isPersistent: false);
                    await _userManager.AddToRoleAsync(editor, "Editor");
                    return Ok(user);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);

                }
                return BadRequest(result);

            }

            return BadRequest(ModelState);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            return Ok(await _authService.Login(user));
        }
       
        
    }
}