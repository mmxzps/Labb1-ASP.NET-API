﻿namespace Labb1_ASP.NET_API.Models.DTOs.Menu
{
    public class CreateMenuDTO
    {
        public string FoodName { get; set; }

        public double Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}