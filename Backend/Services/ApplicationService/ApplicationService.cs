using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
using Backend.ExceptionHandlers;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Repository.AppRepo;
using Backend.Services.NotificationService;
using Backend.Services.UserService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MimeKit;
using MimeKit.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Drawing.Text;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Backend.Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private IEmailService _emailService;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper, IEmailService emailService)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<PagedList<GetApplicationsDto>> GetAllApplications(UserParams userParams)
        {
            var query = _applicationRepository.GetAll(userParams);
            query = FilterApplications.ExtentQueryWithFilter(query, userParams.filter);
            query = AppsSorting.SortBy(query, userParams.OrderBy);
            var apps = query.ProjectTo<GetApplicationsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetApplicationsDto>.CreateAsync(apps, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<GetApplicationsDto>> GetAppsForSelection(UserParams userParams)
        {
            var query = _applicationRepository.GetAll(userParams);
            query = query.Where(x => x.Status == StatusEnum.Preselection);
            query = FilterApplications.ExtentQueryWithFilter(query, userParams.filter);
            query = AppsSorting.SortBy(query, userParams.OrderBy);
            var apps = query.ProjectTo<GetApplicationsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetApplicationsDto>.CreateAsync(apps, userParams.PageNumber, userParams.PageSize);
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

        public async Task<GetAppDto> UpdateStatus(int id, StatusEnum status)
        {
            var app = await _applicationRepository.GetById(id);

            if (app == null)
                throw new NotFoundException("Application not found");

            app.Status = status;
            await _applicationRepository.Update(app);
            
            if (status == StatusEnum.Inselection)
            {
                string subject = "Welcome to Internship";
                string body = "Welcome to Mistral Internship " + app.FirstName + " " + app.LastName;
                await _emailService.SendEmail(subject, body);
            }
           
            return _mapper.Map<GetAppDto>(app);

        }
       
    }
}
