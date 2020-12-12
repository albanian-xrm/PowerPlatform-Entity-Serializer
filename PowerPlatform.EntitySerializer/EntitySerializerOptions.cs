using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform
{
    public class EntitySerializerOptions
    {
        private WriteSchemaOptions _WriteSchema = WriteSchemaOptions.IfNeeded;
        
        internal bool writingSchema = false;
        internal readonly Dictionary<Type, JsonConverter> converters = new Dictionary<Type, JsonConverter>();
        
        public WriteSchemaOptions WriteSchema { get { return _WriteSchema; } set { writingSchema = value == WriteSchemaOptions.Always; _WriteSchema = value; } }

        public JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions();
    }
}
