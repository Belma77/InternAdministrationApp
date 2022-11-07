using Backend.Dtos;
using Backend.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.SelectionService
{
    public interface ISelectionService
    {
        Task<PagedList<GetSelectionsDto>> GetAllSelections(UserParams userParams);
        Task<GetSelectionDto> GetSelectionById(int id);
    }
}
