using Domain.Primitives;

namespace Domain.Destinations;

public sealed class Destination : AgregateRoot
{
    public Destination(DestinationId id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    private Destination()
    {

    }
    public DestinationId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; }

}