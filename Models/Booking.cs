using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb1_ASP.NET_API.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AmountGuest { get; set; }

        [Required]
        public DateOnly BookingDate { get; set; }

        [Required]
        public TimeOnly BookingTime { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        public Table Table { get; set; }
    }
}
