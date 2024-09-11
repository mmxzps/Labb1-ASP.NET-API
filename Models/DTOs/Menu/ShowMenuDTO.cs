using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs.Menu
{
    public class ShowMenuDTO
    {
        public int Id { get; set; }

        public string FoodName { get; set; }
        public string Description { get; set; }

        public FoodType FoodTypee { get; set; }

        public double Price { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsPopular { get; set; }

        public string? ImgUrl { get; set; }

    }
}
