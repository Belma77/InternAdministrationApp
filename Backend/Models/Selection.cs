using Backend.Dtos;

namespace Backend.Models
{
    public class Selection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description{ get; set; }
        public List<Applications>? Applications { get; set; }
        public List<Comment>? SelectionComment { get; set; }

    }
}
