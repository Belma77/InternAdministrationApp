using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.SelectionRepo
{
    public class SelectionRepository:ISelectionRepository
    {
        private readonly DataContext _dbContext;
        public SelectionRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public IQueryable<Selection> GetAllSelections()
        {
            return  _dbContext.Selections.AsQueryable();
        }
        public async Task<Selection> GetSelectionById(int id)
        {
            return await _dbContext.Selections.Where(x => x.Id == id).
                Include(x => x.Applications)
                .FirstOrDefaultAsync();
        }
        public async Task<Selection> AddSelection(Selection selection)
        {
             _dbContext.Selections.Add(selection);
            await  _dbContext.SaveChangesAsync();
            return selection;
        }

    }
}
