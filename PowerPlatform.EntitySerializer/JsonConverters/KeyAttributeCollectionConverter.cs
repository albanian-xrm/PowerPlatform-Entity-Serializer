using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class KeyAttributeCollectionConverter : JsonConverter<KeyAttributeCollection>
    {
        private EntitySerializerOptions entitySerializerOptions;
        public KeyAttributeCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override KeyAttributeCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(KeyAttributeCollection));

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var value = new KeyAttributeCollection();
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
                        case "key":
                            itemKey = reader.GetString();
                            break;
                        case "value":
                            switch (reader.TokenType)
                            {
                                case JsonTokenType.True:
                                case JsonTokenType.False:
                                    itemValue = reader.GetBoolean();
                                    break;
                                case JsonTokenType.StartObject:
                                    itemValue = JsonSerializer.Deserialize(ref reader, typeof(object), options);
                                    if (reader.TokenType != JsonTokenType.EndObject)
                                    {
                                        throw new JsonException();
                                    }
                                    break;
                                default:
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

        public override void Write(Utf8JsonWriter writer, KeyAttributeCollection value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
