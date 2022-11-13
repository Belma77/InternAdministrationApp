using AutoMapper;
using Backend.Dtos;
using Backend.Models;
using Backend.Repository.AppRepo;
using Backend.Repository.CommentRepository;
using Backend.Services.UserService;
using System.Xml.Linq;

namespace Backend.Services.CommentService
{
    public class CommentService:ICommentService
    {
        private ICommentRepository _commentRepository;
        IMapper _mapper;
        IUserService _userService;
        IApplicationRepository _applicationRepository;
        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserService userService, IApplicationRepository applicationRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userService = userService;
            _applicationRepository = applicationRepository;
        }
        public async Task PostComment(AddAppComment appComment)
        {
            //string username = _contextAccessor.HttpContext.User.Identity.Name;
            string username = "Admin";
            var user = await _userService.GetByUsername(username);
            var app = await _applicationRepository.GetById(appComment.ApplicationId);
            if (app == null)
                throw new Exception("Application not found");
            var comment = _mapper.Map<Comment>(appComment);
            _commentRepository.Add(comment);
            //await _applicationRepository.Update(app);
            
            //_commentRepository.Add(_mapper.Map<Comment>(appComment));

        }
    }
}
