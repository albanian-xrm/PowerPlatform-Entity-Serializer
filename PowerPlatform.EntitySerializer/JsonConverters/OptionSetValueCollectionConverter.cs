using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class OptionSetValueCollectionConverter : JsonConverter<OptionSetValueCollection>
    {

        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<OptionSetValue> optionSetValueConverter;

        public OptionSetValueCollectionConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }



        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }
            string propertyName = reader.GetString();
            OptionSetValue money = new OptionSetValue();
            if (propertyName != nameof(money.Value))
            {
                throw new JsonException();
            }
            reader.Read();
            money.Value = reader.GetInt32();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return money;
        }

        public override OptionSetValueCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            var result = new OptionSetValueCollection();
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray) return result;
            if (optionSetValueConverter == null) optionSetValueConverter = entitySerializerOptions.converters.GetForType<OptionSetValue>();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                result.Add(optionSetValueConverter.Read(ref reader, typeof(OptionSetValue), options));
                if (reader.TokenType != JsonTokenType.EndObject)
                {
                    throw new JsonException();
                }
                reader.Read();
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, OptionSetValueCollection value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            if (optionSetValueConverter == null) optionSetValueConverter = entitySerializerOptions.converters.GetForType<OptionSetValue>();
            foreach (var optionSetValue in value)
            {
                optionSetValueConverter.Write(writer, optionSetValue, options);
            }
            writer.WriteEndArray();
        }
    }
}
