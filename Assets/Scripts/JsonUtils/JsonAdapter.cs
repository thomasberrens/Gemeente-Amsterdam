using System;
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

        public static JsonObject ToJsonObject(string json)
        {
                Dictionary<string, object> fields = Parse(json);
                JsonObject jsonObject = new JsonObject
                {
                        Fields = fields
                };

                return jsonObject;
        }
        
        private static Dictionary<string, object> Parse(string jsonString)
        {
                var result = new Dictionary<string, object>();
                var entries = SplitJsonEntries(jsonString);

                foreach (var entry in entries)
                {
                        var keyValuePair = SplitKeyValuePair(entry);
                        result.Add(keyValuePair.Key, ParseJsonValue(keyValuePair.Value));
                }

                return result;
        }

        private static List<string> SplitJsonEntries(string jsonString)
        {
                jsonString = jsonString.Trim().TrimStart('{').TrimEnd('}');
                var entries = new List<string>();
                int braceCount = 0;
                int start = 0;

                for (int i = 0; i < jsonString.Length; i++)
                {
                        if (jsonString[i] == '{') braceCount++;
                        if (jsonString[i] == '}') braceCount--;
                        if (jsonString[i] == ',' && braceCount == 0)
                        {
                                entries.Add(jsonString.Substring(start, i - start));
                                start = i + 1;
                        }
                }

                entries.Add(jsonString.Substring(start));
                return entries;
        }

        private static KeyValuePair<string, string> SplitKeyValuePair(string jsonEntry)
        {
                int colonIndex = jsonEntry.IndexOf(':');
                string key = jsonEntry.Substring(0, colonIndex).Trim().Trim('"');
                string value = jsonEntry.Substring(colonIndex + 1).Trim();
                return new KeyValuePair<string, string>(key, value);
        }

        private static object ParseJsonValue(string value)
        {
                if (value.StartsWith('{'))
                {
                        return Parse(value);
                }

                if (int.TryParse(value, out int intValue))
                {
                        return intValue;
                }

                if (value.StartsWith('"') && value.EndsWith('"'))
                {
                        return value.Substring(1, value.Length - 2);
                }

                if (value == "null")
                {
                        return "null";
                }

                throw new ArgumentException($"Unsupported value type: {value}");
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
