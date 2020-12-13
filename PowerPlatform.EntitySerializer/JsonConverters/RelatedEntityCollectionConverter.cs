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
        public RelatedEntityCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override RelatedEntityCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(RelatedEntityCollection));

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
                        case "key":
                            if (reader.TokenType != JsonTokenType.StartObject)
                            {
                                throw new JsonException();
                            }
                            itemKey = JsonSerializer.Deserialize<Relationship>(ref reader, options);
                            if (reader.TokenType != JsonTokenType.EndObject)
                            {
                                throw new JsonException();
                            }
                            break;
                        case "value":

                            if (reader.TokenType != JsonTokenType.StartArray)
                            {
                                throw new JsonException();
                            }
                            itemValue = JsonSerializer.Deserialize<EntityCollection>(ref reader, options);
                            if (reader.TokenType != JsonTokenType.EndArray)
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

        public override void Write(Utf8JsonWriter writer, RelatedEntityCollection value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
