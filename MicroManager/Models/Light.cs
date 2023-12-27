using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Light
    {
        [Key]
        public Guid LightId { get; set; } //PK
        public Guid Supplier_Id { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        [Display(Name = "Qty")]
        public int OrderQty { get; set; }

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
