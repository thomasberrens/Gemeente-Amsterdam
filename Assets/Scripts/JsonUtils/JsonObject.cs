
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class JsonObject
    {
        // dictionary of all the fields and values
        public Dictionary<string, object> Fields { get; private set; } = new Dictionary<string, object>();

        // constructor
        public JsonObject(Object obj) {
            initializeObjectFields(obj);
        }

        public JsonObject()
        {
            
        }

        private void initializeObjectFields(Object obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties) {
                var jsonAttribute = property.GetCustomAttribute<JsonField>();
                
                if (jsonAttribute == null) continue;
                
                Fields.Add(jsonAttribute.Name, property.GetValue(obj));
                
            }
        }
        
        // add a field to the dictionary
        public void AddField(string name, object value) {
            Fields.Add(name, value);
        }
        
        
        public object GetField(string name) {
            return Fields[name];
        }


    }
