namespace RealEstatePortal.Domain;

public class Property(decimal area, int rooms, int floors)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public decimal Area { get; private set; } = area;
    public int Rooms { get; private set; } = rooms;
    public int Floors { get; private set; } = floors;

    public IEnumerable<Listing> Listings { get; } = new List<Listing>();
}
