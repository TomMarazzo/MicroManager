﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MicroManager.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MicroManager.Models
{
    public class GrowMedia
    {
        [Key]
        public Guid GrowMediaId { get; set; } //PK
        public Guid SupplierId { get; set; } //FK
        public GrowMediaTypesEnum GrowMediaTypesEnums { get; set; }


        [Display(Name = "Date Y-M-D")]
        public DateOnly Date { get; set; }
        [Display(Name = "Grow Media Types")]
        public string Type { get; set; }
        public float Volume { get; set; }

        [Display(Name = "Order Quantity")]
        public float OrderQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required]
        [Range(0.01, 999999)]
        public float Price { get; set; }
        public float Tax { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public float TotalPrice
        {
            get
            {
                if (Price >= 0 && OrderQty >= 0 && Tax >= 0)
                    return Price * Tax * OrderQty;
                return Price;
            }
        }

        public int TotalMediaQty
        {
            get
            {
                return (int)(Volume * OrderQty);
            }
        }

        

        [ForeignKey(nameof(SupplierId))]
        [ValidateNever]
        public virtual Supplier? Supplier { get; set; }

        

    }
}
