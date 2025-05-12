using Domain.Aggregation.Flights;

namespace Infrastructure.Repositories;

/// <summary>
/// Repository for Flight entity
/// </summary>
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

    public IQueryable<Flight> GetInconsistentFlights()
    {
        return context.Flights
            .Include(x => x.DepartureAirport)
            .Include(x => x.ArrivalAirport)
            .Include(x => x.AirCraft)
            .OrderByDescending(x => x.Id)
            .Where(x => x.ConsistencyType == FlightConsistencyType.Inconsistent);
    }

    public IQueryable<Flight> GetFlights(int page, int pageSize)
    {
        return context.Flights
            .Include(x => x.DepartureAirport)
            .Include(x => x.ArrivalAirport)
            .Include(x => x.AirCraft)
            .OrderByDescending(x => x.Id)
            .Skip((page -1) * pageSize)
            .Take(pageSize);
    }
}