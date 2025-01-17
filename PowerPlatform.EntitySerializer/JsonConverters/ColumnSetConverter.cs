using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ColumnSetConverter : JsonConverter<ColumnSet>, IObjectContractConverter
    {
        public const string TypeSchema = "ColumnSet:http://schemas.microsoft.com/xrm/2011/Contracts";
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<AttributeCollection> attributeCollectionConverter;
        private JsonConverter<FormattedValueCollection> formattedValueCollectionConverter;
        private JsonConverter<KeyAttributeCollection> keyAttributeCollectionConverter;
        private JsonConverter<RelatedEntityCollection> relatedEntityCollectionConverter;

        public ColumnSetConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema() { return TypeSchema; }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var columnSet = new ColumnSet();

            reader.Read();
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                string propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case EntitySerializer.TypePropertyName:
                        reader.GetString(); // should check right type?
                        break;
                    case nameof(columnSet.AllColumns):
                        columnSet.AllColumns = reader.GetBoolean();
                        break;
                    case nameof(columnSet.Columns):
                        if (reader.TokenType == JsonTokenType.StartArray)
                        {
                            reader.Read();
                            while (reader.TokenType != JsonTokenType.EndArray)
                            {
                                columnSet.Columns.Add(reader.GetString());
                                reader.Read();
                            }
                        }
                        break;
                    case nameof(columnSet.AttributeExpressions):
                        if (reader.TokenType == JsonTokenType.StartArray)
                        {
                            reader.Read();
                            while (reader.TokenType != JsonTokenType.EndArray)
                            {
                                var attributeExpression = JsonSerializer.Deserialize<XrmAttributeExpression>(ref reader, options);
                                columnSet.AttributeExpressions.Add(attributeExpression);
                                reader.Read();
                            }
                        }
                        break;
                    default:
                        throw new NotImplementedException($"Unknown property \"{propertyName}\" for ColumnSet type.");
                }
                if (!reader.Read())
                {
                    throw new JsonException();
                }
            }
            return columnSet;
        }

        public override ColumnSet Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            return (ColumnSet)ReadInternal(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, ColumnSet value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStartObject();
            if (entitySerializerOptions.writingSchema && entitySerializerOptions.WriteSchema != WriteSchemaOptions.IfNeeded)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }
            writer.WriteBoolean(nameof(value.AllColumns), value.AllColumns);

            writer.WriteStartArray(nameof(value.AttributeExpressions));
            foreach (var attributeExpression in value.AttributeExpressions)
            {
                JsonSerializer.Serialize(writer, attributeExpression, options);
            }
            writer.WriteEndArray();

            writer.WriteStartArray(nameof(value.Columns));
            foreach (var column in value.Columns)
            {
                writer.WriteStringValue(column);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
