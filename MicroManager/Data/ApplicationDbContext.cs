using MicroManager.Enums;
using MicroManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicroManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //*******************MUST ADD THIS SECTION TO FILE************************
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Model Relationships
        {
            base.OnModelCreating(modelBuilder);           

        }

        //***************MUST ADD DbSets HERE **************************
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Seed> Seeds { get; set; }
        public DbSet<Tray> Trays { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shelving> Shelving { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<GrowMedia> GrowMedias { get; set; }
        public DbSet<TypeMedia> TypeMedias { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }        
        public DbSet<InventoryCategory> InventoryCategories { get; set; }




    }
}
