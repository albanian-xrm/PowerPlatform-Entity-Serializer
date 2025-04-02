using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class DoubleConverter : JsonConverter<double>, IObjectContractConverter
    {
        public const string TypeSchema = "Double:#System";

        private readonly EntitySerializerOptions entitySerializerOptions;

        public DoubleConverter(EntitySerializerOptions entitySerializerOptions)
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
            var value = reader.GetDouble();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return value;
        }

        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetDouble();
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
                return (double)ReadInternal(ref reader, typeToConvert, options);
            }
            else
            {
                throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            var writingSchema = entitySerializerOptions.writingSchema;
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                writingSchema = true;
            }
            if (writingSchema)
            {
                writer.WriteStartObject();
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
                writer.WriteNumber(EntitySerializer.ValuePropertyName, value);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNumberValue(value);
            }
            entitySerializerOptions.writingSchema = writingSchema;
        }
    }
}
