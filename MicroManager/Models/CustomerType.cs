using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class CustomerType //MANY Types
    {
        [Key]
        public Guid CustomerTypeId { get; set; } //PK
        public Guid CustomerId { get; set; } //FK

        [Display(Name = "Customer Type")]
        public string Type { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customers { get; set; }

    }
}
