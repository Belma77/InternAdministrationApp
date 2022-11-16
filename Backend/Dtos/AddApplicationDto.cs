using Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class AddApplicationDto
    {
        
        public string FirstName { get; set; }=String.Empty;
        public string LastName { get; set; }=String.Empty;
        public string Email { get; set; } = String.Empty;
        public EducationLevelEnum? EducationLevel { get; set; }
        public string CoverLetter { get; set; } = String.Empty;
        public string CV { get; set; } = String.Empty;
    


    }
}
