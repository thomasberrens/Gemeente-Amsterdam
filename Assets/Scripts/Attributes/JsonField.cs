using System;

/// <summary>
/// Attribute used to mark a property or field for JSON serialization.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class JsonField : Attribute
{
    public string Name { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonField"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the JSON field.</param>
    public JsonField(string name)
    {
        Name = name;
    }
}