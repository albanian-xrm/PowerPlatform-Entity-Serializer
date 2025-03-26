using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace JsonConvertersTests
{
    public class ParameterCollectionConverterTests
    {
        ITestOutputHelper output { get; }

        public ParameterCollectionConverterTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SerializeParameterCollectionWithDictionaryStringString()
        {
            var parameterCollection = new ParameterCollection()
            {
                { "ChangedEntityTypes", new Dictionary<string, string>() {
                    { "activityparty", "Create" },
                    { "actioncard", "Update" },
                    { "principalobjectaccess", "Update" }
                } }
            };
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded,
                Strictness = Strictness.Strict,
            };
            var serialized = EntitySerializer.Serialize(parameterCollection, typeof(ParameterCollection), entitySerializerOptions);
            output.WriteLine(serialized);
            var deserialized = EntitySerializer.Deserialize<ParameterCollection>(serialized, entitySerializerOptions);
            Assert.Equivalent(parameterCollection, deserialized, true);
        }

        [Fact]
        public void SerializeParameterCollectionWithUnknownType_Strict_Throw()
        {
            var parameterCollection = new ParameterCollection()
            {
                { "Unsupported", new TimeSpan() }
            };
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                Strictness = Strictness.Strict,
            };
            Assert.Throws<JsonException>(() => EntitySerializer.Serialize(parameterCollection, typeof(ParameterCollection), entitySerializerOptions));
        }

        [Fact]
        public void SerializeParameterCollectionWithUnknownType_Loose_Null()
        {
            var parameterCollection = new ParameterCollection()
            {
                { "Unsupported", new TimeSpan() }
            };
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Never,
                Strictness = Strictness.Loose,
            };
            var serialized = EntitySerializer.Serialize(parameterCollection, typeof(ParameterCollection), entitySerializerOptions);
            Assert.Equal("[{\"key\":\"Unsupported\",\"value\":null}]", serialized);
            output.WriteLine(serialized);
        }
    }
}
