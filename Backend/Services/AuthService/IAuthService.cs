using Backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Services.AuthService
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(AddEditorDto userRegistration);
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);
        Task<string> CreateTokenAsync();
        Task<string> Login(UserLoginDto user);


    }
}
