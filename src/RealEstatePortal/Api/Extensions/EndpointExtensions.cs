using RealEstatePortal.Api.Endpoints;

namespace RealEstatePortal.Api.Extensions;

public static class EndpointExtensions
{
    public static void MapAllEndpoints(this WebApplication app) =>
        app
            .MapListings()
            .MapProperties();
}
