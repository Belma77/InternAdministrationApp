using Backend.Dtos;
using Backend.Models.Enums;

namespace Backend.Models
{
    public class Applications
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string CoverLetter { get; set; }
        public string CV { get; set; }
        public Status Status { get; set; }
        public ICollection<Comment>? Comments  { get; set; }
        public ICollection<Selection>? Selections { get; set; }



    }
}
