using ShowService.Infrastructure.IoC;

namespace ShowService.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            NativeInjectorBootStrapper.RegisterDbContext(services);
            NativeInjectorBootStrapper.RegisterServices(services);
            NativeInjectorBootStrapper.RegisterRepositories(services);
            NativeInjectorBootStrapper.RegisterValidators(services);
            NativeInjectorBootStrapper.RegisterAutoMapper(services);
        }
    }
}
