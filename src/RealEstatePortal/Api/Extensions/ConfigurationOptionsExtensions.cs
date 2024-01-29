using RealEstatePortal.Application.Configuration;

namespace RealEstatePortal.Api.Extensions;

public static class ConfigurationOptionsExtensions
{
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
}
