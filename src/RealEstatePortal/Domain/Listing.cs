namespace RealEstatePortal.Domain;

public class Listing
{
    public Listing(string title, string description, decimal price)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Price = price;
    }

    public Listing(string title, string description, decimal price, Property property)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Price = price;
        Property = property;
    }


    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Property Property { get; init; } = null!;
}
