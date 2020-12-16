using AlbanianXrm.PowerPlatform.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform
{
    internal class EntitySerializerConverters
    {
        internal readonly Dictionary<Type, JsonConverter> converters = new Dictionary<Type, JsonConverter>();

        public bool CanConvertType<T>()
        {
            return converters.ContainsKey(typeof(T));
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

        public JsonConverter<T> Set<T>(JsonConverter<T> converter)
        {
            if(CanConvertType<T>())
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
