using RealEstatePortal.Application.Features.Listings.Commands;
using RealEstatePortal.Application.Features.Listings.Queries;

namespace RealEstatePortal.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddAllFeatures(this IServiceCollection services) =>
        services.AddListingFeature();

    private static IServiceCollection AddListingFeature(this IServiceCollection services) =>
        services
            .AddTransient<GetAllListings>()
            .AddTransient<CreateListing>();
}
