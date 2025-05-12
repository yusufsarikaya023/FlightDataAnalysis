using Domain.Abstract;
using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;
using Domain.Aggregation.Flights;
using Infrastructure.Repositories;

namespace Infrastructure;

/// <summary>
/// UnitOfWork class for managing database transactions and repositories
/// </summary>
/// <param name="context"></param>
public class UnitOfWork(Context context) : IUnitOfWork
{
    public ITransaction BeginTransaction()
    {
        return new Transaction(context);
    }

    public Task SaveAsync()
    {
        return context.SaveChangesAsync();
    }

    private IAirCraftRepository? _airCraftRepository;

    public IAirCraftRepository AirCraftRepository()
    {
        return _airCraftRepository ??= new AirCraftRepository(context);
    }

    private IAirportRepository? _airportRepository;

    public IAirportRepository AirportRepository()
    {
        return _airportRepository ??= new AirportRepository(context);
    }

    private IFlightRepository? _flightRepository;

    public IFlightRepository FlightRepository()
    {
        return _flightRepository ??= new FlightRepository(context);
    }
}