using Domain.Abstract;

namespace Domain.Aggregation.Flights;

public interface IFlightRepository: IRepository
{
    Task Add(Flight flight);
    Task<Flight[]> GetUncheckedFlights();
}