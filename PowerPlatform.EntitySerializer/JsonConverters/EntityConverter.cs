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
                    case EntitySerializer.TypePropertyName:
                        reader.GetString(); // should check right type?
                        break;
                    case nameof(value.Attributes):
                        if (attributeCollectionConverter == null) attributeCollectionConverter = entitySerializerOptions.converters.GetForType<AttributeCollection>();
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
                        if (formattedValueCollectionConverter == null) formattedValueCollectionConverter = entitySerializerOptions.converters.GetForType<FormattedValueCollection>();
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
                        if (keyAttributeCollectionConverter == null) keyAttributeCollectionConverter = entitySerializerOptions.converters.GetForType<KeyAttributeCollection>();
                        var keyAttributes = keyAttributeCollectionConverter.Read(ref reader, typeof(KeyAttributeCollection), options);
                        foreach (var item in keyAttributes)
                        {
                            value.KeyAttributes.Add(item);
                        }
                        break;
                    case nameof(value.LazyFileAttributeKey):
                        value.LazyFileAttributeKey = reader.GetString();
                        break;
#if !NET462 && !NET472 && !NET48
                    case nameof(value.LazyFileAttributeValue):
                        value.LazyFileAttributeValue = new Lazy<object>(JsonSerializer.Deserialize<object>(ref reader, options));
                        break;
#endif
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
                        if (relatedEntityCollectionConverter == null) relatedEntityCollectionConverter = entitySerializerOptions.converters.GetForType<RelatedEntityCollection>();
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
                        if (entitySerializerOptions.Strictness == Strictness.Strict)
                        {
                            throw new JsonException($"Unknknown property \"{propertyName}\" for Entity type.");
                        } else
                        {
                            reader.Skip();
                            break;
                        }
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
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                writingSchema = true;
            }
            if (writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            if (attributeCollectionConverter == null) attributeCollectionConverter = entitySerializerOptions.converters.GetForType<AttributeCollection>();
            Serialize(writer, options, attributeCollectionConverter, nameof(value.Attributes), value.Attributes);
            if (value.EntityState.HasValue)
            {
                writer.WriteNumber(nameof(value.EntityState), (int)value.EntityState);
            } else
            {
                writer.WriteNull(nameof(value.EntityState));
            }
            if (formattedValueCollectionConverter == null) formattedValueCollectionConverter = entitySerializerOptions.converters.GetForType<FormattedValueCollection>();
            Serialize(writer, options, formattedValueCollectionConverter, nameof(value.FormattedValues), value.FormattedValues);
            if (value.HasLazyFileAttribute)
            {
                writer.WriteBoolean(nameof(value.HasLazyFileAttribute), value.HasLazyFileAttribute);
            }
            writer.WriteString(nameof(value.Id), value.Id);
            if (keyAttributeCollectionConverter == null) keyAttributeCollectionConverter = entitySerializerOptions.converters.GetForType<KeyAttributeCollection>();
            Serialize(writer, options, keyAttributeCollectionConverter, nameof(value.KeyAttributes), value.KeyAttributes);
            if (value.LazyFileAttributeKey != null)
            {
                writer.WriteString(nameof(value.LazyFileAttributeKey), value.LazyFileAttributeKey);
            }
            //ToDo: serialize value.LazyFileAttributeValue 
            if (value.LazyFileSizeAttributeKey != null)
            {
                writer.WriteString(nameof(value.LazyFileSizeAttributeKey), value.LazyFileSizeAttributeKey);
            }
            if (value.LazyFileSizeAttributeValue != 0)
            {
                writer.WriteNumber(nameof(value.LazyFileSizeAttributeValue), value.LazyFileSizeAttributeValue);
            }
            writer.WriteString(nameof(value.LogicalName), value.LogicalName);
            if (relatedEntityCollectionConverter == null) relatedEntityCollectionConverter = entitySerializerOptions.converters.GetForType<RelatedEntityCollection>();
            Serialize(writer, options, relatedEntityCollectionConverter, nameof(value.RelatedEntities), value.RelatedEntities);
            if (value.RowVersion != null)
            {
                writer.WriteString(nameof(value.RowVersion), value.RowVersion);
            } else
            {
                writer.WriteNull(nameof(value.RowVersion));
            }
            writer.WriteEndObject();
            entitySerializerOptions.writingSchema = writingSchema;
        }

        private void Serialize<T>(Utf8JsonWriter writer, JsonSerializerOptions options, JsonConverter<T> converter, string propertyName, T value)
        {
            writer.WritePropertyName(propertyName);
            converter.Write(writer, value, options);
        }
    }
}
