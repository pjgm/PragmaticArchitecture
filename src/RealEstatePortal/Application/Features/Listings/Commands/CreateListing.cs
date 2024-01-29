using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Domain;
using RealEstatePortal.Infrastructure;

namespace RealEstatePortal.Application.Features.Listings.Commands;

public class CreateListing
{
    private readonly RealEstateDbContext _dbContext;

    public CreateListing(RealEstateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(Command command, CancellationToken ct)
    {
        Property property;

        if (command.PropertyId.HasValue)
        {
            property = await _dbContext.Properties.FirstAsync(p => p.Id == command.PropertyId, ct);
        }
        else
        {
            if (command.Property is null)
            {
                throw new ArgumentNullException(nameof(command.Property));
            }
            property = new Property(command.Property.Area, command.Property.Rooms, command.Property.Floors);
        }


        var listing = new Listing(command.Title, command.Description, command.Price, property);

        await _dbContext.Listings.AddAsync(listing, ct);
        await _dbContext.SaveChangesAsync(ct);
        return listing.Id;
    }

    public record Command(string Title, string Description, decimal Price, Guid? PropertyId, PropertyDto? Property);
    public record PropertyDto(decimal Area, int Rooms, int Floors);
}
