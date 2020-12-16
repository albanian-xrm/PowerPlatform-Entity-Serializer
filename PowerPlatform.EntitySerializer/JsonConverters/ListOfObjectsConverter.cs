using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ListOfObjectsConverter<T> : JsonConverter<List<T>>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<T> genericConverter;

        public ListOfObjectsConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(List<T>));

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            List<T> result = new List<T>();
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray) return result;
            genericConverter = entitySerializerOptions.converters.GetForType<T>();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                result.Add(genericConverter.Read(ref reader, typeof(T), options));
                if (reader.TokenType != JsonTokenType.EndObject)
                {
                    throw new JsonException();
                }
                reader.Read();
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
