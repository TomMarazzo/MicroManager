using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class CustomerType //MANY Types
    {
        [Key]
        public Guid Id { get; set; } //PK
        

        [Display(Name = "Customer Type")]
        public string Type { get; set; }

        public virtual List<Customer>? Customers { get; set; } //Need this to make the dropdown list in Customers for Types

    }
}
