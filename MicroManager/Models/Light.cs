using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Light
    {
        [Key]
        public Guid LightId { get; set; } //PK
        public Guid SupplierId { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        [Display(Name = "Qty")]
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

        [ForeignKey(nameof(SupplierId))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
