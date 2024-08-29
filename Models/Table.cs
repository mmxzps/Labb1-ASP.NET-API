using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TableNumber { get; set; }
        [Required]
        public int TableSeats { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
