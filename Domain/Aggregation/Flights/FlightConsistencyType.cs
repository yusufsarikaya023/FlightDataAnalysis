namespace Domain.Aggregation.Flights;

/// <summary>
/// Represents the consistency type of a flight.
/// </summary>
public enum FlightConsistencyType
{
    Unchecked = 0,
    Consistent = 1,
    Inconsistent = 2,
}