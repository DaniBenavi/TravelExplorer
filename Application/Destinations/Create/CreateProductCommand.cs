using MediatR;
using ErrorOr;
using Application.Destinations.Common;

namespace Application.Destinations;

public record CreateDestinationCommand(
    string Name,
    string Description
) : IRequest<ErrorOr<DestinationResponse>>;