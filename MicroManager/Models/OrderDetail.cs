namespace MicroManager.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; } //PK
        public Guid ProductId { get; set; } //FK
        public Guid OrderId { get; set; } //FK
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Order? Order { get; set; }

        public virtual Product? Product { get; set; }

    }
}
