using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Auth
{
    public class AuthRepo:IAuthRepo

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
