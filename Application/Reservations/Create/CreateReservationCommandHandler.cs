using Application.Reservations.Common;
using Domain.Customers;
using Domain.Reservations;
using Domain.Primitives;
using Domain.Destinations;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Reservations.Create;
public sealed class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ErrorOr<ReservationResponse>>
{

    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitofwork;
    public CreateReservationCommandHandler(IReservationRepository reservationRepository, IUnitOfWork unitofwork)
    {

        _reservationRepository = reservationRepository;
        _unitofwork = unitofwork;
    }


    public async Task<ErrorOr<ReservationResponse>> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {


        var reservation = new Reservation(command.ReservationId, command.CustomerId, command.Traveldate, command.Price, command.TouristPackageId);

        _reservationRepository.Add(reservation);

        await _unitofwork.SaveChangesAsync(cancellationToken);

        return new ReservationResponse();
    }
}