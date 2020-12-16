using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class EntityReferenceConverter : JsonConverter<EntityReference>, IObjectContractConverter
    {
        public const string TypeSchema = "EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts";

        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<KeyAttributeCollection> keyAttributeCollectionConverter;

        public EntityReferenceConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = new EntityReference();

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
                    case nameof(value.Id):
                        value.Id = reader.GetGuid();
                        break;
                    case nameof(value.KeyAttributes):
                        if (keyAttributeCollectionConverter == null) keyAttributeCollectionConverter = entitySerializerOptions.converters.GetForType<KeyAttributeCollection>();
                        var keyAttributes = keyAttributeCollectionConverter.Read(ref reader, typeof(KeyAttributeCollection), options);
                        foreach (var item in keyAttributes)
                        {
                            value.KeyAttributes.Add(item);
                        }
                        break;
                    case nameof(value.LogicalName):
                        value.LogicalName = reader.GetString();
                        break;
                    case nameof(value.Name):
                        value.Name = reader.GetString();
                        break;
                    case nameof(value.RowVersion):
                        value.RowVersion = reader.GetString();
                        break;
                    default:
                        throw new JsonException($"Unknknown property \"{propertyName}\" for EntityReference type.");
                }
                if (!reader.Read())
                {
                    throw new JsonException();
                }
            }
            return value;
        }

        public override EntityReference Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(EntityReference));

            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            return (EntityReference)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, EntityReference value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
