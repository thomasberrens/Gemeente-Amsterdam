using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class JsonAdapter {
        public static string Serialize(object obj) {
                var sb = new StringBuilder();
                sb.Append("{");

                var type = obj.GetType();
                
                // get all properties that has JsonAttribute
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic);
                foreach (var property in properties) {
                        var jsonAttribute = property.GetCustomAttribute<JsonField>();
                        
                        if (jsonAttribute == null) continue;
                        
                        sb.Append($"\"{jsonAttribute.Name}\":{ToJsonValue(property.GetValue(obj))},");
                        
                }
                
                if (sb[sb.Length - 1] == ',') {
                        sb.Remove(sb.Length - 1, 1);
                }
                
                sb.Append("}");
                return sb.ToString();
        }
        
        public static string Serialize(JsonObject obj) {
                return Serialize(obj.Fields);
        }

        public static string Serialize(Dictionary<string, object> fields)
        {
                var sb = new StringBuilder();
                sb.Append("{");
                
                foreach (KeyValuePair<string,object> field in fields)
                { 
                        sb.Append($"\"{field.Key}\":{ToJsonValue(field.Value)},");
                }
                
                
                if (sb[sb.Length - 1] == ',') {
                        sb.Remove(sb.Length - 1, 1);
                }
                
                sb.Append("}");
                
                return sb.ToString();
        }

        private static string ToJsonValue(object obj) {
                if (obj == null) {
                        return "null";
                }

                if (obj is string) {
                        return $"\"{obj}\"";
                }

                if (obj is bool) {
                        return obj.ToString().ToLower();
                }

                if (obj is int || obj is long || obj is float || obj is double || obj is decimal) {
                        return obj.ToString();
                }

                if (obj is IEnumerable<object> enumerable) {
                        var sb = new StringBuilder();
                        sb.Append("[");

                        foreach (var item in enumerable) {
                                sb.Append(ToJsonValue(item));
                                sb.Append(",");
                        }

                        if (sb[sb.Length - 1] == ',') {
                                sb.Remove(sb.Length - 1, 1);
                        }

                        sb.Append("]");
                        return sb.ToString();
                }

                return Serialize(obj);
        }
}
