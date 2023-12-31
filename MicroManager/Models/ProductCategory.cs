using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryId { get; set; } //PK
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }        
        
    }
}
