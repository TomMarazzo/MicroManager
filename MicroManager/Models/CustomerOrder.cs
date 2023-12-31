using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class CustomerOrder
    {
        [Key]
        public Guid CustomerOrderId { get; set; } //PK
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid Customer_Id { get; set; }//FK

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string Phone { get; set; }
        public string email { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public float Price { get; set; }

        public int Quantity { get; set; }
        public float Tax { get; set; }


        [ForeignKey(nameof(Customer_Id))]
        [ValidateNever]
        public virtual Customer? Customers { get; set; }

        //Child reference 
        public virtual List<OrderDetail>? OrderDetails { get; set; }


        //Calculations 
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
