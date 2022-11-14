using Backend.Models.Enums;

namespace Backend.Dtos
{
    public class GetAppDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public string CoverLetter { get; set; }
        public string? CV { get; set; }
        public StatusEnum Status { get; set; }
        public List<GetCommentDto>? Comments { get; set; }
        public List<GetSelectionDto>? Selections { get; set; }
        public string Username { get; set; }
    }
}
