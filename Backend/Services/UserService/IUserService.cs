using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetByUsername(string username);
    }
}
