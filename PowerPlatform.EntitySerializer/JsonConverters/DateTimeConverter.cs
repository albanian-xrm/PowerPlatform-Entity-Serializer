using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly EntitySerializerOptions entitySerializerOptions;

        public DateTimeConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            if (!reader.TryGetDateTime(out DateTime value))
            {
                var stringValue = reader.GetString();
                if (stringValue.StartsWith("/Date(") && stringValue.EndsWith(")/"))
                {
                    value = epoch.AddMilliseconds(double.Parse(stringValue.Substring("/Date(".Length, stringValue.Length - "/Date(".Length - ")/".Length)));
                }
                else
                {
                    value = DateTime.Parse(reader.GetString());
                }
            }
            return value;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
        }
    }
}
