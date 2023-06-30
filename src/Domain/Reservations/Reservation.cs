using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using Domain.TouristPackages;

namespace Domain.Reservations;

public sealed class Reservation : AgregateRoot
{
    private Reservation()
    {

    }
    public ReservationId Id { get; private set; }
    public CustomerId CustomerId { get; set; }
    public TouristPackageId TouristPackageId { get; private set; }
    public DateTime TravelDate { get; private set; }

    public static Reservation Create(CustomerId customerId, TouristPackageId touristPackageId, DateTime traveldate)
    {
        var reservation = new Reservation
        {
            Id = new ReservationId(Guid.NewGuid()),
            CustomerId = customerId,
            TouristPackageId = touristPackageId,
            TravelDate = traveldate
        };

        return reservation;
    }
}