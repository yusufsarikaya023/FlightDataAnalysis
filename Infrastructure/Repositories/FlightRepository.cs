using Domain.Aggregation.Flights;

namespace Infrastructure.Repositories;

public class FlightRepository(Context context) : Repository, IFlightRepository
{
    public async Task Add(Flight flight)
    {
        await context.Flights.AddAsync(flight);
    }
}