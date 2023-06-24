using Application.Reservations.Common;
using ErrorOr;
using MediatR;

namespace Application.Reservations.Create;

public record CreateReservationCommand(Guid CustomerId, List<CreateLineItemCommand> Items) : IRequest<ErrorOr<ReservationResponse>>;

public record CreateLineItemCommand(Guid DestinationId, decimal Quantity, decimal Price);