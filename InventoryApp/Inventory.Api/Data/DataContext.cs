using InventoryApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
        }
    }
}