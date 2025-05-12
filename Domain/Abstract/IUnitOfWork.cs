using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;
using Domain.Aggregation.Flights;

namespace Domain.Abstract;

/// <summary>
/// Unit of work interface for managing repositories and transactions
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save changes to the database
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();

    /// <summary>
    /// Aircraft repository to manage aircraft data
    /// </summary>
    IAirCraftRepository AirCraftRepository();
    
    /// <summary>
    /// Airport repository to manage airport data
    /// </summary>
    IAirportRepository AirportRepository();
    
    /// <summary>
    /// Flight repository to manage flight data
    /// </summary>
    IFlightRepository FlightRepository();
    
    /// <summary>
    /// Begin a new transaction for managing database operations
    /// </summary>
    ITransaction BeginTransaction();
}