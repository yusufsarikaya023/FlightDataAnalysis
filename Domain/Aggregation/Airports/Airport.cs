namespace Domain.Aggregation.Airports;

public class Airport : Entity
{
    public string Code { get; private set; } = string.Empty;

    public void SetCode(string value)
    {
        Code = value;
    }

    public string Name { get; set; } = string.Empty;

    public void SetName(string value)
    {
        Name = value;
    }
}