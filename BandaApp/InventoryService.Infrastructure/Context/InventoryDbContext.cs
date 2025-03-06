using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;

namespace InventoryService.Infrastructure.Context
{
    public class InventoryDbContext : DbContext
    {

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Settings.PostgresConnectionString;
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
