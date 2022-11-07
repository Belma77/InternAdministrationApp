using Backend.Dtos;
using Backend.Extensions;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Services.ApplicationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.WebSockets;

namespace Backend.Controllers
{
    [Route("Application")]
    //[Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetApplicationsDto>>> GetAllApplications([FromQuery] UserParams userParams)
        {
            var apps = await _applicationService.GetAllApplications(userParams);
            Response.AddPaginationHeader(apps.CurrentPage, apps.PageSize, apps.TotalCount, apps.TotalPages);

            return Ok(apps);
        }
        [HttpGet("{id}")]
        
        public async Task<ActionResult<GetAppDto>> GetApplicationById(int id)
        {
            return Ok(await _applicationService.GetApplicationById(id));
        }
       

    }
}
