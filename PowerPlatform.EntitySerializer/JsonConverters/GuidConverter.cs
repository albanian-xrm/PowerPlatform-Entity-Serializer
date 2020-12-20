using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class GuidConverter : JsonConverter<Guid>, IObjectContractConverter
    {
        public const string TypeSchema = "Guid:#System";

        private readonly EntitySerializerOptions entitySerializerOptions;

        public GuidConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();
                     
            string propertyName = reader.GetString();
            if (propertyName != EntitySerializer.ValuePropertyName)
            {
                throw new JsonException();
            }
            reader.Read();
            var value = reader.GetGuid();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return value;
        }

        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(Guid));

            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetGuid();
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
                if (reader.GetString() != EntitySerializer.TypePropertyName)
                {
                    throw new JsonException();
                }
                reader.Read();
                if (!TypeSchema.Equals(reader.GetString()))
                {
                    throw new JsonException();
                }
                return (Guid)ReadInternal(ref reader, typeToConvert, options);
            }
            else
            {
                throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            if (entitySerializerOptions.writingSchema)
            {
                writer.WriteStartObject();
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
                writer.WriteString(EntitySerializer.ValuePropertyName, value);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStringValue(value);
            }
        }
    }
}
