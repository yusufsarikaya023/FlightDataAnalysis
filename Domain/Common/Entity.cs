namespace Domain.Common;

public abstract class Entity: IAggregationRoot
{
    public int Id { get; set; }
}