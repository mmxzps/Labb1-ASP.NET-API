using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs.Menu
{
    public class CreateMenuDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Minimum name length is 2 and maximim is 30!")]
        public string FoodName { get; set; }

        [Required]
        [RegularExpression(@"^\d$", ErrorMessage = "Enter only digits.")]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
