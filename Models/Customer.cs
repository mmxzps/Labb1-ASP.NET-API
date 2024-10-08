﻿using System.ComponentModel.DataAnnotations;

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
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter only digits.")]
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
