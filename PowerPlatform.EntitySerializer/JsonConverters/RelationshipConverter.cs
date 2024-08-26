using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class RelationshipConverter : JsonConverter<Relationship>, IObjectContractConverter
    {
        public const string TypeSchema = "Relationship:http://schemas.microsoft.com/xrm/2011/Contracts";

        private readonly EntitySerializerOptions entitySerializerOptions;

        public RelationshipConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = new Relationship();

            reader.Read();
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                string propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case EntitySerializer.TypePropertyName:
                        reader.GetString(); // should check right type?
                        break;
                    case nameof(value.SchemaName):
                        value.SchemaName = reader.GetString();
                        break;
                    case nameof(value.PrimaryEntityRole):
                        if (reader.TokenType != JsonTokenType.Null)
                        {
                            value.PrimaryEntityRole = (EntityRole)reader.GetInt32();
                        }
                        break;
                    default:
                        throw new JsonException($"Unknknown property \"{propertyName}\" for Relationship type.");
                }
                if (!reader.Read())
                {
                    throw new JsonException();
                }
            }
            return value;
        }

        public override Relationship Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            return (Relationship)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, Relationship value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (entitySerializerOptions.writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            writer.WriteString(nameof(value.SchemaName), value.SchemaName);
            if (value.PrimaryEntityRole.HasValue)
            {
                writer.WriteNumber(nameof(value.PrimaryEntityRole), (int)value.PrimaryEntityRole);
            }
            writer.WriteEndObject();
        }
    }
}
