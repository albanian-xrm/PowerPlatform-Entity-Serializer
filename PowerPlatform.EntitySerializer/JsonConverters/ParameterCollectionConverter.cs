using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ParameterCollectionConverter : JsonConverter<ParameterCollection>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<object> objectContractConverter;
        private JsonConverter<IList<object>> listOfObjectsConverter;

        public ParameterCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override ParameterCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(ParameterCollection));

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var value = new ParameterCollection();
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                string itemKey = null;
                object itemValue = null;

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
                            itemValue = ObjectContractConverter.ReadValue(ref reader, options, entitySerializerOptions, ref objectContractConverter, ref listOfObjectsConverter);
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

        public override void Write(Utf8JsonWriter writer, ParameterCollection value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            var writingSchema = entitySerializerOptions.writingSchema;
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                writingSchema = true;
            }
            writer.WriteStartArray();
            foreach (var item in value)
            {
                writer.WriteStartObject();
                writer.WriteString(EntitySerializer.CollectionKeyPropertyName, item.Key);

                writer.WritePropertyName(EntitySerializer.CollectionValuePropertyName);
                if (objectContractConverter == null) objectContractConverter = entitySerializerOptions.converters.GetForType<object>();
                objectContractConverter.Write(writer, item.Value, options);

                writer.WriteEndObject();
            }
            entitySerializerOptions.writingSchema = writingSchema;
        }
    }
}
