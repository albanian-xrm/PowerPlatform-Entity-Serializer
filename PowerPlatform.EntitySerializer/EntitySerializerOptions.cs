using System.Text.Json;

namespace AlbanianXrm.PowerPlatform
{
    public class EntitySerializerOptions
    {
        private WriteSchemaOptions _WriteSchema = WriteSchemaOptions.IfNeeded;
        
        internal bool writingSchema = false;
        internal readonly EntitySerializerConverters converters = new EntitySerializerConverters();
        
        public WriteSchemaOptions WriteSchema { get { return _WriteSchema; } set { writingSchema = value == WriteSchemaOptions.Always; _WriteSchema = value; } }

        public JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions();
    }
}
