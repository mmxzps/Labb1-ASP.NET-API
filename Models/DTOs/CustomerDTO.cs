using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs
{
    public class CustomerDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }



        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }



        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter only digits.")]
        public string PhoneNumber { get; set; }
    }
}
