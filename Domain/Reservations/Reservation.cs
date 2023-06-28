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
    public Reservation(CustomerId customerId, TouristPackageId touristPackageId, DateTime traveldate)
    {

        CustomerId = customerId;
        TouristPackageId = touristPackageId;
        TravelDate = traveldate;

    }
    public ReservationId Id { get; private set; }
    public CustomerId CustomerId { get; set; }
    public TouristPackageId TouristPackageId { get; private set; }
    public DateTime TravelDate { get; private set; }

}