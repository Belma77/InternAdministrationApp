using Backend.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Runtime.ExceptionServices;

namespace Backend.Models
{
    public class User:IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string Email { get; set; }
        //public UserRole UserRole { get; set; }



    }
}
