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
        public async Task<IActionResult>  GetAll([FromQuery] UserParams userParams)
        {
            var selections = await _selectionService.GetAllSelections(userParams);
            Response.AddPaginationHeader(selections.CurrentPage, selections.PageSize, selections.TotalCount, selections.TotalPages);
            return Ok(selections);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _selectionService.GetSelectionById(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddSelectionDto selectionDto)
        {
            return Ok(await _selectionService.AddSelection(selectionDto));
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(EditSelectionDto selectionDto)
        {
            return Ok(await _selectionService.EditSelection(selectionDto));
        }

        [HttpPatch("AddApplication")]
        public async Task<IActionResult> AddApplicantsToSelection([FromBody] ApplicationToSelectionDto req)
        {
            return Ok(await _selectionService.AddApplicantsToSelection(req.selectionId, req.applicationId));
        }

        [HttpPatch("RemoveApplication")]
        public async Task<IActionResult> RemoveApplicantsToSelection([FromBody] ApplicationToSelectionDto req)
        {
            return Ok(await _selectionService.RemoveApplicantToSelection(req.selectionId, req.applicationId));
        }
        

    }
}
