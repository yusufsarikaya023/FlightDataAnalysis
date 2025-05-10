using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;
using Domain.Aggregation.Flights;

namespace Domain.Abstract;

public interface IUnitOfWork
{
    Task SaveAsync();

    IAirCraftRepository AirCraftRepository();
    IAirportRepository AirportRepository();
    IFlightRepository FlightRepository();
    
    ITransaction BeginTransaction();
}