using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Order
    {
        public Guid OrderId { get; set; } //PK
        public DateOnly OrderDate { get; set; }
        public string CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public double Total { get; set; }
        //Child reference 
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
