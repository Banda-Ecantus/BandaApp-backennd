using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShowService.Application.Interfaces;
using ShowService.Domain.Interfaces;
using ShowService.Infrastructure.Context;
using ShowService.Infrastructure.Repositories;

namespace ShowService.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ShowDbContext>(options =>
                options.UseNpgsql(Settings.PostgresConnectionString));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IShowService, ShowService.Application.Services.ShowService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShowRepository, ShowRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            //services.AddScoped<IValidator, Validator>();
        }
        public static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
