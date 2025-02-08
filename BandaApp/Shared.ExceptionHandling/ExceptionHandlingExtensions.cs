using Microsoft.AspNetCore.Builder;

namespace Shared.ExceptionHandling
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
