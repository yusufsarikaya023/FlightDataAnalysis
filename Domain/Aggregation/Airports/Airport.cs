namespace Domain.Aggregation.Airports;

/// <summary>
/// Represents an airport entity.
/// </summary>
public class Airport : Entity
{
    public string Code { get; private set; } = string.Empty;
    public Airport SetCode(string value)
    {
        Code = value;
        return this;
    }

    public string? Name { get; private set; } = string.Empty;
    public Airport SetName(string value)
    {
        Name = value;
        return this;
    }
}