using Backend.Models;

namespace Backend.Dtos
{
    public class GetSelectionsDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        //public List<GetApplicationsDto>? Applications { get; set; }
        //public List<GetCommentDto>? SelectionComment { get; set; }
    }
}
