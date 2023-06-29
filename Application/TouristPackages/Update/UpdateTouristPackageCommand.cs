using Application.TouristPackages.Common;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.TouristPackages.Update;

public record CreateTouristPackageCommand(string Name, string Description, DateTime Traveldate, Money Price, List<CreateLineItemCommand> Items) : IRequest<ErrorOr<TouristPackageResponse>>;

public record CreateLineItemCommand(Guid DestinationId)
{

}