using Backend.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //[ForeignKey("UserId")]
        //public string UserId { get; set; }
        public User User { get; set; }
    }
}
