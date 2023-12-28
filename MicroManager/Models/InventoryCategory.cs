using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class InventoryCategory
    {
        public Guid InventoryCategoryId { get; set; }
        [Display(Name = "Inventory Category")]
        public string InventoryCategoryType { get; set; } //Consumable-Fixed Invenotory
    }
}
