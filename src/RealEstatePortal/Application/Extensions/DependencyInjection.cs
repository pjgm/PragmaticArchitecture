using RealEstatePortal.Application.Features.Listings.Commands;
using RealEstatePortal.Application.Features.Listings.Queries;
using RealEstatePortal.Application.Features.Properties.Commands;
using RealEstatePortal.Application.Features.Properties.Queries;

namespace RealEstatePortal.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationFeatures(this IServiceCollection services) =>
        services
            .AddListingFeature()
            .AddPropertyFeature();

    private static IServiceCollection AddListingFeature(this IServiceCollection services) =>
        services
            .AddTransient<ListListings>()
            .AddTransient<CreateListing>();

    private static IServiceCollection AddPropertyFeature(this IServiceCollection services) =>
        services
            .AddTransient<ListProperties>()
            .AddTransient<CreateProperty>();
}
