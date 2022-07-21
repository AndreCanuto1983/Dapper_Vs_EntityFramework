using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDapperVsEntityFramework.Application.Entities;

namespace ProjectDapperVsEntityFramework.Infra.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    UserName = "master@canuto.com",
                    Email = "master@canuto.com",
                    LockoutEnabled = true,
                    Name = "Master",
                    EmailConfirmed = true,
                    Cpf = "00000000000"                    
                });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {                    
                    Id = "1",
                    Name = "Master",
                    NormalizedName = "MASTER"                    
                });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "3",
                    Name = "Commom",
                    NormalizedName = "COMMOM"
                });
        }
    }
}
