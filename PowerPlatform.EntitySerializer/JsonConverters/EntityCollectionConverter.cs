using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class EntityCollectionConverter : JsonConverter<EntityCollection>, IObjectContractConverter
    {
        public const string TypeSchema = "EntityCollection:http://schemas.microsoft.com/xrm/2011/Contracts";

        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<IList<Entity>> listOfEntititiesConverter;

        public EntityCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = new EntityCollection();
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
                    case nameof(value.Entities):
                        if (listOfEntititiesConverter == null) listOfEntititiesConverter = entitySerializerOptions.converters.GetForType<IList<Entity>>();
                        var attributes = listOfEntititiesConverter.Read(ref reader, typeof(List<Entity>), options);
                        foreach (var item in attributes)
                        {
                            value.Entities.Add(item);
                        }
                        break;
                    case nameof(value.EntityName):
                        value.EntityName = reader.GetString();
                        break;
                    case nameof(value.MinActiveRowVersion):
                        value.MinActiveRowVersion = reader.GetString();
                        break;
                    case nameof(value.MoreRecords):
                        value.MoreRecords = reader.GetBoolean();
                        break;
                    case nameof(value.PagingCookie):
                        value.PagingCookie = reader.GetString();
                        break;
                    case nameof(value.TotalRecordCount):
                        value.TotalRecordCount = reader.GetInt32();
                        break;
                    case nameof(value.TotalRecordCountLimitExceeded):
                        value.TotalRecordCountLimitExceeded = reader.GetBoolean();
                        break;
                    default:
                        if (entitySerializerOptions.Strictness == Strictness.Strict)
                        {
                            throw new JsonException($"Unknknown property \"{propertyName}\" for EntityCollection type.");
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

        public override EntityCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            return (EntityCollection)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, EntityCollection value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartObject();
            var writingSchema = entitySerializerOptions.writingSchema;
            if (writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                entitySerializerOptions.writingSchema = false;
            }

            writer.WritePropertyName(nameof(value.Entities));
            if (listOfEntititiesConverter == null) listOfEntititiesConverter = entitySerializerOptions.converters.GetForType<IList<Entity>>();
            listOfEntititiesConverter.Write(writer, value.Entities, options);

            writer.WriteString(nameof(value.EntityName), value.EntityName);
            writer.WriteString(nameof(value.MinActiveRowVersion), value.MinActiveRowVersion);
            writer.WriteBoolean(nameof(value.MoreRecords), value.MoreRecords);
            writer.WriteString(nameof(value.PagingCookie), value.PagingCookie);
            writer.WriteNumber(nameof(value.TotalRecordCount), value.TotalRecordCount);
            writer.WriteBoolean(nameof(value.TotalRecordCountLimitExceeded), value.TotalRecordCountLimitExceeded);

            entitySerializerOptions.writingSchema = writingSchema;
            writer.WriteEndObject();
        }
    }
}
