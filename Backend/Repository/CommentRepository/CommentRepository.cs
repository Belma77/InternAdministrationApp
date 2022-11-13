using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Comment> GetById(int id)
        {
         return await  _dataContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            
        }
    }
}
