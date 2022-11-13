using Backend.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int ApplicationId { get; set; }
        public int SelectionId { get; set; }


    }
}
