﻿using Microsoft.Xrm.Sdk;
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
        private JsonConverter<List<object>> listOfObjectsConverter;

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
                                    if (objectContractConverter == null) objectContractConverter = entitySerializerOptions.converters.GetForType<object>();
                                    itemValue = objectContractConverter.Read(ref reader, typeof(object), options);
                                    if (reader.TokenType != JsonTokenType.EndObject)
                                    {
                                        throw new JsonException();
                                    }
                                    break;
                                case JsonTokenType.StartArray:
                                    if (listOfObjectsConverter == null) listOfObjectsConverter = entitySerializerOptions.converters.GetForType<List<object>>();
                                    itemValue = listOfObjectsConverter.Read(ref reader, typeof(List<object>), options);
                                    if (reader.TokenType != JsonTokenType.EndArray)
                                    {
                                        throw new JsonException();
                                    }
                                    break;
                                case JsonTokenType.String:
                                    itemValue = reader.GetString();
                                    break;
                                case JsonTokenType.Number:
                                    itemValue = reader.GetDecimal();
                                    break;
                                case JsonTokenType.Null:
                                    itemValue = null;
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

        public override void Write(Utf8JsonWriter writer, ParameterCollection value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
