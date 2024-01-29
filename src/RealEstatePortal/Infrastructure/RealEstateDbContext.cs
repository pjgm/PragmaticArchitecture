using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Domain;

namespace RealEstatePortal.Infrastructure;

public class RealEstateDbContext : DbContext
{
    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    public DbSet<Listing> Listings { get; set; }
}
