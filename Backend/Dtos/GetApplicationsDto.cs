using Backend.Models.Enums;
using Backend.Models;

namespace Backend.Dtos
{
    public class GetApplicationsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EducationLevel EducationLevel { get; set; }
<<<<<<< HEAD
=======
        // public string CoverLetter { get; set; }
        //public string? CV { get; set; }
>>>>>>> 078bafeb0608d521b4d8d579c0ef89fa63c856b4
        public Status Status { get; set; }

    }
}
