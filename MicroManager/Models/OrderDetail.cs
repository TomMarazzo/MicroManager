using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; } //PK
        public Guid ProductId { get; set; } //FK
        public Guid OrderId { get; set; } //FK
        public int Quantity { get; set; }
        public float Price { get; set; }              
       
    }
}
