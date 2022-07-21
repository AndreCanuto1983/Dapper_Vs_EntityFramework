using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDapperVsEntityFramework.Application.Entities;
using ProjectDapperVsEntityFramework.Infra.Context;
using System.Linq;

namespace ProjectDapperVsEntityFramework.Infra.Configuration
{
    public static class SeedData
    {
        private const string group = "MASTER";

        public static void Initialize(ApplicationDbContext context, UserManager<UserModel> userManager)
        {
            if (context.User.AsNoTracking().Where(u => u.Email == "master@canuto.com" && string.IsNullOrEmpty(u.PasswordHash)).Count() > 0)
            {
                var user = context.Users.AsNoTracking().Where(u => u.Email.Equals("master@canuto.com")).FirstOrDefault();
                userManager.AddPasswordAsync(user, group);
                context.SaveChanges();
            }

            if (!context.UserRoles.AsNoTracking().Any())
            {
                var userId = context.User.AsNoTracking()
                    .Where(u => u.Email == "master@canuto.com")
                    .Select(u => u.Id)
                    .FirstOrDefault();

                var roleId = context.Roles.AsNoTracking()
                    .Where(r => r.NormalizedName == group)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                if(!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(roleId))
                {
                    context.UserRoles.Add(entity: new IdentityUserRole<string> { UserId = userId, RoleId = roleId });
                    context.SaveChanges();
                }                
            }

            userManager.Dispose();
        }
    }
}
