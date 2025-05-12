using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions;

public static class WebApplicationExtensions
{
    public static async Task ApplyMigrations(this WebApplication app)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        try
        {
            using var scope = app.Services.CreateScope();
            var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await applicationContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occured during startup migration");
        }
    }
}