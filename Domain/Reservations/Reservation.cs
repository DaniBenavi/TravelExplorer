using Domain.Customers;
using Domain.Primitives;
using Domain.Destinations;
using Domain.ValueObjects;

namespace Domain.Reservations;

public sealed class Reservation : AgregateRoot
{
    private readonly List<LineItem> _lineItems = new();
    private Reservation()
    {

    }

    public ReservationId Id { get; private set; }

    public CustomerId CustomerId { get; set; }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public static Reservation Create(CustomerId customerId)
    {
        var reservation = new Reservation
        {
            Id = new ReservationId(Guid.NewGuid()),
            CustomerId = customerId
        };

        return reservation;
    }

    public void Add(DestinationId destinationId, decimal quantity, Money price)
    {
        var LineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, destinationId, quantity, price);

        _lineItems.Add(LineItem);
    }

    public void RemoveLineItem(LineItemId lineItemId, IReservationRepository reservationRepository)
    {
        if (reservationRepository.HasOneLineItem(this))
        {
            return;
        }

        var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);

        if (lineItem is null)
        {
            return;
        }

        _lineItems.Remove(lineItem);
    }
}