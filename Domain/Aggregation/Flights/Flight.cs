using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;

namespace Domain.Aggregation.Flights;

public class Flight : Entity
{
    public string FlightNumber { get; set; } = string.Empty;

    public Flight SetFlightNumber(string value)
    {
        FlightNumber = value;
        return this;
    }

    public int AirCraftId { get; set; }
    public AirCraft AirCraft { get; set; } = null!;

    public Flight SetAirCraftId(int value)
    {
        AirCraftId = value;
        return this;
    }

    public int DepartureAirportId { get; set; }
    public Airport DepartureAirport { get; set; } = null!;

    public Flight SetDepartureAirportId(int value)
    {
        DepartureAirportId = value;
        return this;
    }

    public int ArrivalAirportId { get; set; }
    public Airport ArrivalAirport { get; set; } = null!;

    public Flight SetArrivalAirportId(int value)
    {
        ArrivalAirportId = value;
        return this;
    }

    public DateTime DepartureDateTime { get; set; }

    public Flight SetDepartureDateTime(DateTime value)
    {
        DepartureDateTime = value;
        return this;
    }

    public DateTime ArrivalDateTime { get; set; }

    public Flight SetArrivalDateTime(DateTime value)
    {
        ArrivalDateTime = value;
        return this;
    }
    
    public FlightConsistencyType ConsistencyType { get; set; } = FlightConsistencyType.Unchecked;
    public Flight SetFlag(FlightConsistencyType value)
    {
        ConsistencyType = value;
        return this;
    }
}