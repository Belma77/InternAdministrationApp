using Backend.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.SelectionService
{
    public interface ISelectionService
    {
        Task<List<GetSelectionDto>> GetAllSelections();
    }
}
