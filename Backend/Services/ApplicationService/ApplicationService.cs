using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Repository.AppRepo;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Drawing.Text;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Backend.Services.ApplicationService
{
    public class ApplicationService:IApplicationService
    {
        IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private  IUserService _userService;
        private UserManager<User> _userManager;
        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper, IHttpContextAccessor contextAccessor, IUserService userService, UserManager<User> userManager)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor; 
            _userService = userService;
            _userManager = userManager;
        }
        
        public async Task<PagedList<GetApplicationsDto>> GetAllApplications(UserParams userParams)
        {
            var query = _applicationRepository.GetAll(userParams);
           query=FilterApplications.FilterData(query, userParams.filter);
            query = AppsSorting.SortBy(query, userParams.OrderBy);
            var apps = query.ProjectTo<GetApplicationsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetApplicationsDto>.CreateAsync(apps, userParams.PageNumber, userParams.pageSize);
       
        }
        public async Task<GetAppDto> GetApplicationById(int id)
        {
            var app= await _applicationRepository.GetById(id);
            if (app == null)
                throw new Exception("Application not found");
            return _mapper.Map<GetAppDto>(app);
            
        }
         public async Task AddApplication(AddApplicationDto app)
        {
         
            await _applicationRepository.Add(_mapper.Map<Applications>(app));
           
        }
        //private User GetCurrentUser()
        //{
        //    string username = _contextAccessor.HttpContext.User.Identity.Name;
        //    var user = _userService.GetByUsername(username);
        //    return user;
        //}
        public async Task<GetAppDto> AddAppComment(int id, string comment)
        {

            string username = _contextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.GetByUsername(username);
            //var user = GetCurrentUser();
            var app = await _applicationRepository.GetById(id);
            var commmentModel = new Comment();
            commmentModel.User = user;
            commmentModel.Description = comment;
            app.Comments.Add(commmentModel);
            await _applicationRepository.Update(app);
            return _mapper.Map<GetAppDto>(app);

        }
        public async Task<GetAppDto> UpdateStatus(int id, Status status)
        {

            string username = _contextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.GetByUsername(username);
            //var user = GetCurrentUser();
            var app = await _applicationRepository.GetById(id);
            app.Status = status;
            await _applicationRepository.Update(app);
            return _mapper.Map<GetAppDto>(app);

        }

    }
}
