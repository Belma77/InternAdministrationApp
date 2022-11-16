using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.SelectionService
{
    public interface ISelectionService
    {
        Task<PagedList<GetSelectionsDto>> GetAllSelections(UserParams userParams);
        Task<GetSelectionDto> GetSelectionById(int id);
        Task<GetSelectionsDto> AddSelection(AddSelectionDto addSelection);
        Task<GetSelectionDto> EditSelection(EditSelectionDto addSelection);
        Task<GetSelectionDto> AddApplicantsToSelection(int selectionId, int applicationId);
        Task<GetSelectionDto> RemoveApplicantToSelection(int selectionId, int applicationId);
    }
}
