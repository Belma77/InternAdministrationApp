using Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class EditSelectionDto
    {
        public int SelectionId { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

    }
}
