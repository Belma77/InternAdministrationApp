using Backend.Dtos;
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
        public async Task<ActionResult<List<GetSelectionDto>>> GetAllSelections(int? pageNumber, int? pageSize)
        {
            var selections =  await _selectionService.GetAllSelections();
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 1;

            return Ok(Paggination.Pagging(currentPageNumber, currentPageSize, selections));
        }
    }
}
