﻿using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class InventoryCategory
    {
        [Key]
        public Guid InventoryCategoryId { get; set; }
        [Display(Name = "Inventory Category")]
        public string InventoryCategoryType { get; set; } //Consumable-Fixed Invenotory
        public virtual List<Product>? Products { get; set; } //1 Category, Many Products - LIST
    }
}
