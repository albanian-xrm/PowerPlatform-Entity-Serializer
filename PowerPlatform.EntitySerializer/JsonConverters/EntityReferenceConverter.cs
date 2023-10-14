using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class EntityReferenceConverter : JsonConverter<EntityReference>, IObjectContractConverter
    {
        public const string TypeSchema = "EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts";

        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<KeyAttributeCollection> keyAttributeCollectionConverter;
        private JsonConverter<Guid> guidConverter;

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
                    case EntitySerializer.TypePropertyName:
                        reader.GetString(); // should check right type?
                        break;
                    case nameof(value.Id):
                        InitializeGuidConverter();
                        value.Id = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.KeyAttributes):
                        InitializeKeyAttributeCollectionConverter();
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
            if (entitySerializerOptions.writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            };
            writer.WriteString(nameof(value.Id), value.Id);

            InitializeKeyAttributeCollectionConverter();
            writer.WritePropertyName(nameof(value.KeyAttributes));
            keyAttributeCollectionConverter.Write(writer, value.KeyAttributes, options);

            writer.WriteString(nameof(value.LogicalName), value.LogicalName);

            writer.WriteString(nameof(value.Name), value.Name);

            writer.WriteString(nameof(value.RowVersion), value.RowVersion);

            writer.WriteEndObject();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeKeyAttributeCollectionConverter()
        {
            if (keyAttributeCollectionConverter == null)
                keyAttributeCollectionConverter = entitySerializerOptions.converters.GetForType<KeyAttributeCollection>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeGuidConverter()
        {
            if (guidConverter == null)
                guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
        }
    }
}
