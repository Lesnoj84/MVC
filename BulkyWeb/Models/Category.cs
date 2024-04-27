﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string?  Name { get; set; }
        public int DisplayOrder { get; set; }

    }
}
