using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb1_ASP.NET_API.Models.DTOs
{
    public class CreateBookingDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter only digits.")]
        public string PhoneNumber { get; set; }
        [Required]
        public int AmountGuest { get; set; }
        [Required]
        [JsonConverter(typeof(CustomDate))]
        public DateTime BookingTime { get; set; }
        //public TimeSpan Duration { get; set; } = TimeSpan.FromHours(2);
        [Required]
        public int TableId { get; set; }
    }
}
