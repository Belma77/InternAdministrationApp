using Backend.Dtos;

namespace Backend.Services.CommentService
{
    public interface ICommentService
    {
        Task<GetCommentDto> PostAppComment(AddAppComment appComment);
        Task<GetCommentDto> PostSelectionComment(AddSelectionComment selectionComment);
    }
}
