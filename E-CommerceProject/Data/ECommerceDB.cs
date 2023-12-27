using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_CommerceProject.Models;

namespace E_CommerceProject.Data
{
    public class ECommerceDB : IdentityDbContext<ApplicationUser>
    {
        public ECommerceDB(DbContextOptions<ECommerceDB> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method first

            // Configure the precision for decimal properties
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderTotal)
                .HasColumnType("decimal(18, 2)"); // or use HasPrecision(18, 2)

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Price)
                .HasColumnType("decimal(18, 2)"); // or use HasPrecision(18, 2)

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)"); // or use HasPrecision(18, 2)

            // ... Other configurations ...
        }
    }
}