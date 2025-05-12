namespace Domain.Common;

/// <summary>
/// Base class for all entities.
/// </summary>
public abstract class Entity: IAggregationRoot
{
    public int Id { get; set; }
}