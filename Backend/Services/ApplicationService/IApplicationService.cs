using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.ApplicationService
{
    public interface IApplicationService
    {
        public Task<PagedList<GetApplicationDto>> GetAllApplications(UserParams userParams);
        Task<GetApplicationDto> GetApplicationById(int id);
        
    }
}
