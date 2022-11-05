using Backend.Models;

namespace Backend.Dtos
{
    public class GetSelectionDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public List<GetApplicationDto> Applications { get; set; }
        public List<GetCommentDto>? Comments { get; set; }
    }
}
