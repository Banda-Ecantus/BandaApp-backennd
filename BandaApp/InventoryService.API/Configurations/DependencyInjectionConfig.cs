
using InventoryService.Infrastructure.CrossCutting.IoC.IoC;

namespace InventoryService.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            NativeInjectorBootStrapper.RegisterDbContext(services, configuration);
            NativeInjectorBootStrapper.RegisterServices(services);
            NativeInjectorBootStrapper.RegisterRepositories(services);
            NativeInjectorBootStrapper.RegisterValidators(services);
        }
    }
}
