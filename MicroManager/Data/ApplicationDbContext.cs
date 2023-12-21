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


            ////Crop and CustomerOrderDetail
            //modelBuilder.Entity<CustomerOrderDetail>()
            //    .HasOne(p => p.Crop);

            ////CustomerOrderDetail and CustomerOrder
            //modelBuilder.Entity<CustomerOrderDetail>()
            //    .HasOne(p => p.CustomerOrder);

            //Crop and Inventory
            //modelBuilder.Entity<Crop>()
            //    .HasOne(p => p.)
            //    .WithMany(p => p.Products)
            //    .HasForeignKey(p => p.CategoryId)
            //    .HasConstraintName("FK_Products_CategoryID");

        }

        //***************MUST ADD DbSets HERE **************************
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Seed> Seeds { get; set; }
        public DbSet<Tray> Trays { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
