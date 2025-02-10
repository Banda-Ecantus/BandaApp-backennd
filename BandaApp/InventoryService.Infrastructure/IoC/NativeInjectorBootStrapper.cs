using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using InventoryService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;

namespace InventoryService.Infrastructure.CrossCutting.IoC.IoC
{
    public static class NativeInjectorBootStrapper
    {

        public static void RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseNpgsql(Settings.PostgresConnectionString));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IService, Service>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            //services.AddScoped<IValidator, Validator>();
        }
    }
}
