using Bogus;
using Domain.Aggregation.AirCrafts;

namespace Test;

public class Faker
{
    public static AirCraft GetFakeAirCraft()
    {
        return new Faker<AirCraft>()
            .RuleFor(x => x.RegistrationNumber, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.AircraftType,
                f => f.PickRandom(Enum.GetValues(typeof(AircraftType)).Cast<AircraftType>().ToArray()));
    }
}