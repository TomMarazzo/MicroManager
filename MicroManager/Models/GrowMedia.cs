using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class GrowMedia
    {
        [Key]
        public Guid GrowMediaId { get; set; } //PK
        public Guid SupplierId { get; set; } //FK
        public Guid GMTypeId { get; set; } //FK

        [Display(Name = "Date Y-M-D")]
        public DateOnly Date { get; set; }
        public string Type { get; set; }
        public float Volume { get; set; }

        [Display(Name = "Order Quantity")]
        public int OrderQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required]
        [Range(0.01, 999999)]
        public float Price { get; set; }
        public float Tax { get; set; }
        public float Total
        {
            get
            {
                if (Price >= 0 && OrderQty >= 0 && Tax >= 0)
                    return Price * Tax * OrderQty;
                return (float)Price;
            }
        }

        [ForeignKey(nameof(GMTypeId))]
        //[ValidateNever]
        public virtual GrowMediaType? GrowMediaType { get; set; }

        [ForeignKey(nameof(SupplierId))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
