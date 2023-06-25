using Domain.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{

    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Reservation reservation)
    {
        _context.Add(reservation);
    }

    public async Task<Reservation?> GetByIdWithLineItemAsync(ReservationId id, LineItemId lineItemId)
    {
        return await _context.Reservations.Include(o => o.LineItems.Where(li => li.Id == lineItemId))
                                    .SingleOrDefaultAsync(o => o.Id == id);
    }

    public bool HasOneLineItem(Reservation reservation)
    {
        return _context.LineItems.Count(li => li.ReservationId == reservation.Id) == 1;
    }
}