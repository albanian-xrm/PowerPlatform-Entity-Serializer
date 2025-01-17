using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class QueryExpressionConverter : JsonConverter<QueryExpression>, IObjectContractConverter
    {
        public const string TypeSchema = "QueryExpression:http://schemas.microsoft.com/xrm/2011/Contracts";
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<ColumnSet> columnSetConverter;
        private JsonConverter<FilterExpression> filterExpressionConverter;
        private JsonConverter<LinkEntity> linkEntityConverter;

        public string GetTypeSchema() { return TypeSchema; }

        public QueryExpressionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override QueryExpression Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }
            return (QueryExpression)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, QueryExpression value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartObject();

            var writingSchema = entitySerializerOptions.writingSchema;
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded || writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                entitySerializerOptions.writingSchema = false;
            }

            if (value.ColumnSet != null)
            {
                if (columnSetConverter == null) columnSetConverter = entitySerializerOptions.converters.GetForType<ColumnSet>();
                writer.WritePropertyName(nameof(QueryExpression.ColumnSet));
                columnSetConverter.Write(writer, value.ColumnSet, options);
            }

            if (value.Criteria != null)
            {
                if (filterExpressionConverter == null) filterExpressionConverter = entitySerializerOptions.converters.GetForType<FilterExpression>();
                writer.WritePropertyName(nameof(QueryExpression.Criteria));
                filterExpressionConverter.Write(writer, value.Criteria, options);
            }

            writer.WriteBoolean(nameof(QueryExpression.Distinct), value.Distinct);
            writer.WriteString(nameof(QueryExpression.EntityName), value.EntityName);

            if (linkEntityConverter == null) linkEntityConverter = entitySerializerOptions.converters.GetForType<LinkEntity>();
            writer.WritePropertyName(nameof(QueryExpression.LinkEntities));
            writer.WriteStartArray();
            if (value.LinkEntities != null)
            {
                foreach (var linkEntity in value.LinkEntities)
                {
                    linkEntityConverter.Write(writer, linkEntity, options);
                }
            }
            writer.WriteEndArray();

            if (value.Orders != null && value.Orders.Count > 0)
            {
                writer.WritePropertyName(nameof(QueryExpression.Orders));
                writer.WriteStartArray();
                foreach (var order in value.Orders)
                {
                    JsonSerializer.Serialize(writer, order, options);
                }
                writer.WriteEndArray();
            }

            if (value.PageInfo != null)
            {
                writer.WritePropertyName(nameof(QueryExpression.PageInfo));
                JsonSerializer.Serialize(writer, value.PageInfo, options);
            }

            if (value.TopCount.HasValue)
            {
                writer.WriteNumber(nameof(QueryExpression.TopCount), value.TopCount.Value);
            }


            writer.WriteBoolean(nameof(QueryExpression.NoLock), value.NoLock);
            if (value.QueryHints != null)
            {
                writer.WriteString(nameof(QueryExpression.QueryHints), value.QueryHints);
            }

            entitySerializerOptions.writingSchema = writingSchema;
            writer.WriteEndObject();
        }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var queryExpression = new QueryExpression();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return queryExpression;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case nameof(QueryExpression.EntityName):
                            queryExpression.EntityName = reader.GetString();
                            break;
                        case nameof(QueryExpression.ColumnSet):
                            if (columnSetConverter == null) columnSetConverter = entitySerializerOptions.converters.GetForType<ColumnSet>();
                            queryExpression.ColumnSet = columnSetConverter.Read(ref reader, typeof(ColumnSet), options);
                            break;
                        case nameof(QueryExpression.Criteria):
                            if (filterExpressionConverter == null) filterExpressionConverter = entitySerializerOptions.converters.GetForType<FilterExpression>();
                            queryExpression.Criteria = filterExpressionConverter.Read(ref reader, typeof(FilterExpression), options);
                            break;
                        case nameof(QueryExpression.Orders):
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    var orderExpression = JsonSerializer.Deserialize<OrderExpression>(ref reader, options);
                                    queryExpression.Orders.Add(orderExpression);
                                }
                            }
                            break;
                        case nameof(QueryExpression.PageInfo):
                            queryExpression.PageInfo = JsonSerializer.Deserialize<PagingInfo>(ref reader, options);
                            break;
                        case nameof(QueryExpression.TopCount):
                            queryExpression.TopCount = reader.GetInt32();
                            break;
                        case nameof(QueryExpression.Distinct):
                            queryExpression.Distinct = reader.GetBoolean();
                            break;
                        case nameof(QueryExpression.LinkEntities):
                            if (linkEntityConverter == null) linkEntityConverter = entitySerializerOptions.converters.GetForType<LinkEntity>();
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    var linkEntity = linkEntityConverter.Read(ref reader, typeof(LinkEntity), options);
                                    queryExpression.LinkEntities.Add(linkEntity);
                                }
                            }
                            break;
                        case nameof(QueryExpression.NoLock):
                            queryExpression.NoLock = reader.GetBoolean();
                            break;
                        case nameof(QueryExpression.QueryHints):
                            queryExpression.QueryHints = reader.GetString();
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            throw new JsonException("Expected EndObject token");
        }
    }
}
