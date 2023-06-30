using MediatR;
using ErrorOr;
using Application.Reservations.Common;
using Domain.ValueObjects;

namespace Application.Reservations.Common;

public record ReservationResponse(
    Guid Id,
    Guid CustomerName,
    Guid TouristPackageId,
    DateTime TravelDate
) : IRequest<ErrorOr<ReservationResponse>>;