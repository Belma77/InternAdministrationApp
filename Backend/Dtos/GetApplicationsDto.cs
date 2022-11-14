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
        public EducationLevelEnum EducationLevel { get; set; }
        public StatusEnum Status { get; set; }

    }
}
