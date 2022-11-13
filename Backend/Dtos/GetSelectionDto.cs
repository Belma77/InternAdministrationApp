using Backend.Models;

namespace Backend.Dtos
{
    public class GetSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Description { get; set; }
        public List<GetApplicationsDto> Applications { get; set; }
        public List<GetCommentDto> Comments { get; set; }
    }
}
