namespace Domain.Aggregation.Airports;

public class Airport : Entity
{
    public string Code { get; private set; } = string.Empty;

    public Airport SetCode(string value)
    {
        Code = value;
        return this;
    }

    public string? Name { get; set; } = string.Empty;

    public Airport SetName(string value)
    {
        Name = value;
        return this;
    }
}