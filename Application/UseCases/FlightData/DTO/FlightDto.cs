namespace Application.UseCases.FlightData.DTO;

public class FlightDto
{
    public int Id { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    
    public string DepartureAirport { get; set; } = string.Empty;
    public string ArrivalAirport { get; set; } = string.Empty;
    
    public string AirCraftRegistrationNumber { get; set; } = string.Empty;
    
    public string ConsistencyType { get; set; } = string.Empty;
    public string? InconsistencyReason { get; set; }
}