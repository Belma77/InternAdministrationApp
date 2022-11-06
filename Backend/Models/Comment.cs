using Backend.Dtos;

namespace Backend.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public User Editor { get; set; }
    }
}
