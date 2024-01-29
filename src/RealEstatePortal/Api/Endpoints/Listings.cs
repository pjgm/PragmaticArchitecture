using RealEstatePortal.Application.Features.Listings.Commands;
using RealEstatePortal.Application.Features.Listings.Queries;
using RealEstatePortal.Domain;

namespace RealEstatePortal.Api.Endpoints;

public static class Listings
{
    public static void MapListings(this IEndpointRouteBuilder endpoints)
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
    }

    private static async Task<IResult> Create(CreateListing.Command command, CreateListing createListing, CancellationToken ct)
    {
        var listing = await createListing.Handle(command, ct);
        return Results.Created($"/listing/{listing.Id}", listing);
    }

    private static async Task<IEnumerable<Listing>> List(GetAllListings getAllListings, CancellationToken ct) =>
        await getAllListings.Handle(ct);
}
