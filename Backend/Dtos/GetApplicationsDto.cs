using Backend.Models.Enums;
using Backend.Models;

namespace Backend.Dtos
{
    public class GetApplicationsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EducationLevel EducationLevel { get; set; }
        // public string CoverLetter { get; set; }
        //public string? CV { get; set; }
        public Status Status { get; set; }

    }
}
