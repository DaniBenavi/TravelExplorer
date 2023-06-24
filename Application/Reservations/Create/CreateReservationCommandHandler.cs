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
    private readonly ICustomerRepository _customerRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitofwork;
    public CreateReservationCommandHandler(ICustomerRepository customerRepository, IReservationRepository reservationRepository, IUnitOfWork unitofwork)
    {
        _customerRepository = customerRepository;
        _reservationRepository = reservationRepository;
        _unitofwork = unitofwork;
    }


    public async Task<ErrorOr<ReservationResponse>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));

        if (customer is null)
        {
            return Error.NotFound("Customer.NotFound", $"The customer {request.CustomerId} does not exist");
        }

        var reservation = Reservation.Create(customer.Id);

        if (!request.Items.Any())
        {
            return Error.Conflict("Reservation.Detail", "For create at reservation you need to specify the details of the reservation");
        }

        foreach (var item in request.Items)
        {
            reservation.Add(new DestinationId(item.DestinationId), item.Quantity, new Money("$", item.Price));
        }
        _reservationRepository.Add(reservation);

        await _unitofwork.SaveChangesAsync(cancellationToken);

        return new ReservationResponse();
    }
}