using Domain.Primitives;

namespace Domain.Destinations;

public sealed class Destination : AgregateRoot
{
    public Destination(DestinationId id, string name, string description, string ubication)
    {
        Id = id;
        Name = name;
        Description = description;
        Ubication = ubication;

    }

    private Destination()
    {

    }
    public DestinationId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; }
    public string Ubication { get; private set; }

}