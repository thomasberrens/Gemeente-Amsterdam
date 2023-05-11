
using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JsonField : Attribute
    {
        public string Name { get; set; }
        public JsonField(string name) {
            Name = name;
        }
    }
