﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Tray
    {
        [Key]
        public Guid TrayId { get; set; } //PK
        public Guid Supplier_Id { get; set; } //FK
        [Display(Name = "Date Y-M-D")]
        public DateTime Date { get; set; }
        public string Type { get; set; }

        [Display(Name = "Qty (g)")]
        public float Qty { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Tax { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }

        [ForeignKey(nameof(Supplier_Id))]
        //[ValidateNever]
        public virtual Supplier? Supplier { get; set; }
    }
}
