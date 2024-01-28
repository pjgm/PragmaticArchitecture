using RealEstatePortal.Domain;

namespace RealEstatePortal.Api.Extensions;

public static class EndpointExtensions
{
    public static void MapAllEndpoints(this WebApplication app)
    {
        app.MapListings();
    }

    private static void MapListings(this WebApplication app)
    {
        app.MapGet("/listings", async (HttpContext context) =>
        {
            var listings = new List<Listing>
            {
                new(Guid.NewGuid(), "Listing 1", "Description 1", 100000),
                new(Guid.NewGuid(), "Listing 2", "Description 2", 200000),
                new(Guid.NewGuid(), "Listing 3", "Description 3", 300000),
                new(Guid.NewGuid(), "Listing 4", "Description 4", 400000),
                new(Guid.NewGuid(), "Listing 5", "Description 5", 500000),
            };

            await context.Response.WriteAsJsonAsync(listings);
        });
    }
}
