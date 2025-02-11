using InventoryService.Application.Services;
using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Context;
using InventoryService.Infrastructure.Repositories;
using InventoryService.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IInventoryItemService, InventoryItemService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            //services.AddScoped<IValidator, Validator>();
        }
    }
}
