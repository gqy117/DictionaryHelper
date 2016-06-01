namespace ObjectExtensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class DictionaryHelper
    {
        public static Dictionary<string, string> MapToDictionary(this object source)
        {
            var dictionary = new Dictionary<string, string>();
            MapToDictionaryInternal(dictionary, source, String.Empty);

            return dictionary;
        }

        private static void MapToDictionaryInternal(Dictionary<string, string> dictionary, object source, string prefix)
        {
            var properties = source.GetType().GetProperties();

            foreach (var p in properties)
            {
                var key = AddNamePrefix(prefix, p.Name);

                object value = p.GetValue(source, null) ?? string.Empty;
                Type valueType = value.GetType();

                if (valueType.IsPrimitive || valueType == typeof(String))
                {
                    dictionary[key] = value.ToString();
                }
                else if (value is IEnumerable)
                {
                    var i = 0;
                    foreach (object o in (IEnumerable)value)
                    {
                        MapToDictionaryInternal(dictionary, o, key + "[" + i + "]");
                        i++;
                    }
                }
                else
                {
                    MapToDictionaryInternal(dictionary, value, key);
                }
            }
        }

        private static string AddNamePrefix(string prefix, string propertyName)
        {
            string key = string.IsNullOrEmpty(prefix) ? propertyName : string.Format("{0}.{1}", prefix, propertyName);

            return key;
        }
    }
}