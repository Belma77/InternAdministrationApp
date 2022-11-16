using Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class EditSelectionDto
    {
        public int SelectionId { get; set; }
        public string? Name { get; set; } = String.Empty;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public string? Description { get; set; } = String.Empty;

    }
}
