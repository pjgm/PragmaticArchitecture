namespace RealEstatePortal.Domain;

public class Property
{
    public Property(decimal area, int rooms, int floors)
    {
        Id = Guid.NewGuid();
        Area = area;
        Rooms = rooms;
        Floors = floors;
    }

    public Guid Id { get; private set; }
    public decimal Area { get; private set; }
    public int Rooms { get; private set; }
    public int Floors { get; private set; }

    public IEnumerable<Listing> Listings { get; } = new List<Listing>();
}
