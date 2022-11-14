using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class AddEditorDto
    {
        public string FirstName { get; set; }=String.Empty;
        public string LastName { get; set; }=String.Empty;
        public string Email { get; set; } = String.Empty;
        public string UserName { get; set; }=String.Empty;
        public string Password { get; set; }=String.Empty;

    }
}
