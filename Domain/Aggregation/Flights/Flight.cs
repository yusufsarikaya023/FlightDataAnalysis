using Domain.Aggregation.Airports;

namespace Domain.Aggregation.Flights;

public class Flight : Entity
{
    public string FlightNumber { get; set; } = string.Empty;
    public int AirCraftId { get; set; }
    public AirCrafts.AirCraft AirCraft { get; set; } = null!;

    public int DepartureAirportId { get; set; }
    public Airport DepartureAirport { get; set; } = null!;
    
    public int ArrivalAirportId { get; set; }
    public Airport ArrivalAirport { get; set; } = null!;

    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
}