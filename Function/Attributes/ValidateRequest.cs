namespace Function.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ValidateRequestAttribute(Type type) : Attribute
{
    public Type Type { get; } = type;
}