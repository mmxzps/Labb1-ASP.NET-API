using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs.Customer
{
    public class CustomerWithIdDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
