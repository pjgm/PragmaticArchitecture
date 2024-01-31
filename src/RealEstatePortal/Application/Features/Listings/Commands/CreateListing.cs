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
        var property = await _dbContext.Properties.FirstAsync(p => p.Id == command.PropertyId, ct);
        var listing = new Listing(command.Title, command.Description, command.Price, property);

        await _dbContext.Listings.AddAsync(listing, ct);
        await _dbContext.SaveChangesAsync(ct);
        return listing.Id;
    }

    public record Command(string Title, string Description, decimal Price, Guid PropertyId);
}
