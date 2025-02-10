
using InventoryService.Infrastructure.CrossCutting.IoC.IoC;
using Shared.Infrastructure;

namespace InventoryService.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            NativeInjectorBootStrapper.RegisterDbContext(services);
            NativeInjectorBootStrapper.RegisterServices(services);
            NativeInjectorBootStrapper.RegisterRepositories(services);
            NativeInjectorBootStrapper.RegisterValidators(services);
        }
    }
}
