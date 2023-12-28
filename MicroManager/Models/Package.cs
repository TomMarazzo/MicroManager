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
        [Display(Name = "Supplier")]
        public Guid Supplier_Id { get; set; } //FK
        [Display(Name = "Package Size")]
        public Guid Package_ProductSize_Id { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime Date { get; set; }
       
        
        [ForeignKey(nameof(Package_ProductSize_Id))]
        public virtual ProductSize? ProductSize{ get; set; }

        [Display(Name = "Qty Per Pack")]
        public int PackSize { get; set; }
        [Display(Name = "Order Qty")]
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

        public int TotalPackages
        {
            get
            {
                if (PackSize >= 0 && OrderQty >= 0 )
                    return PackSize * OrderQty;
                return 0;
            }
        }

        [ForeignKey(nameof(Supplier_Id))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
