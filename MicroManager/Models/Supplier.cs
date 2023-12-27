using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class Supplier //ONE Supplier
    {
        [Key]
        [Display(Name = "Supplier")]
        public Guid SupplierId { get; set; }
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
        [Required]
        public string email { get; set; }
        public string URL { get; set; }
        public virtual List<Shelving>? Shelvings { get; set; }
        public virtual List<Seed>? Seeds { get; set; }
        public virtual List<Tray>? Trays { get; set; }
        public virtual List<Light>? Lights { get; set; }
        public virtual List<Package>? Packages { get; set; }
        public virtual List<GrowMedia>? GrowMedias { get; set; }
       
    }
}
