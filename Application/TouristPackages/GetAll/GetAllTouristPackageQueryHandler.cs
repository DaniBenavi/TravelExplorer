using Application.TouristPackages.Common;
using Domain.TouristPackages;
using Domain.Destinations;
using ErrorOr;
using MediatR;

using Domain.Primitives;
using Domain.ValueObjects;
using System.Runtime.InteropServices;


namespace Application.TouristPackages.GetAll;


internal sealed class GetAllTouristPackagesQueryHandler : IRequestHandler<GetAllTouristPackagesQuery, ErrorOr<IReadOnlyList<TouristPackageResponse>>>
{
    private readonly ITouristPackageRepository _touristPackageRepository;
    private readonly IUnitOfWork _unitofwork;

    public GetAllTouristPackagesQueryHandler(ITouristPackageRepository touristPackageRepository, IUnitOfWork unitofwork)
    {
        _touristPackageRepository = touristPackageRepository;
        _unitofwork = unitofwork;
    }

    public async Task<ErrorOr<IReadOnlyList<TouristPackageResponse>>> Handle(GetAllTouristPackagesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<TouristPackage> touristPackages = await _touristPackageRepository.GetAll();

        var responses = new List<TouristPackageResponse>();

        foreach (var touristPackage in touristPackages)
        {
            var touristPackageResponse = new TouristPackageResponse(
                touristPackage.Id.Value,
                touristPackage.Name,
                touristPackage.Description,
                new MoneyResponse(
                    touristPackage.Price.Currency,
                    touristPackage.Price.Amount),
                touristPackage.TravelDate
                );

            responses.Add(touristPackageResponse);
        }

        return responses;
    }
}