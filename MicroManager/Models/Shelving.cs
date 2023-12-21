using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Shelving
    {
        [Key]
        public Guid ShelvingId { get; set; }//PK
        public Guid SupplierId { get; set; } //FK
        public int Row { get; set; }
        public int Column { get; set; }
        [Display(Name = "Total Grow Spaces")]
        public int TotalGrowSpaces { get; set; }

        [ForeignKey(nameof(SupplierId))]
        [ValidateNever]

        public virtual Supplier? Supplier { get; set; }
    }
}