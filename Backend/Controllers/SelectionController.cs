using Backend.Dtos;
using Backend.Extensions;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.SelectionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Selection")]
    [ApiController]
    //[Authorize(Roles = "Admin, Editor")]

    public class SelectionController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        public SelectionController(ISelectionService selectionService)
        {
            _selectionService = selectionService;

        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSelectionsDto>>> GetAllSelections([FromQuery] UserParams userParams)
        {
            var selections = await _selectionService.GetAllSelections(userParams);
            Response.AddPaginationHeader(selections.CurrentPage, selections.PageSize, selections.TotalCount, selections.TotalPages);
            return Ok(selections);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<GetSelectionDto>> GetById(int id)
        {
            return Ok(await _selectionService.GetSelectionById(id));

        }
        [HttpPost("Add")]
        public async Task<ActionResult<GetSelectionsDto>> AddSelection(AddSelectionDto selectionDto)
        {
            return Ok(await _selectionService.AddSelection(selectionDto));
        }
        [HttpPut("Edit")]
        public async Task<ActionResult<GetSelectionsDto>> EditSelection(EditSelectionDto selectionDto)
        {
            return Ok(await _selectionService.EditSelection(selectionDto));
        }
        [HttpPatch("AddApplication")]
        public async Task<ActionResult<GetSelectionDto>> AddApplicantsToSelection([FromBody] ApplicationToSelectionDto req)
        {
            return Ok(await _selectionService.AddApplicantsToSelection(req.selectionId, req.applicationId));
        }
        [HttpPatch("RemoveApplication")]
        public async Task<ActionResult<GetSelectionDto>> RemoveApplicantsToSelection([FromBody] ApplicationToSelectionDto req)
        {
            return Ok(await _selectionService.RemoveApplicantToSelection(req.selectionId, req.applicationId));
        }
        

    }
}
