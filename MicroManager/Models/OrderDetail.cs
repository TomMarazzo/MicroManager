using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; } //PK
        public Guid Product_Id { get; set; } //FK
        public Guid CustomerOrder_Id { get; set; } //FK
        public int Quantity { get; set; }
        public double Price { get; set; }

        [Display(Name = "Customer Type")]
        [ForeignKey(nameof(CustomerOrder_Id))]
        [ValidateNever]
        public virtual CustomerOrder? CustomerOrders { get; set; }

        [Display(Name = "Customer Type")]
        [ForeignKey(nameof(Product_Id))]
        [ValidateNever]
        public  virtual Product? Product { get; set; }

    }
}
