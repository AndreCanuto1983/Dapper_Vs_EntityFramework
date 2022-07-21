using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectDapperVsEntityFramework.Application.Entities;
using ProjectDapperVsEntityFramework.Infra.Context;
using ProjectDapperVsEntityFramework.Infra.Services;

namespace ProjectDapperVsEntityFramework.Infra.Configuration
{
    public static class ContextExtension
    {
        public static void ContextSettings(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                     
            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<DapperContext>();

            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
