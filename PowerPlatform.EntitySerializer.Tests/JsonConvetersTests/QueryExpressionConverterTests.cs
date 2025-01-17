using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
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
    }
}
