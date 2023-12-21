using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

        public virtual Product? Product { get; set; }

        public double Total
        {
            get
            {
                if (Quantity >= 0 && Price >= 0)
                {
                    return Quantity * Price;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
