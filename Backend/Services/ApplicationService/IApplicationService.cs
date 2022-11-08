using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.ApplicationService
{
    public interface IApplicationService
    {
        public Task<PagedList<GetApplicationsDto>> GetAllApplications(UserParams userParams);
        Task<GetAppDto> GetApplicationById(int id);
        Task AddApplication(AddApplicationDto app);


    }
}
