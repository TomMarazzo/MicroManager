using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Cart
    {
        public Guid CartId { get; set; } //PK

        public Guid ProductId { get; set; } //FK

        public DateTime DateCreated { get; set; }

        public string CustomerId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public virtual Product? Product { get; set; }

    }
}
