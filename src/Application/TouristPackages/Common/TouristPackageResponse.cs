using MediatR;
using ErrorOr;

namespace Application.TouristPackages.Common;

public record TouristPackageResponse(
    Guid Id,
    string Name,
    string Description,
    MoneyResponse Price,
    DateTime TravelDate
    ) : IRequest<ErrorOr<TouristPackageResponse>>;

public record MoneyResponse(
    string Currency,
    decimal Amount
    );
