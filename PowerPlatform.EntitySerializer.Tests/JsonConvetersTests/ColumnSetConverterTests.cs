using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk.Query;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace JsonConvertersTests
{
    public class ColumnSetConverterTests
    {
        public ColumnSetConverterTests(ITestOutputHelper output)
        {
            Output = output;
        }

        public ITestOutputHelper Output { get; }

        [Fact]
        public void ColumnSetConverter_Read()
        {
            // Arrange
            var columnSet = new ColumnSet(true);
            columnSet.AddColumn("column1");
            columnSet.AddColumn("column2");
            columnSet.AddColumn("column3");
            var json = "{\"AllColumns\":true,\"Columns\":[\"column1\",\"column2\",\"column3\"]}";
            // Act
            var result = EntitySerializer.Deserialize<ColumnSet>(json);
            // Assert
            Assert.Equal(columnSet.AllColumns, result.AllColumns);
            Assert.Collection(result.Columns,
                item => Assert.Equal("column1", item),
                item => Assert.Equal("column2", item),
                item => Assert.Equal("column3", item));
        }

        [Fact]
        public void ColumnSetConverter_AddColumn_Write()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded
            };
            // Arrange
            var columnSet = new ColumnSet(true);
            columnSet.AddColumn("column1");
            columnSet.AddColumn("column2");
            columnSet.AddColumn("column3");
            var json = "{\"AllColumns\":true,\"AttributeExpressions\":[],\"Columns\":[\"column1\",\"column2\",\"column3\"]}";
            // Act
            var entitySerializer = EntitySerializer.Serialize(columnSet, typeof(ColumnSet), entitySerializerOptions);
            // Assert
            Assert.Equal(json, entitySerializer);
        }

        [Fact]
        public void ColumnSetConverter_AttributeExpressions_Read()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Never
            };
            // Arrange
            var columnSet = new ColumnSet(true);
            columnSet.AddColumn("column1");
            columnSet.AddColumn("column2");
            columnSet.AddColumn("column3");
            columnSet.AttributeExpressions.Add(new XrmAttributeExpression("attribute1"));
            columnSet.AttributeExpressions.Add(new XrmAttributeExpression("attribute2", XrmAggregateType.Sum, "alias2"));
            columnSet.AttributeExpressions.Add(new XrmAttributeExpression("attribute3", XrmAggregateType.Avg, "alias3") { HasGroupBy = true });
            columnSet.AttributeExpressions.Add(new XrmAttributeExpression("attribute4", XrmAggregateType.Max, "alias4", XrmDateTimeGrouping.Month));
            var json = "{\"AllColumns\":true,\"AttributeExpressions\":[{\"AttributeName\":\"attribute1\",\"AggregateType\":0,\"Alias\":null,\"HasGroupBy\":false,\"DateTimeGrouping\":0,\"ExtensionData\":null},{\"AttributeName\":\"attribute2\",\"AggregateType\":3,\"Alias\":\"alias2\",\"HasGroupBy\":false,\"DateTimeGrouping\":0,\"ExtensionData\":null},{\"AttributeName\":\"attribute3\",\"AggregateType\":4,\"Alias\":\"alias3\",\"HasGroupBy\":true,\"DateTimeGrouping\":0,\"ExtensionData\":null},{\"AttributeName\":\"attribute4\",\"AggregateType\":6,\"Alias\":\"alias4\",\"HasGroupBy\":false,\"DateTimeGrouping\":3,\"ExtensionData\":null}],\"Columns\":[\"column1\",\"column2\",\"column3\"]}";
            // Act
            var entitySerializer = EntitySerializer.Serialize(columnSet, typeof(ColumnSet), entitySerializerOptions);
            var jsonSerializer = JsonSerializer.Serialize(columnSet);
            // Assert
            Assert.Equal(json, entitySerializer);
        }

        [Fact]
        public void ColumnSetConverter_AttributeExpressions_Write()
        {
            var entitySerializerOptions = new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.Never
            };
            // Arrange
            var json = "{\"AllColumns\":true,\"Columns\":[\"column1\",\"column2\",\"column3\"],\"AttributeExpressions\":[{\"AttributeName\":\"attribute1\",\"AggregateType\":0,\"Alias\":null,\"HasGroupBy\":false,\"DateTimeGrouping\":0,\"ExtensionData\":null},{\"AttributeName\":\"attribute2\",\"AggregateType\":3,\"Alias\":\"alias2\",\"HasGroupBy\":true,\"DateTimeGrouping\":0,\"ExtensionData\":null},{\"AttributeName\":\"attribute3\",\"AggregateType\":4,\"Alias\":\"alias3\",\"HasGroupBy\":false,\"DateTimeGrouping\":0,\"ExtensionData\":null},{\"AttributeName\":\"attribute4\",\"AggregateType\":6,\"Alias\":\"alias4\",\"HasGroupBy\":false,\"DateTimeGrouping\":3,\"ExtensionData\":null}]}";
            // Act
            var result = EntitySerializer.Deserialize<ColumnSet>(json);
            // Assert
            Assert.True(result.AllColumns);
            Assert.Collection(result.Columns,
                item => Assert.Equal("column1", item),
                item => Assert.Equal("column2", item),
                item => Assert.Equal("column3", item));
            Assert.Collection(result.AttributeExpressions,
                item =>
                {
                    Assert.Equal("attribute1", item.AttributeName);
                    Assert.Equal(XrmAggregateType.None, item.AggregateType);
                    Assert.Null(item.Alias);
                    Assert.False(item.HasGroupBy);
                    Assert.Equal(XrmDateTimeGrouping.None, item.DateTimeGrouping);
                },
                item =>
                {
                    Assert.Equal("attribute2", item.AttributeName);
                    Assert.Equal(XrmAggregateType.Sum, item.AggregateType);
                    Assert.Equal("alias2", item.Alias);
                    Assert.True(item.HasGroupBy);
                    Assert.Equal(XrmDateTimeGrouping.None, item.DateTimeGrouping);
                },
                item =>
                {
                    Assert.Equal("attribute3", item.AttributeName);
                    Assert.Equal(XrmAggregateType.Avg, item.AggregateType);
                    Assert.Equal("alias3", item.Alias);
                    Assert.False(item.HasGroupBy);
                    Assert.Equal(XrmDateTimeGrouping.None, item.DateTimeGrouping);
                },
                item =>
                {
                    Assert.Equal("attribute4", item.AttributeName);
                    Assert.Equal(XrmAggregateType.Max, item.AggregateType);
                    Assert.Equal("alias4", item.Alias);
                    Assert.False(item.HasGroupBy);
                    Assert.Equal(XrmDateTimeGrouping.Month, item.DateTimeGrouping);
                });
        }
    }
}
