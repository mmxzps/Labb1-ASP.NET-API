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
        public string Description { get; set; }
        public FoodType FoodTypee { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; } = false;
        public string? ImgUrl { get; set; }

    }
    public enum FoodType
    {
        Appetizer,
        MainCourse,
        Dessert,
        Drinks
    }
}
