using Domain.Destinations;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

internal sealed class DestinationRepository : IDestinationRepository
{
    private readonly ApplicationDbContext _context;

    public DestinationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Destination?> GetByIdAsync(DestinationId id)
    {
        return _context.Destinations
                    .SingleOrDefaultAsync(p => p.Id == id);
    }

    public void Add(Destination destination)
    {
        _context.Destinations.Add(destination);
    }
    public void Update(Destination destination)
    {
        _context.Destinations.Update(destination);
    }
    public void Remove(Destination destination)
    {
        _context.Destinations.Remove(destination);
    }
}