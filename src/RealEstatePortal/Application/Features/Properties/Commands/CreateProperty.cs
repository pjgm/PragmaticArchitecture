using RealEstatePortal.Domain;
using RealEstatePortal.Infrastructure;

namespace RealEstatePortal.Application.Features.Properties.Commands;

public class CreateProperty
{
    private readonly RealEstateDbContext _dbContext;

    public CreateProperty(RealEstateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(Command command, CancellationToken ct)
    {
        var property = new Property(command.Area, command.Rooms, command.Floors);
        await _dbContext.Properties.AddAsync(property, ct);
        await _dbContext.SaveChangesAsync(ct);
        return property.Id;
    }

    public record Command(decimal Area, int Rooms, int Floors);
}
