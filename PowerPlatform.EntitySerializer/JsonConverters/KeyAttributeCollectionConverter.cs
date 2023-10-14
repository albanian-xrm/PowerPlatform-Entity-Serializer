using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class KeyAttributeCollectionConverter : JsonConverter<KeyAttributeCollection>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<object> objectContractConverter;
        private JsonConverter<decimal> decimalConverter;
        private JsonConverter<int> integerConverter;
        private JsonConverter<DateTime> dateTimeConverter;
        private JsonConverter<EntityReference> lookupConverter;
        private JsonConverter<OptionSetValue> picklistConverter;
        private JsonConverter<IList<object>> listOfObjectsConverter;

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

        public override void Write(Utf8JsonWriter writer, KeyAttributeCollection value, JsonSerializerOptions options)
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

                if (item.Value is int intValue)
                {
                    InitializeIntegerConverter();
                    integerConverter.Write(writer, intValue, options);
                }
                else if (item.Value is string stringValue)
                {
                    writer.WriteStringValue(stringValue);
                }
                else if (item.Value is DateTime dateTimeValue)
                {
                    InitializeDateTimeConverter();
                    dateTimeConverter.Write(writer, dateTimeValue, options);
                }
                else if (item.Value is EntityReference entityReferenceValue)
                {
                    InitializeLookupConverter();
                    lookupConverter.Write(writer, entityReferenceValue, options);
                }
                else
                {
                    throw new JsonException("Unexpected type serializing KeyAttribute with key: " + item.Key);
                }

                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            entitySerializerOptions.writingSchema = writingSchema;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeDecimalConverter()
        {
            if (decimalConverter == null)
                decimalConverter = entitySerializerOptions.converters.GetForType<decimal>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeIntegerConverter()
        {
            if (integerConverter == null)
                integerConverter = entitySerializerOptions.converters.GetForType<int>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeDateTimeConverter()
        {
            if (dateTimeConverter == null)
                dateTimeConverter = entitySerializerOptions.converters.GetForType<DateTime>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeLookupConverter()
        {
            if (lookupConverter == null)
                lookupConverter = entitySerializerOptions.converters.GetForType<EntityReference>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializePicklistConverter()
        {
            if (picklistConverter == null)
                picklistConverter = entitySerializerOptions.converters.GetForType<OptionSetValue>();
        }
    }
}
