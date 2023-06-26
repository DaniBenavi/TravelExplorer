using Application.Reservations.Common;
using Domain.Customers;
using Domain.Reservations;
using Domain.TouristPackages;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Reservations.Create;

public record CreateReservationCommand(
    ReservationId ReservationId,
    CustomerId CustomerId,
    TouristPackageId TouristPackageId,
    DateTime Traveldate,
    Money Price
    ) : IRequest<ErrorOr<ReservationResponse>>;