﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class ProductSize
    {
        [Key]
        public Guid ProductSizeId { get; set; }
        
        public string Size { get; set; }
        
    }
}
