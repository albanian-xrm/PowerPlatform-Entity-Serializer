using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class FormattedValueCollectionConverter : JsonConverter<FormattedValueCollection>
    {
        public FormattedValueCollectionConverter()
        {
        }

        public override FormattedValueCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var value = new FormattedValueCollection();
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }
                string itemKey = null;
                string itemValue = null;

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
                            if (reader.TokenType != JsonTokenType.String) throw new JsonException();
                            itemValue = reader.GetString();
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

        public override void Write(Utf8JsonWriter writer, FormattedValueCollection value, JsonSerializerOptions options)
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
                writer.WriteString(EntitySerializer.CollectionValuePropertyName, item.Value);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}
