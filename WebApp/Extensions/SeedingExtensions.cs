using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Extensions;

public static class SeedingLocalExtension
{
    public static async Task SeedDataAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();


        string[] roles = ["Admin", "User"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new Role(role));
            }
        }

        var user = await userManager.FindByEmailAsync("user@user.com");
        if (user == null)
        {
            user = new User
            {
                UserName = "user@user.com",
                FirstName = "KobMiles",
                LastName = "KobMiles",
                Email = "user@user.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, "123123");
            await userManager.AddToRoleAsync(user, "User");
        }

        var admin = await userManager.FindByEmailAsync("admin@admin.com");
        if (admin == null)
        {
            admin = new User
            {
                UserName = "admin@admin.com",
                FirstName = "Nikita",
                LastName = "Kobylynskyi",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(admin, "123123");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}