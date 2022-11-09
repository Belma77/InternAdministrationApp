using Backend.Models;

namespace Backend.Repository.Auth
{
    public interface IAuthRepo
    {
        Task<Models.User> findByUsername(string username);

    }
}
