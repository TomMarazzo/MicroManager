using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Product
    {
        public Guid ProductId { get; set; } //PK
        [Required]
        public Guid CropId{ get; set; } //FK
        public Guid ProductSizeId {  get; set; } //FK
        
        public virtual Crop? Crop { get; set; }
        [Display(Name = "Weight (oz)")]
        
        public double? Weight { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        
        [ForeignKey(nameof(ProductSizeId))]
        [ValidateNever]
        public virtual ProductSize? ProductSize { get; set; }

        [ForeignKey(nameof(CropId))]
        [ValidateNever]
        public virtual Crop? Crops { get; set; }
    }
}
