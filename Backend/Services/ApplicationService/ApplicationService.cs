using AutoMapper;
using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Repository.AppRepo;
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
        public async Task<PagedList<GetApplicationDto>> GetAllApplications(UserParams userParams)
        {
            var query=_applicationRepository.GetAll(userParams);
            var apps=query.Select(c=>_mapper.Map<GetApplicationDto>(c));
            return await PagedList<GetApplicationDto>.CreateAsync(apps, userParams.PageNumber, userParams.pageSize);
           // return _mapper.Map<List<GetApplicationDto>>(apps);
        }
        public async Task<GetApplicationDto> GetApplicationById(int id)
        {
            var app= await _applicationRepository.GetById(id);
            return _mapper.Map<GetApplicationDto>(app);
            
        }
       

    }
}
