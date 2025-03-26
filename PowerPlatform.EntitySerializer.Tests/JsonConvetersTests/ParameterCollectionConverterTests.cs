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
        public void SerializeParameterCollectionWithUnknownType_Strict_Throw()
        {
            var dict = new ConcurrentDictionary<string, string>();
            dict.TryAdd("activityparty", "Create");
            dict.TryAdd("actioncard", "Update");
            dict.TryAdd("principalobjectaccess", "Update");

            var parameterCollection = new ParameterCollection()
            {
                { "Unsupported", dict }
            };
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded,
                Strictness = Strictness.Strict,
            };
            Assert.Throws<JsonException>(() => EntitySerializer.Serialize(parameterCollection, typeof(ParameterCollection), entitySerializerOptions));
        }

        [Fact]
        public void SerializeParameterCollectionWithUnknownType_Loose_Null()
        {
            var dict = new ConcurrentDictionary<string, string>();
            dict.TryAdd("activityparty", "Create");
            dict.TryAdd("actioncard", "Update");
            dict.TryAdd("principalobjectaccess", "Update");

            var parameterCollection = new ParameterCollection()
            {
                { "Unsupported", dict }
            };
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded,
                Strictness = Strictness.Loose,
            };
            var serialized = EntitySerializer.Serialize(parameterCollection, typeof(ParameterCollection), entitySerializerOptions);
            Assert.Equal("[{\"key\":\"Unsupported\",\"value\":null}]", serialized);
            output.WriteLine(serialized);
        }
    }
}
