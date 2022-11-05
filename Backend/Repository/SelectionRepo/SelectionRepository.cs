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
        public async Task<List<Selection>> GetAllSelections()
        {
            return await _dbContext.Selections.ToListAsync();
        }
    }
}
