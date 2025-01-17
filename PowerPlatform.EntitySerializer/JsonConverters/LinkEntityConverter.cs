


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
            throw new NotImplementedException();
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
                                reader.Read();
                                while (reader.TokenType != JsonTokenType.EndArray)
                                {
                                    if (reader.TokenType != JsonTokenType.StartObject)
                                    {
                                        throw new JsonException("Expected StartObject token");
                                    }
                                    linkEntity.LinkEntities.Add((LinkEntity)ReadInternal(ref reader, typeof(LinkEntity), options));
                                    reader.Read();
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
                return linkEntity;
            }

            throw new JsonException("Expected EndObject token");
        }
    }
}
