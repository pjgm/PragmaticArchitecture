using RealEstatePortal.Application.Features.Properties.Commands;
using RealEstatePortal.Application.Features.Properties.Queries;
using RealEstatePortal.Domain;

namespace RealEstatePortal.Api.Endpoints;

public static class Properties
{
    public static void MapProperties(this IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapGet("/properties", List)
            .Produces<IEnumerable<Property>>()
            .WithName("GetAllProperties")
            .WithTags("List")
            .WithOpenApi();

        endpoints
            .MapPost("/property", Create)
            .Produces<string>()
            .WithName("CreateProperty")
            .WithTags("Create")
            .WithOpenApi();
    }

    private static async Task<IResult> List(ListProperties handler, CancellationToken ct) =>
        Results.Ok(await handler.Handle(ct));

    private static async Task<IResult> Create(
        CreateProperty.Command command,
        CreateProperty createProperty,
        CancellationToken ct)
    {
        var propertyId = await createProperty.Handle(command, ct);
        return Results.Created($"/property/{propertyId}", propertyId);
    }
}
