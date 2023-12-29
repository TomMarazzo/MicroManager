using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } //PK
        public DateTime OrderDate { get; set; }
        public Guid Customer_Id { get; set; }//FK
        public Guid Product_Id { get; set; }//FK

        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Price { get; set; }

        public int Quantity { get; set; }
        public float Tax { get; set; }


        [ForeignKey(nameof(Customer_Id))]
        [ValidateNever]
        public virtual Customer? Customer { get; set; }
       
        

        //Child reference 
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

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
