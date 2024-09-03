using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Labb1_ASP.NET_API.Models.DTOs.Booking
{
    public class EditBookingDTO
    {
        //     public int? CustomerId { get; set; }  
        public int AmountGuest { get; set; }
        [JsonConverter(typeof(CustomDate))]
        public DateTime BookingTime { get; set; }

        [Required]
        [JsonConverter(typeof(CustomDate))]
        public DateTime BookingTimeEnd { get; set; }
        public int TableId { get; set; }
    }
}