﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class CustomerOrder
    {
        [Key]
        public Guid CustomerOrderId { get; set; } //PK
        public Guid Customer_Id { get; set; }//FK
        public Guid Product_Id { get; set; }//FK
        public DateTime OrderDate { get; set; }
        

        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Price { get; set; }

        public int Quantity { get; set; }
        public float Tax { get; set; }


        [ForeignKey(nameof(Customer_Id))]
        [ValidateNever]
        public virtual Customer? Customer { get; set; }

        [ForeignKey(nameof(Product_Id))]
        [ValidateNever]
        public virtual List<Product>? Product { get; set; } //Customer has MANY products

        
        //Child reference 


        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Total
        {
            get
            {
                if (Price >= 0 && Quantity >= 0 && Tax >= 0)
                    return Price * Tax * Quantity;
                return (float)Price;
            }
        }
    }
}
