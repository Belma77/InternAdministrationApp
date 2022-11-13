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
        [HttpPost]
        public async Task<ActionResult> PostComment(AddAppComment commentDto)
        {
            await _commentService.PostComment(commentDto);
            return Ok();
        }
    }
}
