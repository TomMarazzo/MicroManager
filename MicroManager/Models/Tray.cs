using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Tray
    {
        [Key]
        public Guid TrayId { get; set; } //PK
        [Display(Name = "Supplier")]
        public Guid Supplier_Id { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime Date { get; set; }
        public string Type { get; set; }

        [Display(Name = "Order Qty")]
        public float Qty { get; set; }
        [Display(Name = "Qty/Pack")]
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
                    return Price * Tax * Qty;
                return (float)Price;
            }
        }
        [Display(Name = "Tray Qty")]
        public float TotalTrays
        {
            get
            {
                if (Qty_pack >= 0)
                    return Qty_pack* Qty;
                return (int)TotalTrays;
            }
        }

        [ForeignKey(nameof(Supplier_Id))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
