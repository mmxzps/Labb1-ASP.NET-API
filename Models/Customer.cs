using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [Range(5, 30)]
        public int PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
