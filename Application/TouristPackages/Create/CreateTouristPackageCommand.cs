using Application.TouristPackages.Common;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.TouristPackages.Create;

public record CreateTouristPackageCommand(Guid TouristPackageId, List<CreateLineItemCommand> Items) : IRequest<ErrorOr<TouristPackageResponse>>;

public record CreateLineItemCommand(Guid TouristPackageId, Guid DestinationId, string Name, string Description, DateTime Traveldate, Money Price);