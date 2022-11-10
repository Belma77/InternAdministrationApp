using AutoMapper;
using Backend.Dtos;
using Backend.Models;
using Backend.Repository.UserRepo;

namespace Backend.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;  
            _mapper = mapper;
        }
        public async Task<User> GetByUsername(string username)
        {
            var user=await _userRepository.GetByUserName(username);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }
        public async Task<List<GetUsersDto>> GetAll()
        {
            return  _mapper.Map<List<GetUsersDto>>(await _userRepository.GetAll());
        }
        public async Task<List<GetUsersDto>>Remove(string id)
        {

            var user = await _userRepository.GetById(id);
            if (user == null)
                throw new Exception("User not found");
            await _userRepository.Remove(user);
            return _mapper.Map<List<GetUsersDto>>(await _userRepository.GetAll());
        }
    }
}
