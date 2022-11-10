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
            return await _dbContext.Selections.
                Include(x => x.Applications).Include(x=>x.Comments).ThenInclude(x=>x.User)
                .FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<Selection> AddSelection(Selection selection)
        {
             _dbContext.Selections.Add(selection);
            await  _dbContext.SaveChangesAsync();
            return selection;
        }
        public async Task<Selection> EditSelection(Selection selection)
        {
            _dbContext.Selections.Update(selection);
            await _dbContext.SaveChangesAsync();
            return selection;
        }
        public async Task<Selection> RemoveApplicant(Selection selection, Applications applicant) 
        {
           
           selection.Applications.Remove(applicant);
            await _dbContext.SaveChangesAsync();
            return selection;

        }

    }
}
