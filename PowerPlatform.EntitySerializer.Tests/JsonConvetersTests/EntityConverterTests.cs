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
    }
}
