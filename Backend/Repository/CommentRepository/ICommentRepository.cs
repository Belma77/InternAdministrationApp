using Backend.Data;
using Backend.Models;

namespace Backend.Repository.CommentRepository
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
        Task<Comment> GetById(int id);
    }
}
