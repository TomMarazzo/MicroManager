using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Cart
    {
        public Guid CartId { get; set; } //PK

        public Guid Product_Id { get; set; } //FK
        public string Employee_Id { get; set; } //FK

        public Guid Customer_Id { get; set; } //FK


        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Price { get; set; }

        public float Tax { get; set; }


        [ForeignKey (nameof(Product_Id))]
        public virtual Product? Product { get; set; }

        [ForeignKey(nameof(Employee_Id))]
        public virtual IdentityUser ? Employee { get; set; }

        [ForeignKey(nameof(Customer_Id))]
        public virtual Customer? Customer { get; set; }

        //**********Calculations*********

        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Total
        {
            get
            {
                if (Price >= 0 && Quantity >= 0 && Tax >= 0)
                    return (Price * Tax * Quantity);
                return (float)Price;
            }
        }
        



    }
}
