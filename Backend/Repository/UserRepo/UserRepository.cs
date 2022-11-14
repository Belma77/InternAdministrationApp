using AutoMapper;
using Backend.Dtos;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.UserRepo
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
                this._dataContext = dataContext;
        }
       public async Task<User> GetByUserName(string username)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }
        public async Task<User> GetById(string Id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x =>x.Id==Id);
        }
        public IQueryable<User> GetAll()
        {
            return _dataContext.Users.AsQueryable();
        }
        public async Task<List<User>> Remove(User u)
        {
             _dataContext.Remove(u);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }
    }
}
