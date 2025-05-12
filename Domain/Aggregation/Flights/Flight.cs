using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;

namespace Domain.Aggregation.Flights;

/// <summary>
/// Represents a flight entity.
/// </summary>
public class Flight : Entity
{
    public string FlightNumber { get; private set; } = string.Empty;
    public Flight SetFlightNumber(string value)
    {
        FlightNumber = value;
        return this;
    }

    public int AirCraftId { get; private set; }
    public AirCraft AirCraft { get; private set; } = null!;

    public Flight SetAirCraftId(int value)
    {
        AirCraftId = value;
        return this;
    }

    public int DepartureAirportId { get; private set; }
    public Airport DepartureAirport { get; set; } = null!;
    public Flight SetDepartureAirportId(int value)
    {
        DepartureAirportId = value;
        return this;
    }

    public int ArrivalAirportId { get; private set; }
    public Airport ArrivalAirport { get; private set; } = null!;
    public Flight SetArrivalAirportId(int value)
    {
        ArrivalAirportId = value;
        return this;
    }

    public DateTime DepartureDateTime { get; private set; }
    public Flight SetDepartureDateTime(DateTime value)
    {
        DepartureDateTime = value;
        return this;
    }

    public DateTime ArrivalDateTime { get; private set; }
    public Flight SetArrivalDateTime(DateTime value)
    {
        ArrivalDateTime = value;
        return this;
    }
    
    public FlightConsistencyType ConsistencyType { get; private set; } = FlightConsistencyType.Unchecked;
    public Flight SetConsistencyType(FlightConsistencyType value)
    {
        ConsistencyType = value;
        return this;
    }
    
    public string? InconsistencyReason { get; private set; } = string.Empty;
    public Flight SetInconsistencyReason(string value)
    {
        InconsistencyReason = value;
        return this;
    }
}