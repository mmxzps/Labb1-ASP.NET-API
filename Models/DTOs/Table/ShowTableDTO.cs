﻿using System.ComponentModel.DataAnnotations;

namespace Labb1_ASP.NET_API.Models.DTOs.Table
{
    public class ShowTableDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int TableSeats { get; set; }
    }
}