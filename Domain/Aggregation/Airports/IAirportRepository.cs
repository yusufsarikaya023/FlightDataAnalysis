using Domain.Abstract;

namespace Domain.Aggregation.Airports;

/// <summary>
/// Interface for Airport repository
/// </summary>
public interface IAirportRepository: IRepository
{
    /// <summary>
    /// Add a new Airport to the repository
    /// </summary>
    /// <param name="airport"></param>
    Task Add(Airport airport);
    
    /// <summary>
    /// Get an airport by its code
    /// </summary>
    /// <param name="code"></param>
    Task<Airport?> GetByCode(string code);
}