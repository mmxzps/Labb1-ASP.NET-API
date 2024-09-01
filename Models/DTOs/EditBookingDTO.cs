using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Labb1_ASP.NET_API.Models.DTOs
{
    public class EditBookingDTO
    {
        public int? CustomerId { get; set; }  
        public int? AmountGuest { get; set; }
        [JsonConverter(typeof(CustomDate))]
        public DateTime? BookingDate { get; set; }
        public int? TableId { get; set; }
    }
}   