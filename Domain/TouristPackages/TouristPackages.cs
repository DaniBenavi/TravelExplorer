using Domain.Destinations;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.TouristPackages;

public sealed class TouristPackage : AgregateRoot
{
    private readonly List<LineItem> _lineItems = new();
    private TouristPackage()
    {

    }

    public TouristPackageId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public static TouristPackage Create(CustomerId customerId)
    {
        var touristpackage = new TouristPackage
        {
            Id = new TouristPackageId(Guid.NewGuid()),
            CustomerId = customerId
        };

        return touristpackage;
    }

    public void Add(TouristPackageId touristPackageId, DestinationId destinationId, Money price)
    {
        var LineItem = new LineItem(new LineItemId(Guid.NewGuid()), touristPackageId, destinationId, price);

        _lineItems.Add(LineItem);
    }

    public void RemoveLineItem(LineItemId lineItemId, ITouristPackageRepository touristPackageRepository)
    {
        if (touristPackageRepository.HasOneLineItem(this))
        {
            return;
        }

        var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);

        if (lineItem == null)
        {
            return;
        }

        _lineItems.Remove(lineItem);
    }

}