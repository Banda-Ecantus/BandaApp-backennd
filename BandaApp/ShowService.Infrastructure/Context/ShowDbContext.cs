using Microsoft.EntityFrameworkCore;

namespace ShowService.Infrastructure.Context
{
    public class ShowDbContext : DbContext
    {
        public ShowDbContext(DbContextOptions<ShowDbContext> options) : base(options){}
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Settings.PostgresConnectionString;
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
