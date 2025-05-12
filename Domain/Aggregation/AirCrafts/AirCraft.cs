namespace Domain.Aggregation.AirCrafts;

/// <summary>
/// Represents an aircraft entity.
/// </summary>
public class AirCraft : Entity
{
    public string RegistrationNumber { get; private set; } = string.Empty;
    public AirCraft SetRegistrationNumber(string value)
    {
        RegistrationNumber = value;
        return this;
    }

    public AircraftType AircraftType { get; private set; }
    public AirCraft SetAircraftType(AircraftType value)
    {
        AircraftType = value;
        return this;
    }
}