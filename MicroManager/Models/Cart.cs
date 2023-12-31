﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Cart
    {
        public Guid CartId { get; set; } //PK

        public Guid Product_Id { get; set; } //FK
        public Guid Customer_Id { get; set; } //FK

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }
        [ForeignKey (nameof(Product_Id))]
        public virtual Product? Product { get; set; }

        [ForeignKey(nameof(Customer_Id))]
        public virtual Customer? Customer { get; set; }

        //public double Total
        //{
        //    get
        //    {
        //        if (Quantity >= 0 && Price >= 0)
        //        {
        //            return Quantity * Price;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}
    }
}
