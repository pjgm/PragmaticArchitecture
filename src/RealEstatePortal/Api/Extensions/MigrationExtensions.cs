using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Application.Configuration;
using RealEstatePortal.Application.Extensions;
using RealEstatePortal.Infrastructure;


namespace RealEstatePortal.Api.Extensions;

public static class MigrationExtensions
{
    public static async Task<WebApplication> RunMigrations(this WebApplication builder, IConfiguration configuration)
    {
        var dbOptions = configuration.GetSection<DatabaseOptions>(DatabaseOptions.SectionName);
        if (!dbOptions.RunMigrations)
        {
            return builder;
        }

        using var scope = builder.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<RealEstateDbContext>();
        await dbContext.Database.MigrateAsync();
        return builder;
    }
}
