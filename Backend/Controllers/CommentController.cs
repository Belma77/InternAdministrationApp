using Backend.Dtos;
using Backend.Services.CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost("AddAppComment")]
        public async Task<ActionResult<GetCommentDto>> PostAppComment(AddAppComment commentDto)
        {
            
            return Ok(await _commentService.PostAppComment(commentDto));
        }
        [HttpPost("AddSelectionComment")]
        public async Task<ActionResult<GetCommentDto>> PostSelectionComment(AddSelectionComment commentDto)
        {
            
            return Ok(await _commentService.PostSelectionComment(commentDto));
        }
    }
}
