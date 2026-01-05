using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace JsonConvertersTests
{
    public class EntityConverterTests
    {
        private readonly ITestOutputHelper output;

        public EntityConverterTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void EntityCanBeSerializedAndDeserialized_WithSchema()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always
            };
            var entity = new Entity("contact");
            entity.KeyAttributes.Add("key", 2);
            entity.FormattedValues.Add("fullname", "Betim Beja");
            entity.Attributes.Add("fullname", "Betim Beja");
            entity.Attributes.Add("primarycustomerid", new EntityReference("account", "albx_id", "122333"));
            entity.Attributes.Add("albx_iscompanyowner", true);

            string serializedEntity = EntitySerializer.Serialize(entity, typeof(Entity), entitySerializerOptions);
            Debug.WriteLine(serializedEntity);

            var deserializedEntity = EntitySerializer.Deserialize<Entity>(serializedEntity, entitySerializerOptions);

            Assert.Equal(entity.LogicalName, deserializedEntity.LogicalName);

            Assert.NotEmpty(deserializedEntity.KeyAttributes);
            Assert.Equal(2, deserializedEntity.KeyAttributes["key"]);
            
            var primarycustomerid = deserializedEntity.GetAttributeValue<EntityReference>("primarycustomerid");
            Assert.Equal("Betim Beja", deserializedEntity.GetAttributeValue<string>("fullname"));
            Assert.True(deserializedEntity.GetAttributeValue<bool>("albx_iscompanyowner"));

            Assert.NotNull(primarycustomerid);
            Assert.Equal("account", primarycustomerid.LogicalName);
            Assert.Equal(Guid.Empty, primarycustomerid.Id);
            Assert.NotEmpty(primarycustomerid.KeyAttributes);
            Assert.Equal("122333", primarycustomerid.KeyAttributes["albx_id"]);
            output.WriteLine(serializedEntity);
        }

        [Fact]
        public void EntityCanBeSerializedWithUnknownProperty_LooseStrictness()
        {
            var input = @"{""__type"":""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"", ""NewProperty"":[],""Attributes"":[{""key"":""fullname"",""value"":""Betim Beja""},{""key"":""primarycustomerid"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""00000000-0000-0000-0000-000000000000"",""KeyAttributes"":[{""key"":""albx_id"",""value"":""122333""}],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{""key"":""albx_iscompanyowner"",""value"":true}],""EntityState"":null,""FormattedValues"":[{""key"":""fullname"",""value"":""Betim Beja""}],""Id"":""00000000-0000-0000-0000-000000000000"",""KeyAttributes"":[{""key"":""key"",""value"":{""__type"":""Int32:#System"",""__value"":2}}],""LogicalName"":""contact"",""RelatedEntities"":[],""RowVersion"":null}";
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always,
                Strictness = Strictness.Loose
            };
            var entity = EntitySerializer.Deserialize<Entity>(input, entitySerializerOptions);
            Assert.NotNull(entity);
            Assert.IsType<Entity>(entity);
            Assert.Equal(entity.LogicalName, entity.LogicalName);

            Assert.NotEmpty(entity.KeyAttributes);
            Assert.Equal(2, entity.KeyAttributes["key"]);

            var primarycustomerid = entity.GetAttributeValue<EntityReference>("primarycustomerid");
            Assert.Equal("Betim Beja", entity.GetAttributeValue<string>("fullname"));
            Assert.True(entity.GetAttributeValue<bool>("albx_iscompanyowner"));

            Assert.NotNull(primarycustomerid);
            Assert.Equal("account", primarycustomerid.LogicalName);
            Assert.Equal(Guid.Empty, primarycustomerid.Id);
            Assert.NotEmpty(primarycustomerid.KeyAttributes);
            Assert.Equal("122333", primarycustomerid.KeyAttributes["albx_id"]);
        }

        [Fact]
        public void EntityCanBeSerializedWithUnknownProperty_Strict_Throw()
        {
            var input = @"{""__type"":""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"", ""NewProperty"":[],""Attributes"":[{""key"":""fullname"",""value"":""Betim Beja""},{""key"":""primarycustomerid"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""00000000-0000-0000-0000-000000000000"",""KeyAttributes"":[{""key"":""albx_id"",""value"":""122333""}],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{""key"":""albx_iscompanyowner"",""value"":true}],""EntityState"":null,""FormattedValues"":[{""key"":""fullname"",""value"":""Betim Beja""}],""Id"":""00000000-0000-0000-0000-000000000000"",""KeyAttributes"":[{""key"":""key"",""value"":{""__type"":""Int32:#System"",""__value"":2}}],""LogicalName"":""contact"",""RelatedEntities"":[],""RowVersion"":null}";
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Always,
                Strictness = Strictness.Strict
            };
            Assert.Throws<JsonException>(() => EntitySerializer.Deserialize<Entity>(input, entitySerializerOptions));
        }

        [Fact]
        public void EntityCanBeSerializedWithDouble()
        {
            var entity = new Entity()
            {
                Attributes = new AttributeCollection()
                {
                    { "double", 123.345d },
                    { "decimal", 345.567m },
                    { "double_maxvalue", Double.MaxValue },
                    { "double_minvalue", Double.MinValue },
                    { "decimal_maxvalue", Decimal.MaxValue },
                    { "decimal_minvalue", Decimal.MinValue }
                }
            };
            var entitySerializerOptions = new EntitySerializerOptions();
            var serializedEntity = EntitySerializer.Serialize(entity, typeof(Entity), entitySerializerOptions);
            output.WriteLine(serializedEntity);
            Assert.Equal("{\"__type\":\"Entity:http://schemas.microsoft.com/xrm/2011/Contracts\",\"Attributes\":[{\"key\":\"double\",\"value\":{\"__type\":\"Double:#System\",\"__value\":123.345}},{\"key\":\"decimal\",\"value\":345.567},{\"key\":\"double_maxvalue\",\"value\":{\"__type\":\"Double:#System\",\"__value\":1.7976931348623157E+308}},{\"key\":\"double_minvalue\",\"value\":{\"__type\":\"Double:#System\",\"__value\":-1.7976931348623157E+308}},{\"key\":\"decimal_maxvalue\",\"value\":79228162514264337593543950335},{\"key\":\"decimal_minvalue\",\"value\":-79228162514264337593543950335}],\"EntityState\":null,\"FormattedValues\":[],\"Id\":\"00000000-0000-0000-0000-000000000000\",\"KeyAttributes\":[],\"LogicalName\":null,\"RelatedEntities\":[],\"RowVersion\":null}", serializedEntity);

            var deserializedEntity = EntitySerializer.Deserialize<Entity>(serializedEntity, entitySerializerOptions);
            Assert.Equal(123.345d, deserializedEntity.GetAttributeValue<double>("double"));
            Assert.Equal(345.567m, deserializedEntity.GetAttributeValue<decimal>("decimal")); 
            Assert.Equal(Double.MaxValue, deserializedEntity.GetAttributeValue<double>("double_maxvalue"));
            Assert.Equal(Double.MinValue, deserializedEntity.GetAttributeValue<double>("double_minvalue"));
            Assert.Equal(Decimal.MaxValue, deserializedEntity.GetAttributeValue<decimal>("decimal_maxvalue"));
            Assert.Equal(Decimal.MinValue, deserializedEntity.GetAttributeValue<decimal>("decimal_minvalue"));
        }

        [Fact]
        public void EntityCanBeSerializedWithDouble_NoSchema_DecimalDefault()
        {
            var entity = new Entity()
            {
                Attributes = new AttributeCollection()
                {
                    { "double", 123.345d },
                    { "decimal", 345.567m },
                    { "double_maxvalue", Double.MaxValue },
                    { "double_minvalue", Double.MinValue },
                    { "decimal_maxvalue", Decimal.MaxValue },
                    { "decimal_minvalue", Decimal.MinValue }
                }
            };
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Never
            };
            var serializedEntity = EntitySerializer.Serialize(entity, typeof(Entity), entitySerializerOptions);
            output.WriteLine(serializedEntity);
            Assert.Equal("{\"Attributes\":[{\"key\":\"double\",\"value\":123.345},{\"key\":\"decimal\",\"value\":345.567},{\"key\":\"double_maxvalue\",\"value\":1.7976931348623157E+308},{\"key\":\"double_minvalue\",\"value\":-1.7976931348623157E+308},{\"key\":\"decimal_maxvalue\",\"value\":79228162514264337593543950335},{\"key\":\"decimal_minvalue\",\"value\":-79228162514264337593543950335}],\"EntityState\":null,\"FormattedValues\":[],\"Id\":\"00000000-0000-0000-0000-000000000000\",\"KeyAttributes\":[],\"LogicalName\":null,\"RelatedEntities\":[],\"RowVersion\":null}", serializedEntity);

            var deserializedEntity = EntitySerializer.Deserialize<Entity>(serializedEntity, entitySerializerOptions);
            //No type information was preserved and defaults to decimal
            Assert.Equal(123.345m, deserializedEntity.GetAttributeValue<decimal>("double"));
            Assert.Equal(345.567m, deserializedEntity.GetAttributeValue<decimal>("decimal"));
            Assert.Equal(Double.MaxValue, deserializedEntity.GetAttributeValue<double>("double_maxvalue"));
            Assert.Equal(Double.MinValue, deserializedEntity.GetAttributeValue<double>("double_minvalue"));
            Assert.Equal(Decimal.MaxValue, deserializedEntity.GetAttributeValue<decimal>("decimal_maxvalue"));
            Assert.Equal(Decimal.MinValue, deserializedEntity.GetAttributeValue<decimal>("decimal_minvalue"));
        }
    }
}
