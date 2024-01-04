using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Cart
    {
        public Guid CartId { get; set; } //PK

        public Guid Product_Id { get; set; } //FK
        public Guid Employee_Id { get; set; } //FK
        

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }


        [ForeignKey (nameof(Product_Id))]
        public virtual Product? Product { get; set; }

        [ForeignKey(nameof(Employee_Id))]
        public virtual Employee? Employee { get; set; }

        


    }
}
