using Domain.Aggregation.Flights;

namespace Infrastructure.Repositories;

public class FlightRepository(Context context) : Repository, IFlightRepository
{
    public async Task Add(Flight flight)
    {
        await context.Flights.AddAsync(flight);
    }

    public Task<Flight[]> GetUncheckedFlights()
    {
        return context.Flights
            .Where(x => x.ConsistencyType == FlightConsistencyType.Unchecked)
            .ToArrayAsync();
    }
}