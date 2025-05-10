using Domain.Aggregation.Airports;

namespace Infrastructure.Repositories;

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