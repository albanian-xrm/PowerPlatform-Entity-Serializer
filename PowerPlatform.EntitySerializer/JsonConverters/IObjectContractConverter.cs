using System;
using System.Text.Json;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public interface IObjectContractConverter
    {
        object ReadInternal(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
        string GetTypeSchema();
    }
}
