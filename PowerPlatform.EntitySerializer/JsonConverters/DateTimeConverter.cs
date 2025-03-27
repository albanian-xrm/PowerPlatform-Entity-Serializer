using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class DateTimeConverter : JsonConverter<DateTime>, IObjectContractConverter
    {
        public const string TypeSchema = "DateTime:#System";
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly EntitySerializerOptions entitySerializerOptions;

        public DateTimeConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }
            string propertyName = reader.GetString();
            if (propertyName != EntitySerializer.ValuePropertyName)
            {
                throw new JsonException();
            }
            reader.Read();
            var value = GetDateTime(ref reader);

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return value;
        }

        private static DateTime GetDateTime(ref Utf8JsonReader reader)
        {
            if (!reader.TryGetDateTime(out DateTime value))
            {
                var stringValue = reader.GetString();
                if (stringValue.StartsWith("/Date(") && stringValue.EndsWith(")/"))
                {
                    return ConvertFromString(stringValue);
                }
                else
                {
                    return DateTime.Parse(reader.GetString());
                }
            }
            return value;
        }

        public static DateTime ConvertFromString(string stringValue)
        {
            stringValue = stringValue.Substring("/Date(".Length, stringValue.Length - "/Date(".Length - ")/".Length);
            var charTimezone = stringValue.Length > 5 ? stringValue[stringValue.Length - 5] : '0';
            if (charTimezone == '+' || charTimezone == '-')
            {
                return epoch.AddMilliseconds(double.Parse(stringValue.Substring(0, stringValue.Length - 5)))
                            .AddHours(double.Parse(stringValue.Substring(stringValue.Length - 5, 3)))
                            .AddMinutes(double.Parse(charTimezone + stringValue.Substring(stringValue.Length - 2)));
            }
            else
            {
                return epoch.AddMilliseconds(double.Parse(stringValue));
            }
        }

        public static string ConvertToString(DateTime dateTime)
        {
            var milliseconds = (dateTime.ToUniversalTime() - epoch).TotalMilliseconds;
            // Well escaping forward slashes is optional but in context of date operations it is a convention: https://asp-blogs.azurewebsites.net/bleroy/dates-and-json
            return $"\"\\/Date({milliseconds:0})\\/\"";
        }


        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return GetDateTime(ref reader);
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                if (reader.GetString() != EntitySerializer.TypePropertyName)
                {
                    throw new JsonException();
                }
                reader.Read();
                if (!TypeSchema.Equals(reader.GetString()))
                {
                    throw new JsonException();
                }
                return (DateTime)ReadInternal(ref reader, typeToConvert, options);
            }
            else
            {
                throw new JsonException();
            }

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var stringValue = entitySerializerOptions.DateOptions == DateOptions.SerializeXrmDate ? ConvertToString(value) : $"\"{value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}\"";
            var writingSchema = entitySerializerOptions.writingSchema;
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                writingSchema = false;
            }
            if (writingSchema)
            {
                writer.WriteStartObject();
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
                writer.WritePropertyName(EntitySerializer.ValuePropertyName);
                writer.WriteRawValue(stringValue);
                writer.WriteEndObject();
            }
            else
            {
                
                writer.WriteRawValue(stringValue);
            }
            entitySerializerOptions.writingSchema = writingSchema;
        }
    }
}
