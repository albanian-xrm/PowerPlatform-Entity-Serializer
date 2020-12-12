using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class EntityConverter : JsonConverter<Entity>, IObjectContractConverter
    {
        public const string TypeSchema = "Entity:http://schemas.microsoft.com/xrm/2011/Contracts";

        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<AttributeCollection> attributeCollectionConverter;
        private JsonConverter<FormattedValueCollection> formattedValueCollectionConverter;
        private JsonConverter<KeyAttributeCollection> keyAttributeCollectionConverter;
        private JsonConverter<RelatedEntityCollection> relatedEntityCollectionConverter;

        public EntityConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = new Entity();

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
                    case nameof(value.Attributes):
                        if (attributeCollectionConverter == null) attributeCollectionConverter = (JsonConverter<AttributeCollection>)entitySerializerOptions.converters[typeof(AttributeCollection)];
                        var attributes = attributeCollectionConverter.Read(ref reader, typeof(AttributeCollection), options);
                        foreach (var item in attributes)
                        {
                            value.Attributes.Add(item);
                        }
                        break;
                    case nameof(value.EntityState):
                        value.EntityState = reader.TokenType == JsonTokenType.Null ? default(EntityState?) : (EntityState)reader.GetInt32();
                        break;
                    case nameof(value.FormattedValues):
                        if (formattedValueCollectionConverter == null) formattedValueCollectionConverter = (JsonConverter<FormattedValueCollection>)entitySerializerOptions.converters[typeof(FormattedValueCollection)];
                        var formattedValues = formattedValueCollectionConverter.Read(ref reader, typeof(FormattedValueCollection), options);
                        foreach (var item in formattedValues)
                        {
                            value.FormattedValues.Add(item);
                        }
                        break;
                    case nameof(value.HasLazyFileAttribute):
                        value.HasLazyFileAttribute = reader.GetBoolean();
                        break;
                    case nameof(value.Id):
                        value.Id = reader.GetGuid();
                        break;
                    case nameof(value.KeyAttributes):
                        if (keyAttributeCollectionConverter == null) keyAttributeCollectionConverter = (JsonConverter<KeyAttributeCollection>)entitySerializerOptions.converters[typeof(KeyAttributeCollection)];
                        var keyAttributes = keyAttributeCollectionConverter.Read(ref reader, typeof(KeyAttributeCollection), options);
                        foreach (var item in keyAttributes)
                        {
                            value.KeyAttributes.Add(item);
                        }
                        break;
                    case nameof(value.LazyFileAttributeKey):
                        value.LazyFileAttributeKey = reader.GetString();
                        break;
                    case nameof(value.LazyFileAttributeValue):
                        value.LazyFileAttributeValue = new Lazy<object>(JsonSerializer.Deserialize<object>(ref reader, options));
                        break;
                    case nameof(value.LazyFileSizeAttributeKey):
                        value.LazyFileSizeAttributeKey = reader.GetString();
                        break;
                    case nameof(value.LazyFileSizeAttributeValue):
                        value.LazyFileSizeAttributeValue = reader.GetInt32();
                        break;
                    case nameof(value.LogicalName):
                        value.LogicalName = reader.GetString();
                        break;
                    case nameof(value.RelatedEntities):
                        if (relatedEntityCollectionConverter == null) relatedEntityCollectionConverter = (JsonConverter<RelatedEntityCollection>)entitySerializerOptions.converters[typeof(RelatedEntityCollection)];
                        var relatedEntities = relatedEntityCollectionConverter.Read(ref reader, typeof(RelatedEntityCollection), options);
                        foreach (var item in relatedEntities)
                        {
                            value.RelatedEntities.Add(item);
                        }
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

        public override Entity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(Entity));

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            return (Entity)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, Entity value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            var writingSchema = entitySerializerOptions.writingSchema;
            if (writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                entitySerializerOptions.writingSchema = true;
            }
            writer.WritePropertyName(nameof(value.Attributes));
            attributeCollectionConverter.Write(writer, value.Attributes, options);
            entitySerializerOptions.writingSchema = writingSchema;
            if (value.EntityState.HasValue)
            {
                writer.WriteNumber(nameof(value.EntityState), (int)value.EntityState);
            }

            writer.WriteEndObject();
        }
    }
}
