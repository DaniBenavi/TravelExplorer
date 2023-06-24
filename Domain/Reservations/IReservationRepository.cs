namespace Domain.Reservations;

public interface IReservationRepository
{

    Task<Reservation?> GetByIdWithLineItemAsync(ReservationId id, LineItemId lineItemId);
    bool HasOneLineItem(Reservation reservation);

    void Add(Reservation reservation);
}