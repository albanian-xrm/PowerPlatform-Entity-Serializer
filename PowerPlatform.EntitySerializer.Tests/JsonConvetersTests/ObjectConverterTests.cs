using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Diagnostics;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace JsonConvertersTests
{
    public class ObjectConverterTests
    {
        private readonly ITestOutputHelper _output;
        public ObjectConverterTests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void DateDeserialize()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };

            string serializedDate = "{\"__type\":\"DateTime:#System\",\"__value\":\"\\/Date(1527757524000)\\/\"          }";

            var date = EntitySerializer.Deserialize<DateTime>(serializedDate, entitySerializerOptions);

            Assert.Equal(new DateTime(2018, 5, 31, 9, 5, 24, DateTimeKind.Utc), date);
        }

        [Fact]
        public void DateDeserialize_IsoFormat()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };

            string serializedDate = "{\"__type\":\"DateTime:#System\",\"__value\":\"2018-05-31T09:05:24.0\"          }";

            var date = EntitySerializer.Deserialize<DateTime>(serializedDate, entitySerializerOptions);

            Assert.Equal(new DateTime(2018, 5, 31, 9, 5, 24, DateTimeKind.Utc), date);
        }


        [Fact]
        public void DateSerialize()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always,
                DateOptions = DateOptions.SerializeXrmDate
            };
            var date = new DateTime(2018, 5, 31, 9, 5, 24, DateTimeKind.Utc);
            string serializedDate = EntitySerializer.Serialize(date, typeof(DateTime), entitySerializerOptions);
            Debug.WriteLine(serializedDate);
            Assert.Equal("{\"__type\":\"DateTime:#System\",\"__value\":\"/Date(1527757524000)/\"}", serializedDate);
        }

        [Fact]
        public void DateSerialize_NoSchema()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded,
                DateOptions = DateOptions.SerializeXrmDate
            };
            var date = new DateTime(2018, 5, 31, 9, 5, 24, DateTimeKind.Utc);
            string serializedDate = EntitySerializer.Serialize(date, typeof(DateTime), entitySerializerOptions);
            Debug.WriteLine(serializedDate);
            Assert.Equal("\"/Date(1527757524000)/\"", serializedDate);
        }

        [Fact]
        public void DateSerialize_LocalDate()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded,
                DateOptions = DateOptions.SerializeXrmDate
            };
            var date = new DateTimeOffset(2018, 5, 31, 12, 5, 24, TimeSpan.FromHours(3)).LocalDateTime;
            string serializedDate = EntitySerializer.Serialize(date, typeof(DateTime), entitySerializerOptions);
            Debug.WriteLine(serializedDate);
            Assert.Equal("\"/Date(1527757524000)/\"", serializedDate);
        }


        [Fact]
        public void DateSerialize_IsoFormat()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var date = new DateTime(2018, 5, 31, 9, 5, 24, DateTimeKind.Utc);
            string serializedDate = EntitySerializer.Serialize(date, typeof(DateTime), entitySerializerOptions);
            Debug.WriteLine(serializedDate);
            Assert.Equal("{\"__type\":\"DateTime:#System\",\"__value\":\"2018-05-31T09:05:24.000Z\"}", serializedDate);
        }


        [Fact]
        public void SerializeEnum()
        {
            var entitySerializerOptions = new EntitySerializerOptions();
            var request = new UpdateRequest()
            {
                ConcurrencyBehavior = ConcurrencyBehavior.IfRowVersionMatches
            };
            string serializedValue = EntitySerializer.Serialize(request.Parameters, typeof(ParameterCollection), entitySerializerOptions);
            _output.WriteLine(serializedValue);
            Assert.Equal("[{\"key\":\"Target\",\"value\":null},{\"key\":\"ConcurrencyBehavior\",\"value\":\"IfRowVersionMatches\"}]", serializedValue);
        }
    }
}
