using Domain.Reservations;
using Domain.TouristPackages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class TouristPackageRepository : ITouristPackageRepository
{

    private readonly ApplicationDbContext _context;

    public TouristPackageRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(TouristPackage touristPackage)
    {
        _context.Add(touristPackage);
    }

    public async Task<TouristPackage?> GetByIdWithLineItemAsync(TouristPackageId id, LineItemId lineItemId)
    {
        return await _context.TouristPackages.Include(o => o.LineItems.Where(li => li.Id == lineItemId))
                                    .SingleOrDefaultAsync(o => o.Id == id);
    }

    public Task<Reservation?> GetByIdWithLineItemAsync(ReservationId id)
    {
        throw new NotImplementedException();
    }

    public Task<TouristPackage?> GetByIdWithLineItemAsync(TouristPackageId id)
    {
        throw new NotImplementedException();
    }

    public bool HasOneLineItem(TouristPackage touristpackage)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TouristPackage>> GetAll()
    {
        return await _context.TouristPackages
            .Include(o => o.LineItems)
            .ToListAsync();
    }
}