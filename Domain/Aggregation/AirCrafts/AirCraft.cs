namespace Domain.Aggregation.AirCrafts;

public class AirCraft : Entity
{
    public string RegistrationNumber { get; private set; } = string.Empty;

    public AirCraft SetRegistrationNumber(string value)
    {
        RegistrationNumber = value;
        return this;
    }

    public AircraftType AircraftType { get; set; }

    public AirCraft SetAircraftType(AircraftType value)
    {
        AircraftType = value;
        return this;
    }
}