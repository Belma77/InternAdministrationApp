using Backend.Dtos;
using Backend.Models;

namespace Backend.Repository.SelectionRepo
{
    public interface ISelectionRepository
    {
        IQueryable<Selection> GetAllSelections();
        Task<Selection> GetSelectionById(int id);
        Task<Selection> AddSelection(Selection selection);
        Task<Selection> EditSelection(Selection selection);
        Task<Selection> RemoveApplicant(Selection selection, Applications applicant);
    }
}
