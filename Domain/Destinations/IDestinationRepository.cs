namespace Domain.Destinations;

public interface IDestinationRepository
{
    Task<Destination?> GetByIdAsync(DestinationId id);

    void Add(Destination destination);

    void Update(Destination destination);

    void Remove(Destination destination);


}