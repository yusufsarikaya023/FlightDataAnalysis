using CsvHelper.Configuration.Attributes;
namespace Application.UseCases.FlightData.DTO;

public class FlightDataDto
{
    // id	aircraft_registration_number	aircraft_type	flight_number	departure_airport	departure_datetime	arrival_airport	arrival_datetime
    
    [Name("id")]
    public int Id { get; set; }
    
    [Name("aircraft_registration_number")]
    public string AircraftRegistrationNumber { get; set; } = string.Empty;
    
    [Name("aircraft_type")]
    public string AircraftType { get; set; } = string.Empty;
    
    [Name("flight_number")]
    public string FlightNumber { get; set; } = string.Empty;
    
    [Name("departure_airport")]
    public string DepartureAirport { get; set; } = string.Empty;
    
    [Name("departure_datetime")]
    public DateTime DepartureDateTime { get; set; }
    
    [Name("arrival_airport")]
    public string ArrivalAirport { get; set; } = string.Empty;
    
    [Name("arrival_datetime")]
    public DateTime ArrivalDateTime { get; set; }
}