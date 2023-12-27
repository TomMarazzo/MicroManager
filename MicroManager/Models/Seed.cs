using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Seed
    {
        [Key]
        public Guid SeedId { get; set; } //PK
        public Guid Supplier_Id { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime Date { get; set; }
        public string Type { get; set; }

        [Display(Name = "No. of Packs")]
        public float Qty { get; set; }

        [Display(Name = "Qty/Pack (g)")]
        public float Qty_pack { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required]
        [Range(0.01, 999999)]
        public float Price { get; set; }

        public float Tax { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Total
        {
            get
            {
                if (Price >= 0 && Qty >= 0 && Tax >= 0)
                    return (Price * Tax * Qty);
                return (float)Price;
            }
        }
        [Display(Name = "Qty of Order - kg")]
        public float TotalQuantity
        {
            get
            {
                if (Qty_pack >= 0)
                    return (Qty_pack * Qty)/1000;
                return TotalQuantity;
            }
        }

            [ForeignKey(nameof(Supplier_Id))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
