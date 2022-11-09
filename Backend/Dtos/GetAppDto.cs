using Backend.Models.Enums;

namespace Backend.Dtos
{
    public class GetAppDto
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string CoverLetter { get; set; }
         public string? CV { get; set; }
        public Status Status { get; set; }
        public List<GetCommentDto>? Comments { get; set; }
        public List<GetSelectionDto>? Selections { get; set; }
    }
}
