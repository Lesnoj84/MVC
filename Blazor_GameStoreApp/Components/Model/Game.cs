﻿using System.ComponentModel.DataAnnotations;

namespace Blazor_GameStoreApp.Components.Model
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required"), MinLength(2), MaxLength(50)]

        public string? Name { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public enumGameGenre Genre { get; set; }

        [Range(1, 100, ErrorMessage = "Price is required 1-100")]
        public decimal Price { get; set; }
        public DateOnly ReleasedDate { get; set; }

    }
}
