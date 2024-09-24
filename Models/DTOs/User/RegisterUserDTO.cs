using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs.User
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
