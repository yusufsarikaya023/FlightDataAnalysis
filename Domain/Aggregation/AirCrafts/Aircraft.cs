namespace Domain.Aggregation.AirCrafts;

public class Aircraft : Entity
{
    public string RegistrationNumber { get; private set; } = string.Empty;

    public void SetRegistrationNumber(string value)
    {
        RegistrationNumber = value;
    }

    public AircraftType AircraftType { get; set; } 

    public void SetAircraftType(AircraftType value)
    {
        AircraftType = value;
    }
}