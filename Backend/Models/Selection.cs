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
        public List<Applications>? Applications { get; set; }=new List<Applications>();
        public List<Comment>? Comments { get; set; }=new List<Comment>();

    }
}
