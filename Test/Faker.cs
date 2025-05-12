using Bogus;
using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;
using Domain.Aggregation.Flights;

namespace Test;

/// <summary>
/// This class is responsible for generating fake data for testing purposes.
/// </summary>
public class Faker
{
    /// <summary>
    /// This method is responsible for generating fake data for the AirCraft entity.
    /// </summary>
    public static AirCraft GetFakeAirCraft()
    {
        return new Faker<AirCraft>()
            .RuleFor(x => x.RegistrationNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.AircraftType,
                f => f.PickRandom(Enum.GetValues(typeof(AircraftType)).Cast<AircraftType>().ToArray()));
    }
    
    /// <summary>
    /// This method is responsible for generating fake data for the Flight entity.
    /// </summary>
    public static Flight GetFakeFlight()
    {
        return new Faker<Flight>()
            .RuleFor(x => x.FlightNumber, f => f.Random.AlphaNumeric(10))
            // Utc format
            .RuleFor(x => x.DepartureDateTime, f => f.Date.Past(1, DateTime.UtcNow))
            .RuleFor(x => x.ArrivalDateTime, f => f.Date.Past(1, DateTime.UtcNow));
    }

    /// <summary>
    /// This method is responsible for generating fake data for the Airport entity.
    /// </summary>
    public static Airport GetFakeAirport()
    {
        return new Faker<Airport>()
            .RuleFor(x => x.Name, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.Code, f => f.Random.AlphaNumeric(3));
    }
}