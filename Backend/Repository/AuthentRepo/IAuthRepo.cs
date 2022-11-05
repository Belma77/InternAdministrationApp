using Backend.Models;

namespace Backend.Repository.Auth
{
    public interface IAuthRepo
    {
        public Models.User findByUsername(string username);

    }
}
