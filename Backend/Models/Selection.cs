using Backend.Dtos;

namespace Backend.Models
{
    public class Selection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt{ get; set; }

        public string Description{ get; set; }
        public ICollection<Applications>? Applications { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
