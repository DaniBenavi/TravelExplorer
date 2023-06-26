using Domain.Reservations;

namespace Domain.Reservations;

public interface IReservationRepository
{

    Task<Reservation?> GetByIdWithLineItemAsync(ReservationId id);
    bool HasOneLineItem(Reservation reservation);

    void Add(Reservation reservation);
}