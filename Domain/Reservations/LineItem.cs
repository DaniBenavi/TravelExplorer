using Domain.Customers;
using Domain.Primitives;
using Domain.Destinations;
using Domain.ValueObjects;
using Domain.Reservations;
namespace Domain.Reservations;

public sealed class LineItem
{
    internal LineItem(LineItemId id, ReservationId reservationId, DestinationId destinationId, decimal quantity, Money price)
    {
        Id = id;
        ReservationId = reservationId;
        DestinationId = destinationId;
        Quantity = quantity;
        Price = price;
    }

    private LineItem()
    {

    }

    public LineItemId Id { get; private set; }
    public ReservationId ReservationId { get; private set; }
    public DestinationId DestinationId { get; private set; }
    public decimal Quantity { get; set; }
    public Money Price { get; private set; }

}