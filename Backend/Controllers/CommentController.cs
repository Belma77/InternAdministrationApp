using Backend.Dtos;
using Backend.Services.CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Comment")]
    [ApiController]
    //[Authorize(Roles = "Admin, Editor")]

    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("AddAppComment")]
        public async Task<IActionResult> PostAppComment(AddAppComment commentDto)
        {
            return Ok(await _commentService.PostAppComment(commentDto));
        }

        [HttpPost("AddSelectionComment")]
        public async Task<IActionResult> PostSelectionComment(AddSelectionComment commentDto)
        {
            return Ok(await _commentService.PostSelectionComment(commentDto));
        }
    }
}
