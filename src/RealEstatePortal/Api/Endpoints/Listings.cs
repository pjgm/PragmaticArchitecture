using RealEstatePortal.Application.Features.Listings.Commands;
using RealEstatePortal.Application.Features.Listings.Queries;
using RealEstatePortal.Domain;

namespace RealEstatePortal.Api.Endpoints;

public static class Listings
{
    public static IEndpointRouteBuilder MapListings(this IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapGet("/listings", List)
            .Produces<IEnumerable<Listing>>()
            .WithName("GetAllListings")
            .WithTags("List")
            .WithOpenApi();

        endpoints
            .MapPost("/listing", Create)
            .Produces<Listing>()
            .WithName("CreateListing")
            .WithTags("Create")
            .WithOpenApi();

        return endpoints;
    }

    private static async Task<IResult> Create(
        CreateListing.Command command,
        CreateListing handler,
        CancellationToken ct)
    {
        var listingId = await handler.Handle(command, ct);
        return Results.Created($"/listing/{listingId}", listingId);
    }

    private static async Task<IEnumerable<Listing>> List(
        ListListings handler,
        CancellationToken ct) =>
        await handler.Handle(ct);
}
