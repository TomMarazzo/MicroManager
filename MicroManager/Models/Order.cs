using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Order
    {
        public Guid OrderId { get; set; } //PK
        public DateOnly OrderDate { get; set; }
        public Guid CustomerId { get; set; }//FK
        public Guid ProductId { get; set; } //FK

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        [ValidateNever]
        public virtual Product? Product { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [ValidateNever]
        public virtual Customer? Customer { get; set; }
        //Child reference 
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
