namespace Function.Attributes;

/// <summary>
/// Attribute to mark a method for request validation.
/// </summary>
/// <param name="type"> Type of the request to validate. You can use it with the typeof directive</param>
[AttributeUsage(AttributeTargets.Method)]
public class ValidateRequestAttribute(Type type) : Attribute
{
    public Type Type { get; } = type;
}