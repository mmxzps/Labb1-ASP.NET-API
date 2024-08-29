using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FoodName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
