using Backend.Dtos;
using Backend.Models;

namespace Backend.Repository.SelectionRepo
{
    public interface ISelectionRepository
    {
        IQueryable<Selection> GetAllSelections();
        Task<Selection> GetSelectionById(int id);
    }
}
