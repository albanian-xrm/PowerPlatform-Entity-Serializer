using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class OptionSetValueConverter : JsonConverter<OptionSetValue>, IObjectContractConverter
    {
        public const string TypeSchema = "OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts";
        private readonly EntitySerializerOptions entitySerializerOptions;

        public OptionSetValueConverter(EntitySerializerOptions entitySerializerOptions)
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
            OptionSetValue money = new OptionSetValue();
            if (propertyName != nameof(money.Value))
            {
                throw new JsonException();
            }
            reader.Read();
            money.Value = reader.GetInt32();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return money;
        }

        public override OptionSetValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new OptionSetValue(reader.GetInt32());
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
                return (OptionSetValue)ReadInternal(ref reader, typeToConvert, options);
            }
            else
            {
                throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, OptionSetValue value, JsonSerializerOptions options)
        {
            var writingSchema = entitySerializerOptions.writingSchema;
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                writingSchema = true;
            }
            writer.WriteStartObject();
            if (writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            writer.WriteNumber(nameof(value.Value), value.Value);
            writer.WriteEndObject();
            entitySerializerOptions.writingSchema = writingSchema;
        }
    }
}
