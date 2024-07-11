using AlbanianXrm.PowerPlatform.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform
{
    public class EntitySerializerConverters
    {
        internal readonly Dictionary<Type, JsonConverter> converters = new Dictionary<Type, JsonConverter>();

        public bool CanConvertType<T>()
        {
            return converters.ContainsKey(typeof(T));
        }

        public bool CanConvertType(Type type)
        {
            return converters.ContainsKey(type);
        }

        public JsonConverter<T> GetForType<T>()
        {
            JsonConverter result;
            if (!converters.TryGetValue(typeof(T), out result))
            {
                throw new Exception($"No converter registered for type {typeof(T)}");
            }
            return (JsonConverter<T>)result;
        }

        public JsonConverter GetForType(Type type)
        {
            JsonConverter result;

            if (!converters.TryGetValue(type, out result))
            {
                var baseType = type.BaseType;
                while (baseType != null && result == null)
                {
                    converters.TryGetValue(type, out result);
                    baseType = baseType.BaseType;
                }
            }
            if (result == null)
            {
                throw new Exception($"No converter registered for type {type}");
            }
            return result;
        }

        public JsonConverter<T> Set<T>(JsonConverter<T> converter)
        {
            if (CanConvertType<T>())
            {
                throw new Exception($"Converter for type {typeof(T)} is already registered");
            }
            converters.Add(typeof(T), converter);
            return converter;
        }

        public IEnumerable<IObjectContractConverter> ObjectContractConverters()
        {
            return converters.Values.Where(x => typeof(IObjectContractConverter).IsAssignableFrom(x.GetType())).Cast<IObjectContractConverter>();
        }
    }
}
