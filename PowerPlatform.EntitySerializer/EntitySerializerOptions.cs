using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AlbanianXrm.PowerPlatform
{
    public class EntitySerializerOptions
    {
        private WriteSchemaOptions _WriteSchema = WriteSchemaOptions.IfNeeded;
        private HashSet<string> _KnownGuidAttributes = new HashSet<string>() { "activityid", "activitypartyid" };

        internal bool writingSchema = false;
        internal readonly EntitySerializerConverters converters = new EntitySerializerConverters();

        public WriteSchemaOptions WriteSchema { get { return _WriteSchema; } set { writingSchema = value == WriteSchemaOptions.Always; _WriteSchema = value; } }

        public JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions();

        public Encoding EncodingToCorrect { get; set; } = default;

        public HashSet<string> KnowGuidAttributes { get { return _KnownGuidAttributes; } }

        public Dictionary<string, Type> KnownAttributeTypes { get; set; } = new Dictionary<string, Type>();

        public Dictionary<string, object> UnknownPropertiesLastSerialization { get; set; } = new Dictionary<string, object>();

        public DateOptions DateOptions { get; set; } = DateOptions.SerializeIsoDate;

        public Strictness Strictness { get; set; } = Strictness.Strict;
    }
}
