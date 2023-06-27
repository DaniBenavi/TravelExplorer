using Domain.Destinations;
using Domain.ValueObjects;
namespace Domain.TouristPackages;

public sealed class LineItem
{
    internal LineItem(LineItemId id, string name, string description, DateTime traveldate, Money price, DestinationId destinationId)
    {
        Id = id;
        Name = name;
        Description = description;
        TravelDate = traveldate;
        Price = price;
        DestinationId = destinationId;
    }

    private LineItem()
    {

    }

    public LineItemId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime TravelDate { get; private set; }
    public decimal Quantity { get; set; }
    public Money Price { get; private set; }
    public DestinationId DestinationId { get; private set; }

}