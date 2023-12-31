using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryId { get; set; } //PK
        [Required]
        public string ProductName { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; }= DateTime.Now;
    }
}
