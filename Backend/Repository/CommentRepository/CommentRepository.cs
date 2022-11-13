using Backend.Data;
using Backend.Models;

namespace Backend.Repository.CommentRepository
{
    public class CommentRepository:ICommentRepository
    {
        private DataContext _dataContext;
        public CommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Add(Comment comment)
        {
            _dataContext.Add(comment);
            await _dataContext.SaveChangesAsync();
        }
    }
}
