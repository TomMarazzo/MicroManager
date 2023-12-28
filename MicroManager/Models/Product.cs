using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Product
    {
        public Guid ProductId { get; set; } //PK
        [Required]
        [Display(Name = "Seed Name")]
        public Guid Seed_Id{ get; set; } //FK
        [Display(Name = "Package Sizes")]
        public Guid Product_ProductSize_Id {  get; set; } //FK        
        
        [Display(Name = "Weight (oz)")]
        
        public double? Weight { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        
        [ForeignKey(nameof(Product_ProductSize_Id))]
        [ValidateNever]
        public virtual ProductSize? ProductSize { get; set; }

        [ForeignKey(nameof(Seed_Id))]
        [ValidateNever]
        public virtual Seed? Seeds { get; set; }
    }
}
