using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class AddEditorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
