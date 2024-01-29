using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Application.Configuration;
using RealEstatePortal.Application.Extensions;

namespace RealEstatePortal.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbOptions = configuration.GetSection<DatabaseOptions>(DatabaseOptions.SectionName);

        services.AddDbContext<RealEstateDbContext>(options =>
        {
            options.UseNpgsql(dbOptions.GetConnectionString());
        });

        return services;
    }
}
