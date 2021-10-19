using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    /// <summary>
    /// AppDbContext 
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Order!)
                .HasForeignKey(p => p.OrderId);

            modelBuilder
               .Entity<Product>()
               .HasOne(p => p.Order)
               .WithMany(p => p.Products!)
               .HasForeignKey(p => p.OrderId);
        }
    }
}
