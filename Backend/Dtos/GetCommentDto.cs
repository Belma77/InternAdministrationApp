using Backend.Models;

namespace Backend.Dtos
{
    public class GetCommentDto
    {
        public string Description { get; set; }
        public UserDto User { get; set; }


    }
}
