using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; } //PK
        public Guid Product_Id { get; set; } //FK
        public Guid Order_Id { get; set; } //FK
        
        public int Quantity { get; set; }
        public float Price { get; set; }

        [ForeignKey(nameof(Product_Id))]        
        public virtual Product? Products { get; set; }

        [ForeignKey(nameof(Order_Id))]        
        public virtual Order? Orders { get; set; }

        

    }
}
