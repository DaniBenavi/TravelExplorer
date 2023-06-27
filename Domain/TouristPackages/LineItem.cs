using Domain.Destinations;
using Domain.ValueObjects;
namespace Domain.TouristPackages;

public sealed class LineItem
{
    internal LineItem(LineItemId id, TouristPackageId touristPackageId, DestinationId destinationId, Money price)
    {
        Id = id;
        TouristPackageId = touristPackageId;
        DestinationId = destinationId;
        Price = price;
    }

    private LineItem()
    {

    }

    public LineItemId Id { get; private set; }
    public TouristPackageId TouristPackageId { get; private set; }
    public DestinationId DestinationId { get; private set; }
    public Money Price { get; private set; }
}