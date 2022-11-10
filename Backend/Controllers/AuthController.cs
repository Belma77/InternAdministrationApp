using Backend.Dtos;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Services.AuthService;
using Backend.Services.UserService;
using MailKit.Security;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Xml.Linq;
using MailKit.Net.Smtp;

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
                    await SendEmail(user.UserName);
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
        private async Task SendEmail(String username)
        {
            var text = "Hi " + username + " Your username is: username and password: password123!";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("otha.kuhlman@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("otha.kuhlman@ethereal.email"));
            email.Subject = "Welcome new Editor";
            email.Body = new TextPart(TextFormat.Text)
            {
                Text = text
            };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("otha.kuhlman@ethereal.email", "tvdDh4bdRbvd6eJwYb");
            smtp.Send(email);
            smtp.Disconnect(true);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            return Ok(await _authService.Login(user));
        }
       
        
    }
}