using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MicroManager.Models
{
    public class ReportsViewModel
    {
        [Key]
        public int Id { get; set; } //Needs a PK
        public virtual List<Light> Lightings { get; set; } = new List<Light>();
        public virtual List<Package> Packages { get; set; } = new List<Package>();
        public virtual List<Shelving> Shelvings { get; set; } = new List<Shelving>();
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
