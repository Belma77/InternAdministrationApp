using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Repository.AppRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Drawing.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Services.ApplicationService
{
    public class ApplicationService:IApplicationService
    {
        IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;

        }
        [Authorize]
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
            return _mapper.Map<GetAppDto>(app);
            
        }
         public async Task AddApplication(AddApplicationDto app)
        {
         
            await _applicationRepository.Add(_mapper.Map<Applications>(app));
           
        }

    }
}
