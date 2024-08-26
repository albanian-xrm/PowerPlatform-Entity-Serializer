using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class RelatedEntityCollectionConverter : JsonConverter<RelatedEntityCollection>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<Relationship> relationshipConverter;
        private JsonConverter<EntityCollection> entityCollectionConverter;

        public RelatedEntityCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override RelatedEntityCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var value = new RelatedEntityCollection();
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                Relationship itemKey = null;
                EntityCollection itemValue = null;

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
                            if (relationshipConverter == null) relationshipConverter = entitySerializerOptions.converters.GetForType<Relationship>();
                            itemKey = relationshipConverter.Read(ref reader, typeof(Relationship), options);
                            reader.Read();
                            break;
                        case EntitySerializer.CollectionValuePropertyName:
                            if (entityCollectionConverter == null) entityCollectionConverter = entitySerializerOptions.converters.GetForType<EntityCollection>();
                            itemValue = entityCollectionConverter.Read(ref reader, typeof(EntityCollection), options);
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

        public override void Write(Utf8JsonWriter writer, RelatedEntityCollection value, JsonSerializerOptions options)
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
                writer.WritePropertyName(EntitySerializer.CollectionKeyPropertyName);
                if (relationshipConverter == null) relationshipConverter = entitySerializerOptions.converters.GetForType<Relationship>();
                relationshipConverter.Write(writer, item.Key, options);

                writer.WritePropertyName(EntitySerializer.CollectionValuePropertyName);
                if (entityCollectionConverter == null) entityCollectionConverter = entitySerializerOptions.converters.GetForType<EntityCollection>();
                entityCollectionConverter.Write(writer, item.Value, options);

                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}
