using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class KeyValuePairStringStringConverter : JsonConverter<KeyValuePair<string, string>>, IObjectContractConverter
    {
        public const string TypeSchema = "KeyValuePairOfstringstring:#System.Collections.Generic";
        private readonly EntitySerializerOptions entitySerializerOptions;

        public KeyValuePairStringStringConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }

        public string GetTypeSchema()
        {
            return TypeSchema;
        }

        public override KeyValuePair<string, string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            return (KeyValuePair<string, string>)ReadInternal(ref reader, typeToConvert, options);
        }

        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string itemKey = null;
            string itemValue = null;

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
                        itemValue = reader.GetString();
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
            return new KeyValuePair<string, string>(itemKey, itemValue);
        }

        public override void Write(Utf8JsonWriter writer, KeyValuePair<string, string> value, JsonSerializerOptions options)
        {
            var writingSchema = entitySerializerOptions.writingSchema;
            if (entitySerializerOptions.WriteSchema == WriteSchemaOptions.IfNeeded)
            {
                writingSchema = true;
            }
            writer.WriteStartObject();
            if (writingSchema)
            {
                writer.WriteString(EntitySerializer.TypePropertyName, TypeSchema);
            }

            writer.WriteString(EntitySerializer.CollectionKeyPropertyName, value.Key);
            writer.WritePropertyName(EntitySerializer.CollectionValuePropertyName);
            if (value.Value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value);
            }
            writer.WriteEndObject();
            entitySerializerOptions.writingSchema = writingSchema;
        }
    }
}
