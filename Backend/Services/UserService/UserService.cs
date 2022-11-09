using Backend.Models;
using Backend.Repository.UserRepo;

namespace Backend.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }
        public async Task<User> GetByUsername(string username)
        {
            var user=await _userRepository.GetByUserName(username);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }
    }
}
