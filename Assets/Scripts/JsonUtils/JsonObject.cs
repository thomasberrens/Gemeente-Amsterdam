using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Represents a JSON object with fields and values.
/// </summary>
public class JsonObject
{
    /// <summary>
    /// Gets or sets the dictionary of fields and values.
    /// </summary>
    public Dictionary<string, object> Fields { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Initializes a new instance of the JsonObject class using reflection on the provided object.
    /// </summary>
    /// <param name="obj">The object to initialize the fields from.</param>
    public JsonObject(Object obj)
    {
        InitializeObjectFields(obj);
    }

    /// <summary>
    /// Initializes a new instance of the JsonObject class.
    /// </summary>
    public JsonObject()
    {

    }

    /// <summary>
    /// Initializes the fields of the object by reflecting on the provided object.
    /// </summary>
    /// <param name="obj">The object to initialize the fields from.</param>
    private void InitializeObjectFields(Object obj)
    {
        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var jsonAttribute = property.GetCustomAttribute<JsonField>();

            if (jsonAttribute == null) continue;

            Fields.Add(jsonAttribute.Name, property.GetValue(obj));
        }
    }

    /// <summary>
    /// Adds a field to the dictionary.
    /// </summary>
    /// <param name="name">The name of the field.</param>
    /// <param name="value">The value of the field.</param>
    public void AddField(string name, object value)
    {
        Fields.Add(name, value);
    }

    /// <summary>
    /// Retrieves the value of a field from the dictionary.
    /// </summary>
    /// <param name="name">The name of the field.</param>
    /// <returns>The value of the field.</returns>
    public object GetField(string name)
    {
        return Fields[name];
    }
}
