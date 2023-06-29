using Domain.Reservations;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

internal sealed class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Reservation?> GetByIdAsync(ReservationId id)
    {
        return _context.Reservations
                    .SingleOrDefaultAsync(p => p.Id == id);
    }

    public void Add(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
    }
    public void Update(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
    }
    public void Remove(Reservation reservation)
    {
        _context.Reservations.Remove(reservation);
    }

    public Task<Reservation?> GetByIdWithLineItemAsync(ReservationId id)
    {
        throw new NotImplementedException();
    }

    public bool HasOneLineItem(Reservation reservation)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Reservation>> GetAll() => await _context.Reservations.ToListAsync();
}