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
        [Display(Name = "Date Y-M-D")]
        public DateTime Date { get; set; }

        public int Qty { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public float Price { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public float Tax { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public float Total
        {
            get
            {
                if (Price >= 0 && Qty >= 0 && Tax >= 0)
                    return Price * Tax * Qty;
                return (float)Price;
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }
        [Display(Name = "Total Grow Spaces")]
        public int TotalGrowSpaces
        {
            get
            {
                return Row * Column;
            }
        }

        [ForeignKey(nameof(SupplierId))]
        [ValidateNever]

        public virtual Supplier? Supplier { get; set; }
    }
}