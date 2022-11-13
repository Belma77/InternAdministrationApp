using Backend.Dtos;

namespace Backend.Services.CommentService
{
    public interface ICommentService
    {
        Task PostComment(AddAppComment appComment);
    }
}
