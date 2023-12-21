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
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(CropId))]
        [ValidateNever]
        public virtual Crop? Crop { get; set; }


    }
}
