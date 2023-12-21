using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class ProductSize
    {
        public Guid ProductSizeId { get; set; }
        
        public string Size { get; set; }

        public virtual List<ProductSize>? ProductSizes { get; set; }
    }
}
