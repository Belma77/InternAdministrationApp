using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Auth
{
<<<<<<< HEAD
    public class AuthRepo : IAuthRepo
=======
    public class AuthRepo:IAuthRepo
>>>>>>> 2c0b113c213ad8ae36d2e5ea72bddd6c99608249

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
