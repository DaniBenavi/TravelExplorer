using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Destinations;

public sealed class Destination : AgregateRoot
{
    public Destination(DestinationId id, Sku sku, string name, Money price)
    {
        Id = id;
        Sku = sku;
        Name = name;
        Price = price;
    }

    private Destination()
    {

    }
    public DestinationId Id { get; private set; }
    public Sku Sku { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Money Price { get; private set; }

}