using Domain.Abstract;

namespace Domain.Aggregation.AirCrafts;

/// <summary>
/// Interface for AirCraft repository
/// </summary>
public interface IAirCraftRepository: IRepository
{
    /// <summary>
    /// Add a new AirCraft
    /// </summary>
    /// <param name="airCraft"></param>
    Task Add(AirCraft airCraft);
    
    /// <summary>
    /// Get an aircraft by its registration number
    /// </summary>
    /// <param name="registrationNumber"></param>
    Task<AirCraft?> GetByRegistrationNumber(string registrationNumber);
}