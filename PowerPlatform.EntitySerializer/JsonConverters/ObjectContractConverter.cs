using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ObjectContractConverter : JsonConverter<object>
    {
        private readonly Dictionary<string, IObjectContractConverter> schemaBindings = new Dictionary<string, IObjectContractConverter>();
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<List<object>> listOfObjectsConverter;

        public ObjectContractConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
            foreach (var objectContractConverter in entitySerializerOptions.converters.ObjectContractConverters())
            {
                this.schemaBindings.Add(objectContractConverter.GetTypeSchema(), objectContractConverter);
            }
        }

        public ObjectContractConverter(EntitySerializerOptions entitySerializerOptions, IEnumerable<KeyValuePair<string, IObjectContractConverter>> schemaBindings) : this(entitySerializerOptions)
        {
            foreach (var item in schemaBindings)
            {
                if (this.schemaBindings.ContainsKey(item.Key))
                {
                    continue;
                }
                this.schemaBindings.Add(item.Key, item.Value);
            }
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(object));

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }
            var propertyName = reader.GetString();

            if (propertyName != "__type")
            {
                return ParseAsObject(ref reader, options);
            }
            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
            {
                return ParseAsObject(ref reader, options, isValue: true, propertyName);
            }
            var typeSchema = reader.GetString();
            if (!schemaBindings.TryGetValue(typeSchema, out IObjectContractConverter converter))
            {
                return ParseAsObject(ref reader, options, isValue: true, propertyName);
            }

            return converter.ReadInternal(ref reader, typeToConvert, options);
        }

        private Dictionary<string, object> ParseAsObject(ref Utf8JsonReader reader, JsonSerializerOptions options, bool isValue = false, string key = default)
        {
            var result = new Dictionary<string, object>();

            if (!isValue)
            {
                key = reader.GetString();
                reader.Read();
            }
            object value = ReadValue(ref reader, options);
            result.Add(key, value);
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                key = reader.GetString();
                reader.Read();
                value = ReadValue(ref reader, options);
                result.Add(key, value);
                reader.Read();
            }
            return result;
        }

        private object ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.True:
                case JsonTokenType.False:
                    return reader.GetBoolean();
                case JsonTokenType.StartObject:
                    return Read(ref reader, typeof(object), options);
                case JsonTokenType.StartArray:
                    if (listOfObjectsConverter == null) listOfObjectsConverter = entitySerializerOptions.converters.GetForType<List<object>>();
                    return listOfObjectsConverter.Read(ref reader, typeof(List<object>), options);
                case JsonTokenType.String:
                    return reader.GetString();
                case JsonTokenType.Number:
                    return reader.GetDecimal();
                default:
                    throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {

        }
    }
}
