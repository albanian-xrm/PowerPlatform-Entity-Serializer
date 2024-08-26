using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class AttributeCollectionConverter : JsonConverter<AttributeCollection>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<object> objectContractConverter;
        private JsonConverter<DateTime> dateTimeConverter;
        private JsonConverter<Money> moneyConverter;
        private JsonConverter<EntityReference> entityReferenceConverter;
        private JsonConverter<OptionSetValue> optionSetValueConverter;
        private JsonConverter<IList<object>> listOfObjectsConverter;
        private JsonConverter<OptionSetValueCollection> optionSetValueCollectionConverter;

        public AttributeCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public override AttributeCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var value = new AttributeCollection();
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
                            if (reader.TokenType == JsonTokenType.StartArray) // Choices
                            {
                                InitializeOptionSetValueCollectionConverter();
                                itemValue = optionSetValueCollectionConverter.Read(ref reader, typeof(OptionSetValueCollection), options);
                                reader.Read();
                                break;
                            }
                            itemValue = ObjectContractConverter.ReadValue(ref reader, options, entitySerializerOptions, ref objectContractConverter, ref listOfObjectsConverter, itemKey);
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

        public override void Write(Utf8JsonWriter writer, AttributeCollection value, JsonSerializerOptions options)
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

                if (item.Value == null)
                {
                    writer.WriteNullValue();
                }
                else if (item.Value is bool boolValue)
                {
                    writer.WriteBooleanValue(boolValue);
                }
                else if (item.Value is DateTime dateTimeValue)
                {
                    InitializeDateTimeConverter();
                    dateTimeConverter.Write(writer, dateTimeValue, options);
                }
                else if (item.Value is EntityReference entityReferenceValue)
                {
                    InitializeEntityReferenceConverter();
                    entityReferenceConverter.Write(writer, entityReferenceValue, options);
                }
                else if (item.Value is Money moneyValue)
                {
                    InitializeMoneyConverter();
                    moneyConverter.Write(writer, moneyValue, options);
                }
                else if (item.Value is OptionSetValue optionSetValue)
                {
                    InitializeOptionSetValueConverter();
                    optionSetValueConverter.Write(writer, optionSetValue, options);
                }
                else if (item.Value is OptionSetValueCollection optionSetValues)
                {
                    InitializeOptionSetValueCollectionConverter();
                    optionSetValueCollectionConverter.Write(writer, optionSetValues, options);
                }
                else if (item.Value is string stringValue)
                {
                    writer.WriteStringValue(stringValue);
                }
                else
                {
                    InitializeObjectContractConverter();
                    objectContractConverter.Write(writer, item.Value, options);
                }

                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            entitySerializerOptions.writingSchema = writingSchema;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeDateTimeConverter()
        {
            if (dateTimeConverter == null)
                dateTimeConverter = entitySerializerOptions.converters.GetForType<DateTime>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeEntityReferenceConverter()
        {
            if (entityReferenceConverter == null)
                entityReferenceConverter = entitySerializerOptions.converters.GetForType<EntityReference>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeMoneyConverter()
        {
            if (moneyConverter == null)
                moneyConverter = entitySerializerOptions.converters.GetForType<Money>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeOptionSetValueConverter()
        {
            if (optionSetValueConverter == null)
                optionSetValueConverter = entitySerializerOptions.converters.GetForType<OptionSetValue>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeOptionSetValueCollectionConverter()
        {
            if (optionSetValueCollectionConverter == null)
                optionSetValueCollectionConverter = entitySerializerOptions.converters.GetForType<OptionSetValueCollection>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InitializeObjectContractConverter()
        {
            if (objectContractConverter == null)
                objectContractConverter = entitySerializerOptions.converters.GetForType<object>();
        }
    }
}
