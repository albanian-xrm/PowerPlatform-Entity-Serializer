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
        private JsonConverter<IList<object>> listOfObjectsConverter;

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
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return new object();
            }
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
            JsonConverter<object> temp = this;
            object value = ReadValue(ref reader, options, entitySerializerOptions, ref temp, ref listOfObjectsConverter, key);
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
                value = ReadValue(ref reader, options, entitySerializerOptions, ref temp, ref listOfObjectsConverter, key);
                result.Add(key, value);
                reader.Read();
            }
            return result;
        }

        internal static object ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options, EntitySerializerOptions entitySerializerOptions, ref JsonConverter<object> objectConverter, ref JsonConverter<IList<object>> listOfObjectsConverter, string itemKey)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.True:
                case JsonTokenType.False:
                    return reader.GetBoolean();
                case JsonTokenType.StartObject:
                    if (objectConverter == null) objectConverter = entitySerializerOptions.converters.GetForType<object>();
                    return objectConverter.Read(ref reader, typeof(object), options);
                case JsonTokenType.StartArray:
                    if (listOfObjectsConverter == null) listOfObjectsConverter = entitySerializerOptions.converters.GetForType<IList<object>>();
                    return listOfObjectsConverter.Read(ref reader, typeof(IList<object>), options);
                case JsonTokenType.String:
                    if (itemKey != null && entitySerializerOptions.KnowGuidAttributes.Contains(itemKey))
                    {
                        return reader.GetGuid();
                    }
                    var stringResult = reader.GetString();
                    if (stringResult.StartsWith("/Date(") && stringResult.EndsWith(")/"))
                    {
                        return DateTimeConverter.ConvertFromString(stringResult);
                    }
                    return stringResult;
                case JsonTokenType.Number:
                    var decimalResult = reader.GetDecimal();
                    if (decimalResult % 1 == 0) return (int)decimalResult;
                    return decimalResult;
                default:
                    throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
