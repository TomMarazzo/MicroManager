using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class GrowMediaType
    {
        [Key]
        public Guid GMTypeId { get; set; } //PK


        [Display(Name = "Grow Media Type")]
        public string Type { get; set; }

        public virtual List<GrowMedia>? GrowMedias { get; set; } //Need this to make the dropdown list in Customers for Types
    }
}
