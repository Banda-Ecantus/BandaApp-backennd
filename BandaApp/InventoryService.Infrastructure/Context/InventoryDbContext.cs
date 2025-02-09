using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InventoryService.Infrastructure.Context
{
    public class InventoryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options, IConfiguration configuration) : base(options) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
