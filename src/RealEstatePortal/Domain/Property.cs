namespace RealEstatePortal.Domain;

public class Property
{
    public Property(int rooms, decimal area, int floors)
    {
        Id = Guid.NewGuid();
        Rooms = rooms;
        Area = area;
        Floors = floors;
    }

    public Guid Id { get; private set; }
    public int Rooms { get; private set; }
    public decimal Area { get; private set; }
    public int Floors { get; private set; }

    public IEnumerable<Listing> Listings { get; } = new List<Listing>();
}
