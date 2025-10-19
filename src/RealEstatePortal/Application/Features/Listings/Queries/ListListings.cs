using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Domain;
using RealEstatePortal.Infrastructure;

namespace RealEstatePortal.Application.Features.Listings.Queries;

public class ListListings(RealEstateDbContext dbContext)
{
    public async Task<IEnumerable<Listing>> Handle(CancellationToken ct) =>
        await dbContext.Listings.ToListAsync(ct);
}
