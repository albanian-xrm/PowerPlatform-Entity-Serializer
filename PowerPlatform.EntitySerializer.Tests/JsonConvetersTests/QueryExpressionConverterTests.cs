using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk.Query;
using Xunit;
using Xunit.Abstractions;

namespace JsonConvertersTests
{
    public class QueryExpressionConverterTests
    {
        public QueryExpressionConverterTests(ITestOutputHelper output)
        {
            Output = output;
        }

        public ITestOutputHelper Output { get; }

        [Fact]
        public void QueryExpression_Read()
        {
            // Arrange
            var queryExpression = new QueryExpression("sharepointdocument")
            {
                ColumnSet = new ColumnSet(
                    "documentid",
                    "fullname",
                    "relativelocation",
                    "sharepointcreatedon",
                    "ischeckedout",
                    "filetype",
                    "modified",
                    "sharepointmodifiedby",
                    "servicetype",
                    "absoluteurl",
                    "title",
                    "author",
                    "sharepointdocumentid",
                    "readurl",
                    "editurl",
                    "locationid",
                    "iconclassname",
                    "locationname"),
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("isrecursivefetch", ConditionOperator.Equal, false),
                        new ConditionExpression("regardingobjecttypecode", ConditionOperator.Equal, 1),
                        new ConditionExpression("regardingobjectid", ConditionOperator.Equal, "0a3839b3-08d4-ef11-aeb0-00155d000101")
                    }
                },
                Distinct = false,
                Orders = { new OrderExpression("relativelocation", OrderType.Ascending) },
                PageInfo = new PagingInfo()
                {
                    Count = 10,
                    PageNumber = 1,
                    PagingCookie = null,
                    ReturnTotalRecordCount = true
                },
                NoLock = false,
                QueryHints = "",
            };

            var json = "{\"__type\":\"QueryExpression:http:\\/\\/schemas.microsoft.com\\/xrm\\/2011\\/Contracts\",\"ColumnSet\":{\"AllColumns\":false,\"AttributeExpressions\":[],\"Columns\":[\"documentid\",\"fullname\",\"relativelocation\",\"sharepointcreatedon\",\"ischeckedout\",\"filetype\",\"modified\",\"sharepointmodifiedby\",\"servicetype\",\"absoluteurl\",\"title\",\"author\",\"sharepointdocumentid\",\"readurl\",\"editurl\",\"locationid\",\"iconclassname\",\"locationname\"]},\"Criteria\":{\"Conditions\":[{\"AttributeName\":\"isrecursivefetch\",\"CompareColumns\":false,\"Operator\":0,\"Values\":[false],\"EntityName\":null},{\"AttributeName\":\"regardingobjecttypecode\",\"CompareColumns\":false,\"Operator\":0,\"Values\":[1],\"EntityName\":null},{\"AttributeName\":\"regardingobjectid\",\"CompareColumns\":false,\"Operator\":0,\"Values\":[\"0a3839b3-08d4-ef11-aeb0-00155d000101\"],\"EntityName\":null}],\"FilterOperator\":0,\"Filters\":[]},\"Distinct\":false,\"EntityName\":\"sharepointdocument\",\"LinkEntities\":[],\"Orders\":[{\"Alias\":null,\"AttributeName\":\"relativelocation\",\"OrderType\":0}],\"PageInfo\":{\"Count\":10,\"PageNumber\":1,\"PagingCookie\":null,\"ReturnTotalRecordCount\":true},\"NoLock\":false,\"QueryHints\":\"\"}";
            // Act
            var result = EntitySerializer.Deserialize<QueryExpression>(json);
            // Assert
            Assert.Equal(queryExpression.EntityName, result.EntityName);
            Assert.Equal(queryExpression.ColumnSet.AllColumns, result.ColumnSet.AllColumns);
            Assert.Collection(result.ColumnSet.Columns,
                item => Assert.Equal("documentid", item),
                item => Assert.Equal("fullname", item),
                item => Assert.Equal("relativelocation", item),
                item => Assert.Equal("sharepointcreatedon", item),
                item => Assert.Equal("ischeckedout", item),
                item => Assert.Equal("filetype", item),
                item => Assert.Equal("modified", item),
                item => Assert.Equal("sharepointmodifiedby", item),
                item => Assert.Equal("servicetype", item),
                item => Assert.Equal("absoluteurl", item),
                item => Assert.Equal("title", item),
                item => Assert.Equal("author", item),
                item => Assert.Equal("sharepointdocumentid", item),
                item => Assert.Equal("readurl", item),
                item => Assert.Equal("editurl", item),
                item => Assert.Equal("locationid", item),
                item => Assert.Equal("iconclassname", item),
                item => Assert.Equal("locationname", item));
            Assert.Equal(queryExpression.Criteria.Conditions.Count, result.Criteria.Conditions.Count);
            Assert.Collection(result.Criteria.Conditions,
                item =>
                {
                    Assert.Equal("isrecursivefetch", item.AttributeName);
                    Assert.Equal(ConditionOperator.Equal, item.Operator);
                    Assert.Collection(item.Values, value => Assert.Equal(false, value));
                },
                item =>
                {
                    Assert.Equal("regardingobjecttypecode", item.AttributeName);
                    Assert.Equal(ConditionOperator.Equal, item.Operator);
                    Assert.Collection(item.Values, value => Assert.Equal(1, value));
                },
                item =>
                {
                    Assert.Equal("regardingobjectid", item.AttributeName);
                    Assert.Equal(ConditionOperator.Equal, item.Operator);
                    Assert.Collection(item.Values, value => Assert.Equal("0a3839b3-08d4-ef11-aeb0-00155d000101", value));
                });
            Assert.Equal(queryExpression.Distinct, result.Distinct);
            Assert.Equal(queryExpression.Orders.Count, result.Orders.Count);
            Assert.Collection(result.Orders,
                item => Assert.Equal("relativelocation", item.AttributeName));
            Assert.Equal(queryExpression.PageInfo.Count, result.PageInfo.Count);
            Assert.Equal(queryExpression.PageInfo.PageNumber, result.PageInfo.PageNumber);
            Assert.Equal(queryExpression.PageInfo.PagingCookie, result.PageInfo.PagingCookie);
            Assert.Equal(queryExpression.PageInfo.ReturnTotalRecordCount, result.PageInfo.ReturnTotalRecordCount);
            Assert.Equal(queryExpression.NoLock, result.NoLock);
            Assert.Equal(queryExpression.QueryHints, result.QueryHints);
        }

        [Fact]
        public void QueryExpression_Write()
        {
            // Arrange
            var queryExpression = new QueryExpression("sharepointdocument")
            {
                ColumnSet = new ColumnSet(
                    "documentid",
                    "fullname",
                    "relativelocation",
                    "sharepointcreatedon",
                    "ischeckedout",
                    "filetype",
                    "modified",
                    "sharepointmodifiedby",
                    "servicetype",
                    "absoluteurl",
                    "title",
                    "author",
                    "sharepointdocumentid",
                    "readurl",
                    "editurl",
                    "locationid",
                    "iconclassname",
                    "locationname"),
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("isrecursivefetch", ConditionOperator.Equal, false),
                        new ConditionExpression("regardingobjecttypecode", ConditionOperator.Equal, 1),
                        new ConditionExpression("regardingobjectid", ConditionOperator.Equal, "0a3839b3-08d4-ef11-aeb0-00155d000101")
                    }
                },
                Distinct = false,
                Orders = { new OrderExpression("relativelocation", OrderType.Ascending) },
                PageInfo = new PagingInfo()
                {
                    Count = 10,
                    PageNumber = 1,
                    PagingCookie = null,
                    ReturnTotalRecordCount = true
                },
                NoLock = false,
                QueryHints = "",
            };
            var json = "{\"__type\":\"QueryExpression:http://schemas.microsoft.com/xrm/2011/Contracts\",\"ColumnSet\":{\"AllColumns\":false,\"AttributeExpressions\":[],\"Columns\":[\"documentid\",\"fullname\",\"relativelocation\",\"sharepointcreatedon\",\"ischeckedout\",\"filetype\",\"modified\",\"sharepointmodifiedby\",\"servicetype\",\"absoluteurl\",\"title\",\"author\",\"sharepointdocumentid\",\"readurl\",\"editurl\",\"locationid\",\"iconclassname\",\"locationname\"]},\"Criteria\":{\"Conditions\":[{\"AttributeName\":\"isrecursivefetch\",\"CompareColumns\":false,\"Operator\":0,\"Values\":[false],\"EntityName\":null},{\"AttributeName\":\"regardingobjecttypecode\",\"CompareColumns\":false,\"Operator\":0,\"Values\":[1],\"EntityName\":null},{\"AttributeName\":\"regardingobjectid\",\"CompareColumns\":false,\"Operator\":0,\"Values\":[\"0a3839b3-08d4-ef11-aeb0-00155d000101\"],\"EntityName\":null}],\"FilterOperator\":0,\"Filters\":[]},\"Distinct\":false,\"EntityName\":\"sharepointdocument\",\"LinkEntities\":[],\"Orders\":[{\"AttributeName\":\"relativelocation\",\"OrderType\":0,\"Alias\":null,\"EntityName\":null,\"ExtensionData\":null}],\"PageInfo\":{\"PageNumber\":1,\"Count\":10,\"ReturnTotalRecordCount\":true,\"PagingCookie\":null,\"ExtensionData\":null},\"NoLock\":false,\"QueryHints\":\"\"}";

            // Act
            var result = EntitySerializer.Serialize(queryExpression, typeof(QueryExpression), new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded
            });
            // Assert
            Output.WriteLine($"Serialized result: {result}");
            Assert.Equal(json, result);

        }


        [Fact]
        public void QueryExpression_SerializeObject_Deserialize_Equals()
        {
            var queryExpression = new QueryExpression("account")
            {
                ColumnSet = new ColumnSet(true)
                {
                    Columns = { "name", "address1_city" }
                },
                Criteria = new FilterExpression(LogicalOperator.And)
                {
                    Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, "Test"),
                        new ConditionExpression("address1_city", ConditionOperator.Equal, "Redmond")
                    }
                },
                PageInfo = new PagingInfo()
                {
                    Count = 10,
                    PageNumber = 1,
                    PagingCookie = null,
                    ReturnTotalRecordCount = true
                },
                Orders = {
                    new OrderExpression("name", OrderType.Ascending),
                    new OrderExpression("createdon", OrderType.Descending)
                },
                NoLock = false,
                Distinct = false,
                LinkEntities =
                {
                    new LinkEntity("account", "contact", "primarycontactid", "contactid", JoinOperator.Inner)
                    {
                        Columns = new ColumnSet(true),
                        EntityAlias = "contact",
                        LinkCriteria = new FilterExpression(LogicalOperator.And)
                        {
                            Conditions =
                            {
                                new ConditionExpression("firstname", ConditionOperator.Equal, "John")
                            }
                        },
                        LinkEntities = {
                            new LinkEntity("contact", "account", "contactid", "primarycontactid", JoinOperator.Inner)
                            {
                                Columns = new ColumnSet(true),
                                EntityAlias = "account",
                                LinkCriteria = new FilterExpression(LogicalOperator.And)
                                {
                                    Conditions =
                                    {
                                        new ConditionExpression("name", ConditionOperator.Equal, "Test")
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var json = EntitySerializer.Serialize(queryExpression, typeof(QueryExpression), new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded
            });

            var result = EntitySerializer.Deserialize<QueryExpression>(json);

            Assert.Equal(queryExpression.EntityName, result.EntityName);
            Assert.Equal(queryExpression.ColumnSet.AllColumns, result.ColumnSet.AllColumns);
            Assert.Collection(result.ColumnSet.Columns,
                item => Assert.Equal("name", item),
                item => Assert.Equal("address1_city", item));
            Assert.Equal(queryExpression.Criteria.Conditions.Count, result.Criteria.Conditions.Count);
            Assert.Collection(result.Criteria.Conditions,
                item =>
                {
                    Assert.Equal("name", item.AttributeName);
                    Assert.Equal(ConditionOperator.Equal, item.Operator);
                    Assert.Collection(item.Values, value => Assert.Equal("Test", value));
                },
                item =>
                {
                    Assert.Equal("address1_city", item.AttributeName);
                    Assert.Equal(ConditionOperator.Equal, item.Operator);
                    Assert.Collection(item.Values, value => Assert.Equal("Redmond", value));
                });
            Assert.Equal(queryExpression.Criteria.FilterOperator, result.Criteria.FilterOperator);
            Assert.Equal(queryExpression.PageInfo.Count, result.PageInfo.Count);
            Assert.Equal(queryExpression.PageInfo.PageNumber, result.PageInfo.PageNumber);
            Assert.Equal(queryExpression.PageInfo.PagingCookie, result.PageInfo.PagingCookie);
            Assert.Equal(queryExpression.PageInfo.ReturnTotalRecordCount, result.PageInfo.ReturnTotalRecordCount);
            Assert.Equal(queryExpression.Orders.Count, result.Orders.Count);
            Assert.Collection(result.Orders,
                item => {
                    Assert.Equal("name", item.AttributeName);
                    Assert.Equal(OrderType.Ascending, item.OrderType);
                },
                item => {
                    Assert.Equal("createdon", item.AttributeName);
                    Assert.Equal(OrderType.Descending, item.OrderType);
                });
            Assert.Equal(queryExpression.NoLock, result.NoLock);
            Assert.Equal(queryExpression.Distinct, result.Distinct);
            Assert.Equal(queryExpression.LinkEntities.Count, result.LinkEntities.Count);
            Assert.Collection(result.LinkEntities,
                item =>
                {
                    Assert.Equal("account", item.LinkFromEntityName);
                    Assert.Equal("contact", item.LinkToEntityName);
                    Assert.Equal("primarycontactid", item.LinkFromAttributeName);
                    Assert.Equal("contactid", item.LinkToAttributeName);
                    Assert.Equal(JoinOperator.Inner, item.JoinOperator);
                    Assert.Equal("contact", item.EntityAlias);
                    Assert.Equal(queryExpression.LinkEntities[0].Columns.AllColumns, item.Columns.AllColumns);
                    Assert.Equal(queryExpression.LinkEntities[0].LinkCriteria.FilterOperator, item.LinkCriteria.FilterOperator);
                    Assert.Collection(item.LinkCriteria.Conditions,
                        condition =>
                        {
                            Assert.Equal("firstname", condition.AttributeName);
                            Assert.Equal(ConditionOperator.Equal, condition.Operator);
                            Assert.Collection(condition.Values, value => Assert.Equal("John", value));
                        });
                    Assert.Collection(item.LinkEntities,
                        subItem =>
                        {
                            Assert.Equal("contact", subItem.LinkFromEntityName);
                            Assert.Equal("account", subItem.LinkToEntityName);
                            Assert.Equal("contactid", subItem.LinkFromAttributeName);
                            Assert.Equal("primarycontactid", subItem.LinkToAttributeName);
                            Assert.Equal(JoinOperator.Inner, subItem.JoinOperator);
                            Assert.Equal("account", subItem.EntityAlias);
                            Assert.Equal(queryExpression.LinkEntities[0].LinkEntities[0].Columns.AllColumns, subItem.Columns.AllColumns);
                            Assert.Equal(queryExpression.LinkEntities[0].LinkEntities[0].LinkCriteria.FilterOperator, subItem.LinkCriteria.FilterOperator);
                            Assert.Collection(subItem.LinkCriteria.Conditions,
                                condition =>
                                {
                                    Assert.Equal("name", condition.AttributeName);
                                    Assert.Equal(ConditionOperator.Equal, condition.Operator);
                                    Assert.Collection(condition.Values, value => Assert.Equal("Test", value));
                                });
                        });
                });
        }
    }
}
