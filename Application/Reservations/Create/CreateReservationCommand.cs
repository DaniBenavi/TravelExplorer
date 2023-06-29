using Application.Reservations.Common;
using Domain.Customers;
using Domain.Reservations;
using Domain.TouristPackages;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Reservations.Create;

public record CreateReservationCommand(
    Guid CustomerId,
    TouristPackageId TouristPackageId,
    DateTime Traveldate
    ) : IRequest<ErrorOr<Unit>>;