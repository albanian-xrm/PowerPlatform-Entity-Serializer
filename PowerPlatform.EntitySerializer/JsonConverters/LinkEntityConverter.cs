


using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class LinkEntityConverter : JsonConverter<LinkEntity>, IObjectContractConverter
    {
        public const string TypeSchema = "LinkEntity:http://schemas.microsoft.com/xrm/2011/Contracts";
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<FilterExpression> filterExpressionConverter;
        private JsonConverter<ColumnSet> columnSetConverter;

        public string GetTypeSchema() { return TypeSchema; }

        public LinkEntityConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override LinkEntity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }
            return (LinkEntity)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, LinkEntity value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartObject();

            if (value.Columns != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.Columns));
                JsonSerializer.Serialize(writer, value.Columns, options);
            }

            if (value.EntityAlias != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.EntityAlias));
                writer.WriteStringValue(value.EntityAlias);
            }

            writer.WritePropertyName(nameof(LinkEntity.JoinOperator));
            writer.WriteNumberValue((int)value.JoinOperator);

            if (value.LinkCriteria != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.LinkCriteria));
                JsonSerializer.Serialize(writer, value.LinkCriteria, options);
            }

            if (value.LinkFromAttributeName != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.LinkFromAttributeName));
                writer.WriteStringValue(value.LinkFromAttributeName);
            }

            if (value.LinkFromEntityName != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.LinkFromEntityName));
                writer.WriteStringValue(value.LinkFromEntityName);
            }

            if (value.LinkToAttributeName != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.LinkToAttributeName));
                writer.WriteStringValue(value.LinkToAttributeName);
            }

            if (value.LinkToEntityName != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.LinkToEntityName));
                writer.WriteStringValue(value.LinkToEntityName);
            }

            if (value.LinkEntities != null && value.LinkEntities.Count > 0)
            {
                writer.WritePropertyName(nameof(LinkEntity.LinkEntities));
                writer.WriteStartArray();
                foreach (var linkEntity in value.LinkEntities)
                {
                    JsonSerializer.Serialize(writer, linkEntity, options);
                }
                writer.WriteEndArray();
            }

            if (value.ForceSeek != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.ForceSeek));
                writer.WriteStringValue(value.ForceSeek);
            }

            if (value.ExtensionData != null)
            {
                writer.WritePropertyName(nameof(LinkEntity.ExtensionData));
                JsonSerializer.Serialize(writer, value.ExtensionData, options);
            }

            writer.WriteEndObject();
        }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var linkEntity = new LinkEntity();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return linkEntity;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case nameof(LinkEntity.Columns):
                            if (columnSetConverter == null) { columnSetConverter = entitySerializerOptions.converters.GetForType<ColumnSet>(); }
                            linkEntity.Columns = columnSetConverter.Read(ref reader, typeof(ColumnSet), options);
                            break;
                        case nameof(LinkEntity.EntityAlias):
                            linkEntity.EntityAlias = reader.GetString();
                            break;
                        case nameof(LinkEntity.JoinOperator):
                            linkEntity.JoinOperator = (JoinOperator)reader.GetInt32();
                            break;
                        case nameof(LinkEntity.LinkCriteria):
                            if (filterExpressionConverter == null) { filterExpressionConverter = entitySerializerOptions.converters.GetForType<FilterExpression>(); }
                            linkEntity.LinkCriteria = filterExpressionConverter.Read(ref reader, typeof(FilterExpression), options);
                            break;
                        case nameof(LinkEntity.LinkFromAttributeName):
                            linkEntity.LinkFromAttributeName = reader.GetString();
                            break;
                        case nameof(LinkEntity.LinkFromEntityName):
                            linkEntity.LinkFromEntityName = reader.GetString();
                            break;
                        case nameof(LinkEntity.LinkToAttributeName):
                            linkEntity.LinkToAttributeName = reader.GetString();
                            break;
                        case nameof(LinkEntity.LinkToEntityName):
                            linkEntity.LinkToEntityName = reader.GetString();
                            break;
                        case nameof(LinkEntity.LinkEntities):
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    if (reader.TokenType != JsonTokenType.StartObject)
                                    {
                                        throw new JsonException("Expected StartObject token");
                                    }
                                    linkEntity.LinkEntities.Add((LinkEntity)ReadInternal(ref reader, typeof(LinkEntity), options));
                                }
                            }
                            break;
                        case nameof(LinkEntity.ForceSeek):
                            linkEntity.ForceSeek = reader.GetString();
                            break;
                        case nameof(LinkEntity.ExtensionData):
                            linkEntity.ExtensionData = JsonSerializer.Deserialize<ExtensionDataObject>(ref reader, options);
                            break;
                        default:
                            throw new NotImplementedException($"Unknown property \"{propertyName}\" for LinkEntity type.");
                    }
                }
            }

            throw new JsonException("Expected EndObject token");
        }
    }
}
