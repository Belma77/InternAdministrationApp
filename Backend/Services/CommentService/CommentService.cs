using AutoMapper;
using Backend.Dtos;
using Backend.Models;
using Backend.Repository.AppRepo;
using Backend.Repository.CommentRepository;
using Backend.Repository.SelectionRepo;
using Backend.Services.UserService;
using System.Xml.Linq;

namespace Backend.Services.CommentService
{
    public class CommentService:ICommentService
    {
        private ICommentRepository _commentRepository;
       private IMapper _mapper;
       private IUserService _userService;
       private IApplicationRepository _applicationRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private ISelectionRepository _selectionRepository;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserService userService, IApplicationRepository applicationRepository, IHttpContextAccessor httpContextAccessor, ISelectionRepository selectionRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userService = userService;
            _applicationRepository = applicationRepository;
            _httpContextAccessor = httpContextAccessor;
            _selectionRepository = selectionRepository;
        }
        public async Task<GetCommentDto> PostAppComment(AddAppComment appComment)
        {
            string username = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.GetByUsername(username);
            var app = await _applicationRepository.GetById(appComment.ApplicationId);
            if (app == null)
                throw new Exception("Application not found");
            var comment = _mapper.Map<Comment>(appComment);
            comment.User = user;
            await _commentRepository.Add(comment);
            return _mapper.Map<GetCommentDto>(comment);

        }
        public async Task<GetCommentDto> PostSelectionComment(AddSelectionComment selectionComment)
        {
            string username = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.GetByUsername(username);
            var selection = await _selectionRepository.GetSelectionById(selectionComment.SelectionId);
            if (selection == null)
                throw new Exception("Selection not found");
            var comment = _mapper.Map<Comment>(selectionComment);
            comment.User = user;
            await _commentRepository.Add(comment);
            return _mapper.Map<GetCommentDto>(comment);


        }
    }
}
