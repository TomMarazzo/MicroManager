﻿namespace MicroManager.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } //PK
        public int ProductId { get; set; } //FK
        public int OrderId { get; set; } //FK
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
