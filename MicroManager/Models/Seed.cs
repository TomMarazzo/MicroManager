using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Seed
    {
        [Key]
        public Guid SeedId { get; set; } //PK
        public Guid SupplierId { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateOnly Date { get; set; }
        public string Type { get; set; }

        [Display(Name = "Qty (g)")]
        public float Qty { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required]
        [Range(0.01, 999999)]
        public double Price { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }

        [ForeignKey(nameof(SupplierId))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
