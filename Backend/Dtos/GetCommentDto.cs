using Backend.Models;

namespace Backend.Dtos
{
    public class GetCommentDto
    {
        public string Comment { get; set; }
        public UserDto User { get; set; }



    }
}
