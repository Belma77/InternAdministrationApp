using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Repository.AppRepo;
using Backend.Services.UserService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MimeKit;
using MimeKit.Text;
using System.Drawing.Text;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Backend.Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private IUserService _userService;
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
            query = FilterApplications.FilterData(query, userParams.filter);
            query = AppsSorting.SortBy(query, userParams.OrderBy);
            var apps = query.ProjectTo<GetApplicationsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetApplicationsDto>.CreateAsync(apps, userParams.PageNumber, userParams.pageSize);

        }
        public async Task<PagedList<GetApplicationsDto>> GetAppsForSelection(UserParams userParams)
        {
            var query = _applicationRepository.GetAll(userParams);
            query = query.Where(x => x.Status == Status.Preselection);
            query = FilterApplications.FilterData(query, userParams.filter);
            query = AppsSorting.SortBy(query, userParams.OrderBy);
            var apps = query.ProjectTo<GetApplicationsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetApplicationsDto>.CreateAsync(apps, userParams.PageNumber, userParams.pageSize);

        }
        public async Task<GetAppDto> GetApplicationById(int id)
        {
            var app = await _applicationRepository.GetById(id);
            if (app == null)
                throw new Exception("Application not found");
            return _mapper.Map<GetAppDto>(app);

        }
        public async Task AddApplication(AddApplicationDto app)
        {

            await _applicationRepository.Add(_mapper.Map<Applications>(app));

        }

        public async Task<GetAppDto> AddAppComment([FromQuery] int id, string comments)
        {

            //string username = _contextAccessor.HttpContext.User.Identity.Name;
            string username = "Admin";
            var user = await _userService.GetByUsername(username);
            var app = await _applicationRepository.GetById(id);
            if (app == null)
                throw new Exception("Application not found");
            var commmentModel = new Comment();
            commmentModel.User = user;
            commmentModel.Description = comments;
            app.Comments.Add(commmentModel);
            await _applicationRepository.Update(app);
            return _mapper.Map<GetAppDto>(app);

        }
        public async Task<GetAppDto> UpdateStatus(int id, Status status)
        {

            var app = await _applicationRepository.GetById(id);
            if (app == null)
                throw new Exception("Application not found");
            app.Status = status;
            await _applicationRepository.Update(app);
            if (status == Status.Inselection)
                SendEmail();
            return _mapper.Map<GetAppDto>(app);

        }
        private void SendEmail()
        {
            var text = "Welcome to internship!";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("otha.kuhlman@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("otha.kuhlman@ethereal.email"));
            email.Subject = "Welcome to internship";
            email.Body = new TextPart(TextFormat.Text)
            {
                Text = text
            };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("otha.kuhlman@ethereal.email", "tvdDh4bdRbvd6eJwYb");
            smtp.Send(email);
            smtp.Disconnect(true);

        }

    }
}
