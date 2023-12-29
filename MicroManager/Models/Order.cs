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
        

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

        public int Quantity { get; set; }

       
        [ForeignKey(nameof(Customer_Id))]
        [ValidateNever]
        public virtual Customer? Customer { get; set; }
        

        //Child reference 
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
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
