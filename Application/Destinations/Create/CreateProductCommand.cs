using MediatR;
using ErrorOr;
using Application.Destinations.Common;

namespace Application.Destinations;

public record CreateDestinationCommand(
    string Name,
    string Sku,
    string Currency,
    decimal Amount
) : IRequest<ErrorOr<DestinationResponse>>;