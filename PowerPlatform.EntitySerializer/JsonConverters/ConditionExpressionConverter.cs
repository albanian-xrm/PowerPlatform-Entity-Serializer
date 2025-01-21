using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ConditionExpressionConverter : JsonConverter<ConditionExpression>, IObjectContractConverter
    {
        public const string TypeSchema = "ConditionExpression:http://schemas.microsoft.com/xrm/2011/Contracts";
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<FilterExpression> filterExpressionConverter;
        private JsonConverter<LinkEntity> linkEntityConverter;
        private JsonConverter<object> objectContractConverter;
        private JsonConverter<IList<object>> listOfObjectsConverter;

        public string GetTypeSchema() { return TypeSchema; }

        public ConditionExpressionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override ConditionExpression Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }
            return (ConditionExpression)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, ConditionExpression value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartObject();

            if (value.AttributeName != null)
            {
                writer.WriteString(nameof(ConditionExpression.AttributeName), value.AttributeName);
            }

            writer.WriteBoolean(nameof(ConditionExpression.CompareColumns), value.CompareColumns);
            writer.WriteNumber(nameof(ConditionExpression.Operator), (int)value.Operator);
            if (value.Values != null && value.Values.Count > 0)
            {
                writer.WritePropertyName(nameof(ConditionExpression.Values));
                writer.WriteStartArray();
                foreach (var val in value.Values)
                {
                    JsonSerializer.Serialize(writer, val, options);
                }
                writer.WriteEndArray();
            }

            writer.WriteString(nameof(ConditionExpression.EntityName), value.EntityName);

            writer.WriteEndObject();
        }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var conditionExpression = new ConditionExpression();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return conditionExpression;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case nameof(ConditionExpression.AttributeName):
                            conditionExpression.AttributeName = reader.GetString();
                            break;
                        case nameof(ConditionExpression.Operator):
                            conditionExpression.Operator = (ConditionOperator)reader.GetInt32();
                            break;
                        case nameof(ConditionExpression.EntityName):
                            conditionExpression.EntityName = reader.GetString();
                            break;
                        case nameof(ConditionExpression.Values):
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    conditionExpression.Values.Add(ObjectContractConverter.ReadValue(ref reader, options, entitySerializerOptions, ref objectContractConverter, ref listOfObjectsConverter, null));
                                }
                            }
                            break;
                        case nameof(ConditionExpression.CompareColumns):
                            conditionExpression.CompareColumns = reader.GetBoolean();
                            break;
                        default:
                            throw new NotSupportedException($"Property {propertyName} not supported");
                    }
                }
            }

            throw new JsonException("Expected EndObject token");
        }
    }
}
