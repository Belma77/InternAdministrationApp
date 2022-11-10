using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetByUsername(string username);
        Task<List<GetUsersDto>> GetAll();
        Task<List<GetUsersDto>> Remove(string id);
    }
}
