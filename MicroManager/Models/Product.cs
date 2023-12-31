using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroManager.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } //PK
        [Required]
        [Display(Name = "Seed Name")]
        public Guid Seed_Id{ get; set; } //FK
        [Display(Name = "Package Sizes")]
        public Guid Product_ProductSize_Id {  get; set; } //FK        
        [Display(Name = "Category")]
        public Guid InventoryCategory_Id { get; set; } //FK 
        public Guid ProductCategory_Id { get; set; } //FK 

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        //Link to Seed Types
        [ForeignKey(nameof(Seed_Id))]
        [ValidateNever]
        public virtual Seed? Seeds { get; set; }

        //Link to Product packageing Size
        [ForeignKey(nameof(Product_ProductSize_Id))]
        [ValidateNever]
        public virtual ProductSize? ProductSize { get; set; }

        //Link to Categories
        [ForeignKey(nameof(InventoryCategory_Id))]
        public virtual InventoryCategory? InventoryCategory { get; set; }

        [ForeignKey(nameof(ProductCategory_Id))]
        public virtual ProductCategory? ProductCategory { get; set; }

        //public virtual List<OrderDetail>? OrderDetails { get; set; }
        //public virtual List<Cart>? Carts { get; set; }
    }
}
