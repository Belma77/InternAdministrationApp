using Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class AddApplicationDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public EducationLevel EducationLevel { get; set; }
        [Required]
        public string CoverLetter { get; set; }
        //[Required]
       // public string CV { get; set; }
    


    }
}
