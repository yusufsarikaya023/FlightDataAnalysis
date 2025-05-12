using Domain.Abstract;

namespace Domain.Aggregation.Flights;

/// <summary>
/// Interface for Flight repository
/// </summary>
public interface IFlightRepository: IRepository
{
    /// <summary>
    /// Add a new Flight to the repository
    /// </summary>
    /// <param name="flight"> The flight to add</param>
    Task Add(Flight flight);
    
    /// <summary>
    /// Get unchecked flights from the repository
    /// </summary>
    /// <returns> A task that represents the asynchronous operation.
    /// The task result contains an array of unchecked flights.</returns>
    Task<Flight[]> GetUncheckedFlights();
    
    /// <summary>
    /// Get inconsistent flights from the repository
    /// </summary>
    /// <returns> A queryable collection of inconsistent flights.</returns>
    IQueryable<Flight> GetInconsistentFlights();
    
    /// <summary>
    /// Get a paginated list of flights from the repository
    /// </summary>
    /// <param name="skip"> The number of flights to skip</param>
    /// <param name="take"> The number of flights to take</param>
    /// <returns> A queryable collection of flights.</returns>
    IQueryable<Flight> GetFlights(int skip, int take);
}