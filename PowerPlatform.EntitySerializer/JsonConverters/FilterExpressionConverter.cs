using Microsoft.Xrm.Sdk.Query;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class FilterExpressionConverter : JsonConverter<FilterExpression>, IObjectContractConverter
    {
        public const string TypeSchema = "FilterExpression:http://schemas.microsoft.com/xrm/2011/Contracts";
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<FilterExpression> filterExpressionConverter;

        public string GetTypeSchema() { return TypeSchema; }

        public FilterExpressionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override FilterExpression Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }
            return (FilterExpression)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, FilterExpression value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(nameof(FilterExpression.Conditions));
            writer.WriteStartArray();
            foreach (var condition in value.Conditions)
            {
                JsonSerializer.Serialize(writer, condition, options);
            }
            writer.WriteEndArray();

            writer.WritePropertyName(nameof(FilterExpression.FilterOperator));
            writer.WriteNumberValue((int)value.FilterOperator);

            writer.WritePropertyName(nameof(FilterExpression.Filters));
            writer.WriteStartArray();
            foreach (var filter in value.Filters)
            {
                JsonSerializer.Serialize(writer, filter, options);
            }
            writer.WriteEndArray();
            if (value.IsQuickFindFilter == true) {
                writer.WritePropertyName(nameof(FilterExpression.IsQuickFindFilter));
            }

            if (value.FilterHint != null)
            {
                writer.WritePropertyName(nameof(FilterExpression.FilterHint));
                writer.WriteStringValue(value.FilterHint);
            }

            writer.WriteEndObject();
        }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var filterExpression = new FilterExpression();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return filterExpression;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case nameof(FilterExpression.FilterOperator):
                            filterExpression.FilterOperator = (LogicalOperator)reader.GetInt32();
                            break;
                        case nameof(FilterExpression.Conditions):
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                reader.Read();
                                while (reader.TokenType != JsonTokenType.EndArray)
                                {
                                    var conditionExpression = JsonSerializer.Deserialize<ConditionExpression>(ref reader, options);
                                    filterExpression.Conditions.Add(conditionExpression);
                                    reader.Read();
                                }
                            }
                            break;
                        case nameof(FilterExpression.Filters):
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                reader.Read();
                                while (reader.TokenType != JsonTokenType.EndArray)
                                {
                                    if (filterExpressionConverter == null) { filterExpressionConverter = entitySerializerOptions.converters.GetForType<FilterExpression>(); }
                                    var subFilterExpression = filterExpressionConverter.Read(ref reader, typeof(FilterExpression), options);
                                    filterExpression.Filters.Add(subFilterExpression);
                                }
                            }
                            break;
                        case nameof(FilterExpression.IsQuickFindFilter):
                            filterExpression.IsQuickFindFilter = reader.GetBoolean();
                            break;
                        case nameof(FilterExpression.FilterHint):
                            filterExpression.FilterHint = reader.GetString();
                            break;
                        default:
                            throw new NotImplementedException($"Unknown property \"{propertyName}\" for FilterExpression type.");
                    }
                }
            }

            throw new JsonException("Expected EndObject token");
        }
    }
}
