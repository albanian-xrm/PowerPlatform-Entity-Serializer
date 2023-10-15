using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using Xunit;

namespace JsonConvertersTests
{
    public class EntityConverterTests
    {
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
        }
    }
}
