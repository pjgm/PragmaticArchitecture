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

    public async Task<Listing> Handle(Command command, CancellationToken cancellationToken)
    {
        var listing = new Listing(Guid.NewGuid(), command.Title, command.Description, command.Price);
        _dbContext.Listings.Add(listing);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return listing;
    }

    public record Command(string Title, string Description, decimal Price);
}
