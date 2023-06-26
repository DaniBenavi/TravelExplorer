using Domain.Destinations;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.TouristPackages;

public sealed class TouristPackage : AgregateRoot
{
    private readonly List<LineItem> _lineItems = new();
    private TouristPackage()
    {

    }
    public TouristPackage(LineItemId lineItemId, TouristPackageId touristPackageId, string name, string description, DateTime traveldate, Money price, DestinationId destinationId)
    {
        LineItemId = lineItemId;
        Id = touristPackageId;
        Name = name;
        Description = description;
        Traveldate = traveldate;
        Price = price;
        DestinationId = destinationId;

    }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public static TouristPackage Create(DestinationId destinationId)
    {
        var touristpackage = new TouristPackage
        {
            Id = new TouristPackageId(Guid.NewGuid()),
            DestinationId = destinationId
        };

        return touristpackage;
    }

    public void Add(TouristPackageId touristPackageId, string name, string description, DateTime travelDate, Money price, DestinationId destinationId)
    {
        var LineItem = new LineItem(new LineItemId(Guid.NewGuid()), touristPackageId, name, description, travelDate, price, destinationId);

        _lineItems.Add(LineItem);
    }

    public void RemoveLineItem(LineItemId lineItemId, ITouristPackageRepository touristPackageRepository)
    {
        if (touristPackageRepository.HasOneLineItem(this)) return;

        var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);

        if (lineItem == null) return;

        _lineItems.Remove(lineItem);
    }

    public LineItemId LineItemId { get; private set; }
    public TouristPackageId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; }
    public DateTime Traveldate { get; private set; }
    public Money Price { get; private set; }
    public DestinationId DestinationId { get; private set; }


}