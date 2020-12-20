using AlbanianXrm.PowerPlatform;
using System;
using System.Diagnostics;
using System.Text.Json;
using Xunit;

namespace JsonConvertersTests
{
    public class GuidConverterTests
    {
        [Fact]
        public void GuidCanBeSerializedAndDeserialized_WithoutSchema()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Never
            };
            var guid = Guid.NewGuid();

            string serializedGuid = EntitySerializer.Serialize(guid, typeof(Guid), entitySerializerOptions);
            Debug.WriteLine(serializedGuid);

            var deserializedGuid = EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions);

            Assert.Equal(guid, deserializedGuid);
        }

        [Fact]
        public void GuidCanBeSerializedAndDeserialized_WithSchema()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var guid = Guid.NewGuid();

            string serializedGuid = EntitySerializer.Serialize(guid, typeof(Guid), entitySerializerOptions);
            Debug.WriteLine(serializedGuid);

            var deserializedGuid = EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions);

            Assert.Equal(guid, deserializedGuid);
        }

        [Fact]
        public void GuidCannotBeDeserializedFromMalformedInput_SchemaTypeIsNotFirstProperty()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var guid = Guid.NewGuid();

            string serializedGuid = "{\"__value\":\"4daeb0c8-3b82-409c-99e5-0b3ad238379d\"}";

            var exception = Record.Exception(() => EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions));

            Assert.NotNull(exception);
            Assert.Equal(typeof(JsonException), exception.GetType());
        }

        [Fact]
        public void GuidCannotBeDeserializedFromMalformedInput_WrongSchemaType()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var guid = Guid.NewGuid();

            string serializedGuid = "{\"__type\":\"DateTime:#System\",\"__value\":\"4daeb0c8-3b82-409c-99e5-0b3ad238379d\"}";

            var exception = Record.Exception(() => EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions));

            Assert.NotNull(exception);
            Assert.Equal(typeof(JsonException), exception.GetType());
        }

        [Fact]
        public void GuidCannotBeDeserializedFromMalformedInput_InputIsArray()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var guid = Guid.NewGuid();

            string serializedGuid = "[\"__type\",\"Guid:#System\",\"__value\",\"4daeb0c8-3b82-409c-99e5-0b3ad238379d\"]";

            var exception = Record.Exception(() => EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions));

            Assert.NotNull(exception);
            Assert.Equal(typeof(JsonException), exception.GetType());
        }

        [Fact]
        public void GuidCannotBeDeserializedFromMalformedInput_SecondPropertyIsNotCalledValue()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var guid = Guid.NewGuid();

            string serializedGuid = "{\"__type\":\"Guid:#System\",\"__values\":\"4daeb0c8-3b82-409c-99e5-0b3ad238379d\"}";

            var exception = Record.Exception(() => EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions));

            Assert.NotNull(exception);
            Assert.Equal(typeof(JsonException), exception.GetType());
        }

        [Fact]
        public void GuidCannotBeDeserializedFromMalformedInput_ContainsMoreProperties()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var guid = Guid.NewGuid();

            string serializedGuid = "{\"__type\":\"Guid:#System\",\"__value\":\"4daeb0c8-3b82-409c-99e5-0b3ad238379d\",\"extra\":0]";

            var exception = Record.Exception(() => EntitySerializer.Deserialize<Guid>(serializedGuid, entitySerializerOptions));

            Assert.NotNull(exception);
            Assert.Equal(typeof(JsonException), exception.GetType());
        }
    }
}
