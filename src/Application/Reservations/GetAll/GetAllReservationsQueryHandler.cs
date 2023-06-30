using Application.Reservations.Common;
using Domain.Reservations;
using Domain.Destinations;
using ErrorOr;
using MediatR;
using Domain.Primitives;

namespace Application.Reservations.GetAll;


internal sealed class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, ErrorOr<IReadOnlyList<ReservationResponse>>>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IDestinationRepository _destinationRepository;
    private readonly IUnitOfWork _unitofwork;

    public GetAllReservationsQueryHandler(IReservationRepository reservationRepository, IDestinationRepository destinationRepository, IUnitOfWork unitofwork)
    {
        _reservationRepository = reservationRepository;
        _unitofwork = unitofwork;
    }

    public async Task<ErrorOr<IReadOnlyList<ReservationResponse>>> Handle(GetAllReservationsQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Reservation> reservations = await _reservationRepository.GetAll();

        var responses = new List<ReservationResponse>();

        foreach (var reservation in reservations)
        {
            var reservationResponse = new ReservationResponse(
                reservation.Id.Value,
                reservation.CustomerId.Value,
                reservation.TouristPackageId.Value,
                reservation.TravelDate
                );

            responses.Add(reservationResponse);
        }

        return responses;
    }
}