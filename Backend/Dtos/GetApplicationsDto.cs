using Backend.Models.Enums;
using Backend.Models;

namespace Backend.Dtos
{
    public class GetApplicationsDto
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public Status Status { get; set; }

    }
}
