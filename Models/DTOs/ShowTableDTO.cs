using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs
{
    public class ShowTableDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int TableSeats { get; set; }
    }
}
