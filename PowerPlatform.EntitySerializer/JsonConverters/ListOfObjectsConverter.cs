 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ListOfObjectsConverter<T> : JsonConverter<IList<T>>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<T> genericConverter;

        public ListOfObjectsConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override IList<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(IList<T>));

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            List<T> result = new List<T>();
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray) return result;
            if (genericConverter == null) genericConverter = entitySerializerOptions.converters.GetForType<T>();
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

        public override void Write(Utf8JsonWriter writer, IList<T> value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartArray();
            if (genericConverter == null) genericConverter = entitySerializerOptions.converters.GetForType<T>();
            foreach (var item in value)
            {
                genericConverter.Write(writer, item, options);
            }
            writer.WriteEndArray();
        }
    }
}
