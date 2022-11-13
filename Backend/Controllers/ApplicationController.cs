using Backend.Dtos;
using Backend.Extensions;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Services.ApplicationService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.WebSockets;

namespace Backend.Controllers
{
    [Route("Application")]
    [ApiController]
    //[Authorize(Roles = "Admin, Editor")]

    public class ApplicationController : ControllerBase
    {
        IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpPost]
        public async Task<ActionResult> AddApplication(AddApplicationDto app)
        {
            await _applicationService.AddApplication(app);
            return Ok();
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<PagedList<GetApplicationsDto>>> GetAllApplications([FromQuery] UserParams userParams)
        {
            var apps = await _applicationService.GetAllApplications(userParams);
            Response.AddPaginationHeader(apps.CurrentPage, apps.PageSize, apps.TotalCount, apps.TotalPages);

            return Ok(apps);
        }
        [HttpGet("GetAppsForSelection")]
        public async Task<ActionResult<PagedList<GetApplicationsDto>>> GetAppsForSelection([FromQuery] UserParams userParams)
        {
            var apps = await _applicationService.GetAppsForSelection(userParams);
            Response.AddPaginationHeader(apps.CurrentPage, apps.PageSize, apps.TotalCount, apps.TotalPages);

            return Ok(apps);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Applications>> GetApplicationById(int id)
        {

            return Ok(await _applicationService.GetApplicationById(id));
        }


       
        [HttpPatch("UpdateStatus")]
        public async Task<ActionResult<GetAppDto>> UpdateStatus(AppUpdateStatus updateStatus)
        {
            return Ok(await _applicationService.UpdateStatus(updateStatus.ApplicationId, updateStatus.Status));

        }



    }
}
