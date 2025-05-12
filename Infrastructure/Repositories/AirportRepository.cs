using Domain.Aggregation.Airports;

namespace Infrastructure.Repositories;

/// <summary>
/// Repository for Airport entity
/// </summary>
public class AirportRepository(Context context) : Repository, IAirportRepository
{
    public async Task Add(Airport airport)
    {
       await context.Airports.AddAsync(airport);
    }

    public Task<Airport?> GetByCode(string code)
    {
        return context.Airports.FirstOrDefaultAsync(airport => airport.Code == code);
    }
}