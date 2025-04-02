using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class ObjectContractConverter : JsonConverter<object>
    {
        private readonly Dictionary<string, IObjectContractConverter> schemaBindings = new Dictionary<string, IObjectContractConverter>();
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<IList<object>> listOfObjectsConverter;
        private JsonConverter<KeyValuePair<string, string>> kvpStringStringConverter;
        private JsonConverter<double> doubleConverter;

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
                    var collection = listOfObjectsConverter.Read(ref reader, typeof(ICollection<object>), options);
                    ///SharedVariables may contain ChangedEntityTypes which is actually a Dictionary and not a List
                    if (collection.All(x => x?.GetType() == typeof(KeyValuePair<string, string>)))
                    {
                        return collection.Cast<KeyValuePair<string, string>>().ToDictionary(x => x.Key, x => x.Value);
                    }
                    return collection;
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
                    if (reader.TryGetDecimal(out var decimalResult))
                    {
                        if (reader.ValueSpan.IndexOf((byte)'.') >= 0 || decimalResult % 1 != 0 || decimalResult > int.MaxValue || decimalResult < int.MinValue)
                        {
                            return decimalResult;
                        }
                        else
                        {
                            return (int)decimalResult;
                        }
                    }
                    else if (reader.TryGetDouble(out var doubleResult))
                    {
                        return doubleResult;
                    }
                    else
                    {
                        throw new JsonException();
                    }
                default:
                    if (entitySerializerOptions.Strictness == Strictness.Strict)
                    {
                        throw new JsonException($"We don't know how to handle value of type {reader.TokenType}");
                    }
                    else
                    {
                        return null;
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            switch (value)
            {
                case bool boolValue:
                    writer.WriteBooleanValue(boolValue);
                    break;
                case int intValue:
                    writer.WriteNumberValue(intValue);
                    break;
                case decimal decimalValue:
                    writer.WriteNumberValue(decimalValue);
                    break;
                case double doubleValue:
                    if (doubleConverter == null) doubleConverter = entitySerializerOptions.converters.GetForType<double>();
                    doubleConverter.Write(writer, doubleValue, options);
                    break;
                case string stringValue:
                    writer.WriteStringValue(stringValue);
                    break;
                case Guid guidValue:
                    var guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                    guidConverter.Write(writer, guidValue, options);
                    break;
                case DateTime dateTimeValue:
                    var dateTimeConverter = entitySerializerOptions.converters.GetForType<DateTime>();
                    dateTimeConverter.Write(writer, dateTimeValue, options);
                    break;
                case ICollection<KeyValuePair<string, string>> collection:
                    writer.WriteStartArray();
                    if (kvpStringStringConverter == null) kvpStringStringConverter = entitySerializerOptions.converters.GetForType<KeyValuePair<string, string>>();
                    foreach (var item in collection)
                    {
                        kvpStringStringConverter.Write(writer, item, options);
                    }
                    writer.WriteEndArray();
                    break;
                case IList<object> listValue:
                    JsonConverter<IList<object>> listConverter = entitySerializerOptions.converters.GetForType<IList<object>>();
                    listConverter.Write(writer, listValue, options);
                    break;
                case Dictionary<string, object> dictValue:
                    writer.WriteStartObject();
                    foreach (var kvp in dictValue)
                    {
                        writer.WritePropertyName(kvp.Key);
                        Write(writer, kvp.Value, options);
                    }
                    writer.WriteEndObject();
                    break;
                case KeyValuePair<string, string> kvp:
                    if (kvpStringStringConverter == null) kvpStringStringConverter = entitySerializerOptions.converters.GetForType<KeyValuePair<string, string>>();
                    kvpStringStringConverter.Write(writer, kvp, options);
                    break;
                case AttributeCollection attributeCollectionValue:
                    JsonConverter<AttributeCollection> attributeCollectionConverter = entitySerializerOptions.converters.GetForType<AttributeCollection>();
                    attributeCollectionConverter.Write(writer, attributeCollectionValue, options);
                    break;
                case ColumnSet columnSetValue:
                    JsonConverter<ColumnSet> columnSetConverter = entitySerializerOptions.converters.GetForType<ColumnSet>();
                    columnSetConverter.Write(writer, columnSetValue, options);
                    break;
                case ConditionExpression conditionExpressionValue:
                    JsonConverter<ConditionExpression> conditionExpressionConverter = entitySerializerOptions.converters.GetForType<ConditionExpression>();
                    conditionExpressionConverter.Write(writer, conditionExpressionValue, options);
                    break;
                case EntityCollection entityCollectionValue:
                    JsonConverter<EntityCollection> entityCollectionConverter = entitySerializerOptions.converters.GetForType<EntityCollection>();
                    entityCollectionConverter.Write(writer, entityCollectionValue, options);
                    break;
                case Entity entityValue:
                    JsonConverter<Entity> entityConverter = entitySerializerOptions.converters.GetForType<Entity>();
                    entityConverter.Write(writer, entityValue, options);
                    break;
                case EntityImageCollection entityImageCollectionValue:
                    JsonConverter<EntityImageCollection> entityImageCollectionConverter = entitySerializerOptions.converters.GetForType<EntityImageCollection>();
                    entityImageCollectionConverter.Write(writer, entityImageCollectionValue, options);
                    break;
                case EntityReference entityReferenceValue:
                    JsonConverter<EntityReference> entityReferenceConverter = entitySerializerOptions.converters.GetForType<EntityReference>();
                    entityReferenceConverter.Write(writer, entityReferenceValue, options);
                    break;
                case FilterExpression filterExpressionValue:
                    JsonConverter<FilterExpression> filterExpressionConverter = entitySerializerOptions.converters.GetForType<FilterExpression>();
                    filterExpressionConverter.Write(writer, filterExpressionValue, options);
                    break;
                case FormattedValueCollection formattedValueCollectionValue:
                    JsonConverter<FormattedValueCollection> formattedValueCollectionConverter = entitySerializerOptions.converters.GetForType<FormattedValueCollection>();
                    formattedValueCollectionConverter.Write(writer, formattedValueCollectionValue, options);
                    break;
                case KeyAttributeCollection keyAttributeCollectionValue:
                    JsonConverter<KeyAttributeCollection> keyAttributeCollectionConverter = entitySerializerOptions.converters.GetForType<KeyAttributeCollection>();
                    keyAttributeCollectionConverter.Write(writer, keyAttributeCollectionValue, options);
                    break;
                case LinkEntity linkEntityValue:
                    JsonConverter<LinkEntity> linkEntityConverter = entitySerializerOptions.converters.GetForType<LinkEntity>();
                    linkEntityConverter.Write(writer, linkEntityValue, options);
                    break;
                case Money moneyValue:
                    JsonConverter<Money> moneyConverter = entitySerializerOptions.converters.GetForType<Money>();
                    moneyConverter.Write(writer, moneyValue, options);
                    break;
                case OptionSetValue optionSetValue:
                    JsonConverter<OptionSetValue> optionSetValueConverter = entitySerializerOptions.converters.GetForType<OptionSetValue>();
                    optionSetValueConverter.Write(writer, optionSetValue, options);
                    break;
                case OptionSetValueCollection optionSetValueCollectionValue:
                    JsonConverter<OptionSetValueCollection> optionSetValueCollectionConverter = entitySerializerOptions.converters.GetForType<OptionSetValueCollection>();
                    optionSetValueCollectionConverter.Write(writer, optionSetValueCollectionValue, options);
                    break;
                case ParameterCollection parameterCollectionValue:
                    JsonConverter<ParameterCollection> parameterCollectionConverter = entitySerializerOptions.converters.GetForType<ParameterCollection>();
                    parameterCollectionConverter.Write(writer, parameterCollectionValue, options);
                    break;
                case QueryExpression queryExpressionValue:
                    JsonConverter<QueryExpression> queryExpressionConverter = entitySerializerOptions.converters.GetForType<QueryExpression>();
                    queryExpressionConverter.Write(writer, queryExpressionValue, options);
                    break;
                case RelatedEntityCollection relatedEntityCollectionValue:
                    JsonConverter<RelatedEntityCollection> relatedEntityCollectionConverter = entitySerializerOptions.converters.GetForType<RelatedEntityCollection>();
                    relatedEntityCollectionConverter.Write(writer, relatedEntityCollectionValue, options);
                    break;
                case Relationship relationshipValue:
                    JsonConverter<Relationship> relationshipConverter = entitySerializerOptions.converters.GetForType<Relationship>();
                    relationshipConverter.Write(writer, relationshipValue, options);
                    break;
                case RemoteExecutionContext remoteExecutionContextValue:
                    JsonConverter<RemoteExecutionContext> remoteExecutionContextConverter = entitySerializerOptions.converters.GetForType<RemoteExecutionContext>();
                    remoteExecutionContextConverter.Write(writer, remoteExecutionContextValue, options);
                    break;
                case null:
                    writer.WriteNullValue();
                    break;
                case Enum enumValue:
                    writer.WriteStringValue(enumValue.ToString());
                    break;
                default:
                    if (entitySerializerOptions.Strictness == Strictness.Strict)
                    {
                        throw new JsonException($"We don't know how to handle value of type {value.GetType().Name}");
                    }
                    else
                    {
                        writer.WriteNullValue();
                        break;
                    }
            }
        }
    }
}
