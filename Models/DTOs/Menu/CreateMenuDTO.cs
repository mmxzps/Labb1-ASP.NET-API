using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs.Menu
{
    public class CreateMenuDTO
    {
        [Required(ErrorMessage = "Food name is required.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Food name must be between 2 and 30 characters.")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select a valid food type.")]
        public FoodType FoodTypee { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Availability status is required.")]
        public bool IsAvailable { get; set; }

        public string? ImgUrl { get; set; }
    }

}
