using Abp.Net.Mail;
using AutoMapper;
using Backend.Dtos;
using Backend.ExceptionHandlers;
using Backend.Models;
using Backend.Repository.UserRepo;
using Backend.Services.NotificationService;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        IEmailService _emailService;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService)
        {
            _userRepository = userRepository;  
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public async Task<User> AddEditor(AddEditorDto user)
        {
            IdentityResult result;
            var editor = new User { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, UserName = user.UserName };
            result = await _userManager.CreateAsync(editor, user.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(editor, isPersistent: false);
                await _userManager.AddToRoleAsync(editor, "Editor");
                string subject = "Welome new Editor";
                string body = "Welcome " + user.UserName;
                await _emailService.SendEmail(subject, body);
                return editor;
            }
           
            else
            {
                throw new DomainException("Error occurred");
            }

        }

        public async Task<User> GetByUsername(string username)
        {
            var user=await _userRepository.GetByUserName(username);

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }

        public async Task<List<GetUsersDto>> GetAll()
        {
            return  _mapper.Map<List<GetUsersDto>>(_userRepository.GetAll());
        }

        public async Task<List<GetUsersDto>>Remove(string id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new NotFoundException("User not found");

            await _userRepository.Remove(user);

            return _mapper.Map<List<GetUsersDto>>(_userRepository.GetAll());
        }
    }
}
