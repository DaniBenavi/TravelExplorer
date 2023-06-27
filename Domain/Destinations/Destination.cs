using Domain.ValueObjects;

namespace Domain.Destinations;

public sealed class Destination
{
    public Destination(DestinationId id, string name, string description, string ubication, Money price)
    {
        Id = id;
        Name = name;
        Description = description;
        Ubication = ubication;
        Price = price;
    }

    private Destination()
    {

    }

    public DestinationId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Ubication { get; private set; } = string.Empty;
    public Money Price { get; private set; }

    public void Update(string name, string description, string ubication, Money price)
    {
        Name = name;
        Description = description;
        Ubication = ubication;
        Price = price;
    }
}