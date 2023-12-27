using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MicroManager;

namespace MicroManager.Models
{
    public class Package
    {
        [Key]
        public Guid PackageId { get; set; } //PK
        public Guid Supplier_Id { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime Date { get; set; }
        public string PackageType { get; set; }

        [Display(Name = "Pack Size")]
        public int PackSize { get; set; }

        public int OrderQty { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public float Price { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public float Tax { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public float Total
        {
            get
            {
                if (Price >= 0 && OrderQty >= 0 && Tax >= 0)
                    return Price * Tax * OrderQty;
                return (float)Price;
            }
        }

        [ForeignKey(nameof(Supplier_Id))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
