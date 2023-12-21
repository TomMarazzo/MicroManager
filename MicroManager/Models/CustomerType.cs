using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class CustomerType //MANY Types
    {
        [Key]
        public Guid CustomerTypeId { get; set; } //PK
        

        [Display(Name = "Customer Type")]
        public string Type { get; set; }

       

    }
}
