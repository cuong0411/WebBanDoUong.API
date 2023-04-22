﻿using System.ComponentModel.DataAnnotations;

namespace WebBanDoUong.UI.Models.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        // Navigation property
        public virtual Category Category { get; set; }
    }
}
