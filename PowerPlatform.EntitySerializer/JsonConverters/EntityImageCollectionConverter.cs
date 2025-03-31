using Microsoft.Xrm.Sdk;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class EntityImageCollectionConverter : JsonConverter<EntityImageCollection>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<Entity> entityConverter;

        public EntityImageCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override EntityImageCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var value = new EntityImageCollection();
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                string itemKey = null;
                Entity itemValue = null;
                for (int index = 0; index < 2; index++)
                {
                    reader.Read();
                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        throw new JsonException();
                    }
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case EntitySerializer.CollectionKeyPropertyName:
                            itemKey = reader.GetString();
                            break;
                        case EntitySerializer.CollectionValuePropertyName:
                            if (entityConverter == null) entityConverter = entitySerializerOptions.converters.GetForType<Entity>();
                            itemValue = entityConverter.Read(ref reader, typeof(Entity), options);
                            if (reader.TokenType != JsonTokenType.EndObject)
                            {
                                throw new JsonException();
                            }
                            reader.Read();
                            break;
                        default:
                            throw new JsonException();
                    }
                }
                if (reader.TokenType != JsonTokenType.EndObject)
                {
                    throw new JsonException();
                }
                reader.Read();
                value.Add(itemKey, itemValue);
            }
            return value;
        }

        public override void Write(Utf8JsonWriter writer, EntityImageCollection value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartArray();
            foreach (var item in value)
            {
                writer.WriteStartObject();
                writer.WriteString(EntitySerializer.CollectionKeyPropertyName, item.Key);

                writer.WritePropertyName(EntitySerializer.CollectionValuePropertyName);
                if (entityConverter == null) entityConverter = entitySerializerOptions.converters.GetForType<Entity>();
                entityConverter.Write(writer, item.Value, options);

                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}
