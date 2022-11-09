using Backend.Dtos;
using Backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<User> GetByUserName(string username);
    }
}
