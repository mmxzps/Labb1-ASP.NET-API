﻿namespace Labb1_ASP.NET_API.Models.DTOs.Menu
{
    public class EditMenuDTO
    {
        public string FoodName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
        public FoodType FoodTypee { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsPopular { get; set; }

        public string? ImgUrl { get; set; }

    }
}
