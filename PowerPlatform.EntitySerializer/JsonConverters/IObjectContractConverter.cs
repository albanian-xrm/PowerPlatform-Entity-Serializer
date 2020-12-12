using System;
using System.Text.Json;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public interface IObjectContractConverter
    {
        public object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
        public string GetTypeSchema();
    }
}
