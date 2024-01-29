using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Domain;
using RealEstatePortal.Infrastructure;

namespace RealEstatePortal.Application.Features.Listings.Queries;

public class ListListings
{
    private readonly RealEstateDbContext _dbContext;

    public ListListings(RealEstateDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Listing>> Handle(CancellationToken ct) =>
        await _dbContext.Listings.ToListAsync(ct);
}
