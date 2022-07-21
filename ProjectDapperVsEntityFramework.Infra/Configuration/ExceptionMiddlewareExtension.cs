using Microsoft.AspNetCore.Builder;
using ProjectDapperVsEntityFramework.Infra.Services;

namespace ProjectDapperVsEntityFramework.Infra.Configuration
{
    public static class ExceptionMiddlewareExtension
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
