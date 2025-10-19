using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Domain;

namespace RealEstatePortal.Infrastructure;

public class RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    public required DbSet<Listing> Listings { get; set; }
    public required DbSet<Property> Properties { get; set; }
}
