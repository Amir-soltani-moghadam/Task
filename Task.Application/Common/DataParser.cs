using System.Reflection;
using System.Text.Json;
using System.Xml.Serialization;

namespace Task.Application.Common
{
    public class DataParser : IDataParser
    {
        public async Task<List<T>> ParseAsync<T>(string datatype, string data) where T : class, new()
        {
            datatype = datatype.ToLower();
            switch (datatype)
            {
                case "json":
                    {
                        try
                        {
                            return JsonSerializer.Deserialize<List<T>>(data);
                        }
                        catch (JsonException)
                        {
                            var single = JsonSerializer.Deserialize<T>(data);
                            return new List<T> { single };
                        }
                    }
                case "xml":
                    {
                        var serializer = new XmlSerializer(typeof(SalaryCalculationsXml<T>));
                        using var reader = new StringReader(data);
                        var wrapper = (SalaryCalculationsXml<T>)serializer.Deserialize(reader);
                        return wrapper.Items;
                    }
                case "csv":
                    {
                        return ParseCsv<T>(data);
                    }
                case "custom":
                    {
                        return ParseCustom<T>(data);
                    }

                default:
                    throw new ArgumentException($"Unsupported datatype: {datatype}");
            }
        }
        private List<T> ParseCsv<T>(string data) where T : class, new()
        {
            var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var headers = lines[0].Split(',');
            var result = new List<T>();

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                var obj = new T();
                MapValues(obj, headers, values);
                result.Add(obj);
            }

            return result;
        }

        private List<T> ParseCustom<T>(string data) where T : class, new()
        {
            var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var headers = lines[0].Split('/');
            var values = lines[1].Split('/');
            var obj = new T();
            MapValues(obj, headers, values);
            return new List<T> { obj };
        }

        private void MapValues<T>(T obj, string[] headers, string[] values)
        {
            var type = typeof(T);
            for (int i = 0; i < headers.Length && i < values.Length; i++)
            {
                var prop = type.GetProperty(headers[i], BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (prop != null && prop.CanWrite)
                {
                    try
                    {
                        var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        object safeValue = Convert.ChangeType(values[i], targetType);
                        prop.SetValue(obj, safeValue);
                    }
                    catch
                    {

                    }
                }
            }
        }
        [XmlRoot("SalaryCalculations")]
        public class SalaryCalculationsXml<T>
        {
            [XmlElement("SalaryCalculation")]
            public List<T> Items { get; set; }
        }
    }
}
