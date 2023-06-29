using Domain.Reservations;

namespace Domain.Reservations;

public interface IReservationRepository
{

    Task<Reservation?> GetByIdWithLineItemAsync(ReservationId id);
    bool HasOneLineItem(Reservation reservation);
    Task<List<Reservation>> GetAll();
    void Add(Reservation reservation);
}