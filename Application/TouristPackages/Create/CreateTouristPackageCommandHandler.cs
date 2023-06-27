using Application.TouristPackages.Common;
using Domain.Primitives;
using Domain.Destinations;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Domain.TouristPackages;
using Domain.Reservations;

namespace Application.TouristPackages.Create;
public sealed class CreateTouristPackageCommandHandler : IRequestHandler<CreateTouristPackageCommand, ErrorOr<TouristPackageResponse>>
{
    private readonly ITouristPackageRepository _touristpackageRepository;
    private readonly IDestinationRepository _destinationRepository;
    private readonly IUnitOfWork _unitofwork;
    public CreateTouristPackageCommandHandler(ITouristPackageRepository touristpackageRepository, IDestinationRepository destinationRepository, IUnitOfWork unitofwork)
    {
        _touristpackageRepository = touristpackageRepository;
        _destinationRepository = destinationRepository;
        _unitofwork = unitofwork;
    }


    public async Task<ErrorOr<TouristPackageResponse>> Handle(CreateTouristPackageCommand command, CancellationToken cancellationToken)
    {
        var touristPackages = await _touristpackageRepository.GetByIdWithLineItemAsync(new TouristPackageId(command.TouristPackageId));

        if (touristPackages is null)
        {
            return Error.NotFound("touristPackage.NotFound", $"The touristPackage {command.TouristPackageId} does not exist");
        }

        var touristPackage = TouristPackage.Create(touristPackages.CustomerId);

        if (!command.Items.Any())
        {
            return Error.Conflict("TouristPackage.Detail", "For create at reservation you need to specify the details of the reservation");
        }

        foreach (var item in command.Items)
        {
            touristPackage.Add(new TouristPackageId(item.TouristPackageId), new DestinationId(item.DestinationId), item.Price);
        }
        _touristpackageRepository.Add(touristPackage);

        await _unitofwork.SaveChangesAsync(cancellationToken);

        return new TouristPackageResponse();
    }
}