using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.ApplicationService
{
    public interface IApplicationService
    {
        Task<PagedList<GetApplicationsDto>> GetAllApplications(UserParams userParams);
        Task<PagedList<GetApplicationsDto>> GetAppsForSelection(UserParams userParams);
        Task<GetAppDto> GetApplicationById(int id);
        Task AddApplication(AddApplicationDto app);
        Task<GetAppDto> UpdateStatus(int id, StatusEnum status);

    }
}
