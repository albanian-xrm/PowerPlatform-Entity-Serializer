using AlbanianXrm.PowerPlatform.JsonConverters;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace AlbanianXrm.PowerPlatform
{
    public class EntitySerializer
    {
        public const string TypePropertyName = "__type";
        public const string ValuePropertyName = "__value";

        public static T Deserialize<T>(string json, EntitySerializerOptions options = default)
        {
            var jsonSerializerOptions = InitializeOptions(options);
            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
        }

        public static T Deserialize<T>(ref Utf8JsonReader reader, EntitySerializerOptions options = default)
        {
            var jsonSerializerOptions = InitializeOptions(options);
            return JsonSerializer.Deserialize<T>(ref reader, jsonSerializerOptions);
        }

        public static T Deserialize<T>(ReadOnlySpan<byte> utf8Json, EntitySerializerOptions options = default)
        {
            var jsonSerializerOptions = InitializeOptions(options);
            return JsonSerializer.Deserialize<T>(utf8Json, jsonSerializerOptions);
        }

        public static ValueTask<T> DeserializeAsync<T>(Stream utf8Json, EntitySerializerOptions options = default, CancellationToken cancellationToken = default)
        {
            var jsonSerializerOptions = InitializeOptions(options);
            return JsonSerializer.DeserializeAsync<T>(utf8Json, jsonSerializerOptions, cancellationToken);
        }

        internal static JsonSerializerOptions InitializeOptions(EntitySerializerOptions entitySerializerOptions = default)
        {
            if (entitySerializerOptions == null)
            {
                entitySerializerOptions = new EntitySerializerOptions();
            }
            var jsonSerializerOptions = entitySerializerOptions.JsonSerializerOptions;

            foreach (var item in jsonSerializerOptions.Converters)
            {
                if (CanConvert(typeof(AttributeCollection), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(DateTime), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(Entity), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(EntityImageCollection), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(EntityReference), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(FormattedValueCollection), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(Guid), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(KeyAttributeCollection), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(Money), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(object), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(OptionSetValue), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(ParameterCollection), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(RelatedEntityCollection), item, entitySerializerOptions.converters) ||
                    CanConvert(typeof(RemoteExecutionContext), item, entitySerializerOptions.converters))
                {
                    continue;
                }
            }
            EnsureHasConverters(entitySerializerOptions);
            return jsonSerializerOptions;
        }

        internal static bool CanConvert(Type type, JsonConverter item, Dictionary<Type, JsonConverter> converters)
        {
            var canConvert = item.CanConvert(type);
            if (canConvert && !converters.ContainsKey(type))
            {
                converters.Add(type, item);
            }
            return canConvert;
        }

        internal static void EnsureHasConverters(EntitySerializerOptions entitySerializerOptions)
        {
            JsonConverter converter;
            Type type = typeof(AttributeCollection);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new AttributeCollectionConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(DateTime);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new DateTimeConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(Entity);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new EntityConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(EntityImageCollection);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new EntityImageCollectionConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(EntityReference);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new EntityReferenceConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(FormattedValueCollection);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new FormattedValueCollectionConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(Guid);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new GuidConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(KeyAttributeCollection);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new KeyAttributeCollectionConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(Money);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new MoneyConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(OptionSetValue);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new OptionSetValueConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            } 
            type = typeof(ParameterCollection);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new ParameterCollectionConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(RelatedEntityCollection);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new RelatedEntityCollectionConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(RemoteExecutionContext);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new RemoteExecutionContextConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
            type = typeof(object);
            if (!entitySerializerOptions.converters.ContainsKey(type))
            {
                converter = new ObjectContractConverter(entitySerializerOptions);
                entitySerializerOptions.converters.Add(type, converter);
                entitySerializerOptions.JsonSerializerOptions.Converters.Add(converter);
            }
        }
    }
}
