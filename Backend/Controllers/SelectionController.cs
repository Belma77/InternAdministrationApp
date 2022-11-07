using Backend.Dtos;
using Backend.Extensions;
using Backend.Helpers;
using Backend.Services.SelectionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Selection")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        public SelectionController(ISelectionService selectionService)
        {
             _selectionService=selectionService;

        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSelectionsDto>>> GetAllSelections([FromQuery] UserParams userParams)
        {
            var selections =  await _selectionService.GetAllSelections(userParams);
            Response.AddPaginationHeader(selections.CurrentPage, selections.PageSize, selections.TotalCount, selections.TotalPages);
            return Ok(selections);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<GetSelectionDto>> GetById(int id)
        {
            return Ok(await _selectionService.GetSelectionById(id));
        }
    }
}
