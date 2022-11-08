using Backend.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Backend.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(AddEditorDto userForRegistration);
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);
        Task<string> CreateTokenAsync();
    }
}
