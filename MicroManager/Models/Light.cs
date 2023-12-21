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
        public DateOnly Date { get; set; }
        public string Type { get; set; }

        [Display(Name = "Qty (g)")]
        public float Size { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Tax { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }

        [ForeignKey(nameof(SupplierId))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
