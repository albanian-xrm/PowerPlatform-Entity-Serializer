using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class IntegerConverter : JsonConverter<int>, IObjectContractConverter
    {
        public const string TypeSchema = "Int32:#System";

        private readonly EntitySerializerOptions entitySerializerOptions;

        public IntegerConverter(EntitySerializerOptions entitySerializerOptions)
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
            var value = reader.GetInt32();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return value;
        }

        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(int));

            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetInt32();
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
                return (int)ReadInternal(ref reader, typeToConvert, options);
            }
            else
            {
                throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            if (entitySerializerOptions.writingSchema)
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
        }
    }
}
