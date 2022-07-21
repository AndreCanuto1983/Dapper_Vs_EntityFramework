using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectDapperVsEntityFramework.Application.Interfaces;
using ProjectDapperVsEntityFramework.Application.Interfaces.Repository;
using ProjectDapperVsEntityFramework.Infra.Repository;

namespace ProjectDapperVsEntityFramework.Infra.Configuration
{
    public static class InterfaceConfigurations
    {
        public static void InterfaceSettings(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();            
            services.AddTransient<IUserEfRepository, UserEfRepository>();
            services.AddTransient<IUserRepository, UserRepository>();            
        }
    }
}
