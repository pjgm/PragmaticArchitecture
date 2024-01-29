using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Infrastructure;

namespace RealEstatePortal.Application.Features.Properties.Queries;

public class ListProperties
{
    private readonly RealEstateDbContext _dbContext;

    public ListProperties(RealEstateDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<ResponseDto>> Handle(CancellationToken ct)
    {
        var properties = await _dbContext.Properties.ToListAsync(ct);
        return properties.Select(p => new ResponseDto(p.Area, p.Rooms, p.Floors));
    }

    public record ResponseDto(decimal Area, int Rooms, int Floors);
}
