using Backend.Models;

namespace Backend.Repository.SelectionRepo
{
    public interface ISelectionRepository
    {
        Task<List<Selection>> GetAllSelections();
    }
}
