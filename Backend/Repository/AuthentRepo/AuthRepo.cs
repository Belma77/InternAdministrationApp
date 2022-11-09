using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Auth
{
<<<<<<< HEAD
    public class AuthRepo:IAuthRepo
=======
    public class AuthRepo : IAuthRepo
>>>>>>> 09b45b1e04f99431862fcbbe71067ae92da2d2b2
    {
        private DataContext _dbContext;
        public AuthRepo(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Models.User> findByUsername(string username)
        {
            return  await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());

        }
    }
}
