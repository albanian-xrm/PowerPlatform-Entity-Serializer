using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace EntitySerializerTests
{
    public class DeserializationFromTextSamplesTests
    {
        private readonly ITestOutputHelper _output;
        public DeserializationFromTextSamplesTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void RemoteExecutionContextCanBeDeserialized_Sample1()
        {
            var input = /*lang=json*/ @"{
""BusinessUnitId"": ""f0bf3c9a-8150-e811-a953-000d3af29fc0"",
""CorrelationId"": ""39499111-e689-42a1-ae8a-5b14a84514ce"",
""Depth"": 1,
""InitiatingUserId"": ""df010dad-f103-4589-ba66-76a5a04c2a11"",
""InputParameters"": [
    {
    ""key"": ""Target"",
    ""value"": {
        ""__type"": ""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
        ""Attributes"": [
        {
            ""key"": ""telephone1"",
            ""value"": ""1111""
        },{
            ""key"": ""accountid"",            ""value"": {""__type"":""Guid:#System"",""__value"":""ec4e2f7d-9d60-e811-a95a-000d3af24950""}          },          {            ""key"": ""modifiedon"",            ""value"": {""__type"":""DateTime:#System"",""__value"":""\/Date(1527757524000)\/""          }},          {            ""key"": ""modifiedby"",            ""value"": {              ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",              ""Id"": ""df010dad-f103-4589-ba66-76a5a04c2a11"",              ""KeyAttributes"": [],              ""LogicalName"": ""systemuser"",              ""Name"": null,              ""RowVersion"": null            }          },          {            ""key"": ""modifiedonbehalfby"",            ""value"": null          }        ],        ""EntityState"": null,        ""FormattedValues"": [],        ""Id"": ""ec4e2f7d-9d60-e811-a95a-000d3af24950"",        ""KeyAttributes"": [],        ""LogicalName"": ""account"",        ""RelatedEntities"": [],        ""RowVersion"": null      }    }  ],  ""IsExecutingOffline"": false,  ""IsInTransaction"": true,  ""IsOfflinePlayback"": false,  ""IsolationMode"": 1,  ""MessageName"": ""Update"",  ""Mode"": 0,  ""OperationCreatedOn"": ""\/Date(1527757530151)\/"",  ""OperationId"": ""08fec203-ec78-4f7a-a024-c96e329a64fe"",  ""OrganizationId"": ""b0714265-8e72-4d3b-8239-ecf0970a3da6"",  ""OrganizationName"": ""org94971a24"",  ""OutputParameters"": [],  ""OwningExtension"": {    ""Id"": ""3db800fe-0963-e811-a95a-000d3af24324"",    ""KeyAttributes"": [],    ""LogicalName"": ""sdkmessageprocessingstep"",    ""Name"": ""D365WebHookHttpTrigger: Update of account"",    ""RowVersion"": null  },  ""ParentContext"": {    ""BusinessUnitId"": ""f0bf3c9a-8150-e811-a953-000d3af29fc0"",    ""CorrelationId"": ""39499111-e689-42a1-ae8a-5b14a84514ce"",    ""Depth"": 1,    ""InitiatingUserId"": ""df010dad-f103-4589-ba66-76a5a04c2a11"",    ""InputParameters"": [      {        ""key"": ""Target"",        ""value"": {          ""__type"": ""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",          ""Attributes"": [            {              ""key"": ""telephone1"",              ""value"": ""1111""            },            {              ""key"": ""accountid"",              ""value"": ""ec4e2f7d-9d60-e811-a95a-000d3af24950""            }          ],          ""EntityState"": null,          ""FormattedValues"": [],          ""Id"": ""ec4e2f7d-9d60-e811-a95a-000d3af24950"",          ""KeyAttributes"": [],          ""LogicalName"": ""account"",          ""RelatedEntities"": [],          ""RowVersion"": null        }      },      {        ""key"": ""SuppressDuplicateDetection"",        ""value"": false      }    ],    ""IsExecutingOffline"": false,    ""IsInTransaction"": true,    ""IsOfflinePlayback"": false,    ""IsolationMode"": 1,    ""MessageName"": ""Update"",    ""Mode"": 0,    ""OperationCreatedOn"": ""\/Date(1527757524631)\/"",    ""OperationId"": ""08fec203-ec78-4f7a-a024-c96e329a64fe"",    ""OrganizationId"": ""b0714265-8e72-4d3b-8239-ecf0970a3da6"",    ""OrganizationName"": ""org94971a24"",    ""OutputParameters"": [],    ""OwningExtension"": {      ""Id"": ""63cdbb1b-ea3e-db11-86a7-000a3a5473e8"",      ""KeyAttributes"": [],      ""LogicalName"": ""sdkmessageprocessingstep"",      ""Name"": ""ObjectModel Implementation"",      ""RowVersion"": null    },    ""ParentContext"": null,    ""PostEntityImages"": [],    ""PreEntityImages"": [],    ""PrimaryEntityId"": ""ec4e2f7d-9d60-e811-a95a-000d3af24950"",    ""PrimaryEntityName"": ""account"",    ""RequestId"": ""08fec203-ec78-4f7a-a024-c96e329a64fe"",    ""SecondaryEntityName"": ""none"",    ""SharedVariables"": [      {        ""key"": ""ChangedEntityTypes"",        ""value"": [          {            ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",            ""key"": ""account"",            ""value"": ""Update""          }        ]      }    ],    ""Stage"": 30,    ""UserId"": ""df010dad-f103-4589-ba66-76a5a04c2a11""  },  ""PostEntityImages"": [],  ""PreEntityImages"": [],  ""PrimaryEntityId"": ""ec4e2f7d-9d60-e811-a95a-000d3af24950"",  ""PrimaryEntityName"": ""account"",  ""RequestId"": ""08fec203-ec78-4f7a-a024-c96e329a64fe"",  ""SecondaryEntityName"": ""none"",  ""SharedVariables"": [],  ""Stage"": 40,  ""UserId"": ""df010dad-f103-4589-ba66-76a5a04c2a11""}";
            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(input);

            Assert.NotNull(remoteExecutionContext);
            Assert.Equal(Guid.Parse("f0bf3c9a-8150-e811-a953-000d3af29fc0"), remoteExecutionContext.BusinessUnitId);
            Assert.Equal(Guid.Parse("39499111-e689-42a1-ae8a-5b14a84514ce"), remoteExecutionContext.CorrelationId);
            Assert.Equal(1, remoteExecutionContext.Depth);
            Assert.Equal(Guid.Parse("df010dad-f103-4589-ba66-76a5a04c2a11"), remoteExecutionContext.InitiatingUserId);

        }

        [Fact]
        public void RemoteExecutionContextCanBeDeserialized_Sample2()
        {
            var input = @"{""BusinessUnitId"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"", ""CorrelationId"":""9d4c7524-a578-4783-b608-73f7b0b68fd2"", ""Depth"":1, ""InitiatingUserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"", ""InitiatingUserId"":""a0bde583-0537-eb11-bf68-0022489b563d"", ""InputParameters"":[{""key"":""Target"",""value"":{""__type"":""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Attributes"":[{""key"":""albxrm_twooptions"",""value"":true},{""key"":""albxrm_lookupaccount"",""value"":{""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""b76b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{ ""key"":""albxrm_wholenumber"",""value"":987654321},{ ""key"":""owningbusinessunit"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""businessunit"",""Name"":null,""RowVersion"":null} },{ ""key"":""modifiedon"",""value"":""\/Date(1608007658000)\/""},{ ""key"":""albxrm_name"",""value"":""Test Betim""},{ ""key"":""albxrm_multiplelinesoftext"",""value"":""sdafasf\u000aasdfas\u000aafsd""},{ ""key"":""ownerid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""createdby"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_customer"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""ad6b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""},{ ""key"":""timezoneruleversionnumber"",""value"":0},{ ""key"":""transactioncurrencyid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""083081e1-0737-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""transactioncurrency"",""Name"":null,""RowVersion"":null} },{ ""key"":""modifiedonbehalfby"",""value"":null},{ ""key"":""albxrm_currency"",""value"":{ ""__type"":""Money:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":2154.32} },{ ""key"":""albxrm_optionset"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001} },{ ""key"":""albxrm_multiselectoptionset"",""value"":[{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001},{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760002}]},{ ""key"":""albxrm_float"",""value"":2365.12},{ ""key"":""modifiedby"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_dateandtime"",""value"":""\/Date(1608015600000)\/""},{ ""key"":""createdon"",""value"":""\/Date(1608007658000)\/""},{ ""key"":""statecode"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":0} },{ ""key"":""statuscode"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":1} },{ ""key"":""albxrm_decimal"",""value"":10.01},{ ""key"":""exchangerate"",""value"":1.0000000000},{ ""key"":""albxrm_currency_base"",""value"":{ ""__type"":""Money:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":2154.32} }],""EntityState"":null,""FormattedValues"":[{""key"":""albxrm_twooptions"",""value"":""Yes""},{ ""key"":""albxrm_wholenumber"",""value"":""987,654,321""},{ ""key"":""modifiedon"",""value"":""2020-12-15T05:47:38+01:00""},{ ""key"":""timezoneruleversionnumber"",""value"":""0""},{ ""key"":""albxrm_currency"",""value"":""Ã¢âÂ¬2,154.32""},{ ""key"":""albxrm_optionset"",""value"":""Value 2""},{ ""key"":""albxrm_multiselectoptionset"",""value"":""Value 1; Value 2""},{ ""key"":""albxrm_float"",""value"":""2,365.12""},{ ""key"":""albxrm_dateandtime"",""value"":""2020-12-15T08:00:00+01:00""},{ ""key"":""createdon"",""value"":""2020-12-15T05:47:38+01:00""},{ ""key"":""statecode"",""value"":""Active""},{ ""key"":""statuscode"",""value"":""Active""},{ ""key"":""albxrm_decimal"",""value"":""10.01""}],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}}],""IsExecutingOffline"":false,""IsInTransaction"":false,""IsOfflinePlayback"":false,""IsolationMode"":1,""MessageName"":""Create"",""Mode"":1,""OperationCreatedOn"":""\/Date(1608007658000+0000)\/"",""OperationId"":""45bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""OrganizationId"":""0ba4ce62-d2d6-4681-bc25-b3bfb695d4d6"",""OrganizationName"":""0ba4ce62d2d64681bc25b3bfb695d4d6"",""OutputParameters"":[{""key"":""id"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""OwningExtension"":{ ""Id"":""2c28fe56-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""sdkmessageprocessingstep"",""Name"":null,""RowVersion"":null},""ParentContext"":{ ""BusinessUnitId"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""CorrelationId"":""9d4c7524-a578-4783-b608-73f7b0b68fd2"",""Depth"":1,""InitiatingUserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""InitiatingUserId"":""a0bde583-0537-eb11-bf68-0022489b563d"",""InputParameters"":[{ ""key"":""Target"",""value"":{ ""__type"":""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Attributes"":[{ ""key"":""albxrm_name"",""value"":""Test Betim""},{ ""key"":""albxrm_wholenumber"",""value"":987654321},{ ""key"":""albxrm_dateandtime"",""value"":""\/Date(1608015600000)\/""},{ ""key"":""albxrm_twooptions"",""value"":true},{ ""key"":""albxrm_float"",""value"":2365.12},{ ""key"":""albxrm_lookupaccount"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""b76b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_customer"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""ad6b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_multiplelinesoftext"",""value"":""sdafasf\u000aasdfas\u000aafsd""},{ ""key"":""albxrm_multiselectoptionset"",""value"":[{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001},{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760002}]},{ ""key"":""albxrm_optionset"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001} },{ ""key"":""albxrm_decimal"",""value"":10.01},{ ""key"":""albxrm_currency"",""value"":{ ""__type"":""Money:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":2154.32} },{ ""key"":""ownerid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""transactioncurrencyid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""083081e1-0737-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""transactioncurrency"",""Name"":null,""RowVersion"":null} },{ ""key"":""statuscode"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":1} },{ ""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""EntityState"":null,""FormattedValues"":[{ ""key"":""albxrm_wholenumber"",""value"":""987654321""},{ ""key"":""albxrm_twooptions"",""value"":""True""},{ ""key"":""albxrm_decimal"",""value"":""10.01""}],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null} },{ ""key"":""SuppressDuplicateDetection"",""value"":false}],""IsExecutingOffline"":false,""IsInTransaction"":false,""IsOfflinePlayback"":false,""IsolationMode"":1,""MessageName"":""Create"",""Mode"":1,""OperationCreatedOn"":""\/Date(1608007658000+0000)\/"",""OperationId"":""45bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""OrganizationId"":""0ba4ce62-d2d6-4681-bc25-b3bfb695d4d6"",""OrganizationName"":""0ba4ce62d2d64681bc25b3bfb695d4d6"",""OutputParameters"":[],""OwningExtension"":{ ""Id"":""2c28fe56-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""sdkmessageprocessingstep"",""Name"":null,""RowVersion"":null},""ParentContext"":null,""PostEntityImages"":[],""PreEntityImages"":[],""PrimaryEntityId"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""PrimaryEntityName"":""albxrm_alltypes"",""RequestId"":""3fab629b-b795-4834-a2ca-5a09b2cc6934"",""SecondaryEntityName"":""none"",""SharedVariables"":[{ ""key"":""IsAutoTransact"",""value"":true},{ ""key"":""DefaultsAddedFlag"",""value"":true}],""Stage"":30,""UserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""UserId"":""a0bde583-0537-eb11-bf68-0022489b563d""},""PostEntityImages"":[{""key"":""AsynchronousStepPrimaryName"",""value"":{""Attributes"":[{""key"":""albxrm_name"",""value"":""Test Betim""},{ ""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""EntityState"":null,""FormattedValues"":[],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}}],""PreEntityImages"":[],""PrimaryEntityId"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""PrimaryEntityName"":""albxrm_alltypes"",""RequestId"":""3fab629b-b795-4834-a2ca-5a09b2cc6934"",""SecondaryEntityName"":""none"",""SharedVariables"":[{""key"":""IsAutoTransact"",""value"":true},{ ""key"":""DefaultsAddedFlag"",""value"":true}],""Stage"":40,""UserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""UserId"":""a0bde583-0537-eb11-bf68-0022489b563d""}";
            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(input);

            Assert.NotNull(remoteExecutionContext);
        }

        [Fact]
        public void RemoteExecutionContextCanBeDeserializedAndSerialized_Sample2()
        {
            var input = @"{""BusinessUnitId"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"", ""CorrelationId"":""9d4c7524-a578-4783-b608-73f7b0b68fd2"", ""Depth"":1, ""InitiatingUserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"", ""InitiatingUserId"":""a0bde583-0537-eb11-bf68-0022489b563d"", ""InputParameters"":[{""key"":""Target"",""value"":{""__type"":""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Attributes"":[{""key"":""albxrm_twooptions"",""value"":true},{""key"":""albxrm_lookupaccount"",""value"":{""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""b76b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{ ""key"":""albxrm_wholenumber"",""value"":987654321},{ ""key"":""owningbusinessunit"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""businessunit"",""Name"":null,""RowVersion"":null} },{ ""key"":""modifiedon"",""value"":""\/Date(1608007658000)\/""},{ ""key"":""albxrm_name"",""value"":""Test Betim""},{ ""key"":""albxrm_multiplelinesoftext"",""value"":""sdafasf\u000aasdfas\u000aafsd""},{ ""key"":""ownerid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""createdby"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_customer"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""ad6b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""},{ ""key"":""timezoneruleversionnumber"",""value"":0},{ ""key"":""transactioncurrencyid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""083081e1-0737-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""transactioncurrency"",""Name"":null,""RowVersion"":null} },{ ""key"":""modifiedonbehalfby"",""value"":null},{ ""key"":""albxrm_currency"",""value"":{ ""__type"":""Money:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":2154.32} },{ ""key"":""albxrm_optionset"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001} },{ ""key"":""albxrm_multiselectoptionset"",""value"":[{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001},{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760002}]},{ ""key"":""albxrm_float"",""value"":2365.12},{ ""key"":""modifiedby"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_dateandtime"",""value"":""\/Date(1608015600000)\/""},{ ""key"":""createdon"",""value"":""\/Date(1608007658000)\/""},{ ""key"":""statecode"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":0} },{ ""key"":""statuscode"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":1} },{ ""key"":""albxrm_decimal"",""value"":10.01},{ ""key"":""exchangerate"",""value"":1.0000000000},{ ""key"":""albxrm_currency_base"",""value"":{ ""__type"":""Money:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":2154.32} }],""EntityState"":null,""FormattedValues"":[{""key"":""albxrm_twooptions"",""value"":""Yes""},{ ""key"":""albxrm_wholenumber"",""value"":""987,654,321""},{ ""key"":""modifiedon"",""value"":""2020-12-15T05:47:38+01:00""},{ ""key"":""timezoneruleversionnumber"",""value"":""0""},{ ""key"":""albxrm_currency"",""value"":""Ã¢âÂ¬2,154.32""},{ ""key"":""albxrm_optionset"",""value"":""Value 2""},{ ""key"":""albxrm_multiselectoptionset"",""value"":""Value 1; Value 2""},{ ""key"":""albxrm_float"",""value"":""2,365.12""},{ ""key"":""albxrm_dateandtime"",""value"":""2020-12-15T08:00:00+01:00""},{ ""key"":""createdon"",""value"":""2020-12-15T05:47:38+01:00""},{ ""key"":""statecode"",""value"":""Active""},{ ""key"":""statuscode"",""value"":""Active""},{ ""key"":""albxrm_decimal"",""value"":""10.01""}],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}}],""IsExecutingOffline"":false,""IsInTransaction"":false,""IsOfflinePlayback"":false,""IsolationMode"":1,""MessageName"":""Create"",""Mode"":1,""OperationCreatedOn"":""\/Date(1608007658000+0000)\/"",""OperationId"":""45bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""OrganizationId"":""0ba4ce62-d2d6-4681-bc25-b3bfb695d4d6"",""OrganizationName"":""0ba4ce62d2d64681bc25b3bfb695d4d6"",""OutputParameters"":[{""key"":""id"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""OwningExtension"":{ ""Id"":""2c28fe56-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""sdkmessageprocessingstep"",""Name"":null,""RowVersion"":null},""ParentContext"":{ ""BusinessUnitId"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""CorrelationId"":""9d4c7524-a578-4783-b608-73f7b0b68fd2"",""Depth"":1,""InitiatingUserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""InitiatingUserId"":""a0bde583-0537-eb11-bf68-0022489b563d"",""InputParameters"":[{ ""key"":""Target"",""value"":{ ""__type"":""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Attributes"":[{ ""key"":""albxrm_name"",""value"":""Test Betim""},{ ""key"":""albxrm_wholenumber"",""value"":987654321},{ ""key"":""albxrm_dateandtime"",""value"":""\/Date(1608015600000)\/""},{ ""key"":""albxrm_twooptions"",""value"":true},{ ""key"":""albxrm_float"",""value"":2365.12},{ ""key"":""albxrm_lookupaccount"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""b76b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_customer"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""ad6b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null} },{ ""key"":""albxrm_multiplelinesoftext"",""value"":""sdafasf\u000aasdfas\u000aafsd""},{ ""key"":""albxrm_multiselectoptionset"",""value"":[{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001},{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760002}]},{ ""key"":""albxrm_optionset"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":257760001} },{ ""key"":""albxrm_decimal"",""value"":10.01},{ ""key"":""albxrm_currency"",""value"":{ ""__type"":""Money:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":2154.32} },{ ""key"":""ownerid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null} },{ ""key"":""transactioncurrencyid"",""value"":{ ""__type"":""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Id"":""083081e1-0737-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""transactioncurrency"",""Name"":null,""RowVersion"":null} },{ ""key"":""statuscode"",""value"":{ ""__type"":""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",""Value"":1} },{ ""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""EntityState"":null,""FormattedValues"":[{ ""key"":""albxrm_wholenumber"",""value"":""987654321""},{ ""key"":""albxrm_twooptions"",""value"":""True""},{ ""key"":""albxrm_decimal"",""value"":""10.01""}],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null} },{ ""key"":""SuppressDuplicateDetection"",""value"":false}],""IsExecutingOffline"":false,""IsInTransaction"":false,""IsOfflinePlayback"":false,""IsolationMode"":1,""MessageName"":""Create"",""Mode"":1,""OperationCreatedOn"":""\/Date(1608007658000+0000)\/"",""OperationId"":""45bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""OrganizationId"":""0ba4ce62-d2d6-4681-bc25-b3bfb695d4d6"",""OrganizationName"":""0ba4ce62d2d64681bc25b3bfb695d4d6"",""OutputParameters"":[],""OwningExtension"":{ ""Id"":""2c28fe56-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""sdkmessageprocessingstep"",""Name"":null,""RowVersion"":null},""ParentContext"":null,""PostEntityImages"":[],""PreEntityImages"":[],""PrimaryEntityId"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""PrimaryEntityName"":""albxrm_alltypes"",""RequestId"":""3fab629b-b795-4834-a2ca-5a09b2cc6934"",""SecondaryEntityName"":""none"",""SharedVariables"":[{ ""key"":""IsAutoTransact"",""value"":true},{ ""key"":""DefaultsAddedFlag"",""value"":true}],""Stage"":30,""UserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""UserId"":""a0bde583-0537-eb11-bf68-0022489b563d""},""PostEntityImages"":[{""key"":""AsynchronousStepPrimaryName"",""value"":{""Attributes"":[{""key"":""albxrm_name"",""value"":""Test Betim""},{ ""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""EntityState"":null,""FormattedValues"":[],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}}],""PreEntityImages"":[],""PrimaryEntityId"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""PrimaryEntityName"":""albxrm_alltypes"",""RequestId"":""3fab629b-b795-4834-a2ca-5a09b2cc6934"",""SecondaryEntityName"":""none"",""SharedVariables"":[{""key"":""IsAutoTransact"",""value"":true},{ ""key"":""DefaultsAddedFlag"",""value"":true}],""Stage"":40,""UserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""UserId"":""a0bde583-0537-eb11-bf68-0022489b563d""}";
            //var input = @"{""BusinessUnitId"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""CorrelationId"":""9d4c7524-a578-4783-b608-73f7b0b68fd2"",""Depth"":1,""InitiatingUserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""InitiatingUserId"":""a0bde583-0537-eb11-bf68-0022489b563d"",""InputParameters"":[{""key"":""Target"",""value"":{""__type"":""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",""Attributes"":[{""key"":""albxrm_twooptions"",""value"":true},{""key"":""albxrm_lookupaccount"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""b76b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{""key"":""albxrm_wholenumber"",""value"":987654321},{""key"":""owningbusinessunit"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""businessunit"",""Name"":null,""RowVersion"":null}},{""key"":""modifiedon"",""value"":""/Date(1608007658000)/""},{""key"":""albxrm_name"",""value"":""Test Betim""},{""key"":""albxrm_multiplelinesoftext"",""value"":""sdafasf\nasdfas\nafsd""},{""key"":""ownerid"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null}},{""key"":""createdby"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null}},{""key"":""albxrm_customer"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""ad6b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""},{""key"":""timezoneruleversionnumber"",""value"":0},{""key"":""transactioncurrencyid"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""083081e1-0737-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""transactioncurrency"",""Name"":null,""RowVersion"":null}},{""key"":""modifiedonbehalfby"",""value"":null},{""key"":""albxrm_currency"",""value"":{""__type"":""Money:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":2154.32}},{""key"":""albxrm_optionset"",""value"":{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":257760001}},{""key"":""albxrm_multiselectoptionset"",""value"":[{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":257760001},{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":257760002}]},{""key"":""albxrm_float"",""value"":2365.12},{""key"":""modifiedby"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null}},{""key"":""albxrm_dateandtime"",""value"":""/Date(1608015600000)/""},{""key"":""createdon"",""value"":""/Date(1608007658000)/""},{""key"":""statecode"",""value"":{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":0}},{""key"":""statuscode"",""value"":{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":1}},{""key"":""albxrm_decimal"",""value"":10.01},{""key"":""exchangerate"",""value"":1},{""key"":""albxrm_currency_base"",""value"":{""__type"":""Money:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":2154.32}}],""EntityState"":null,""FormattedValues"":[{""key"":""albxrm_twooptions"",""value"":""Yes""},{""key"":""albxrm_wholenumber"",""value"":""987,654,321""},{""key"":""modifiedon"",""value"":""2020-12-15T05:47:38+01:00""},{""key"":""timezoneruleversionnumber"",""value"":""0""},{""key"":""albxrm_currency"",""value"":""Ã¢âÂ¬2,154.32""},{""key"":""albxrm_optionset"",""value"":""Value 2""},{""key"":""albxrm_multiselectoptionset"",""value"":""Value 1; Value 2""},{""key"":""albxrm_float"",""value"":""2,365.12""},{""key"":""albxrm_dateandtime"",""value"":""2020-12-15T08:00:00+01:00""},{""key"":""createdon"",""value"":""2020-12-15T05:47:38+01:00""},{""key"":""statecode"",""value"":""Active""},{""key"":""statuscode"",""value"":""Active""},{""key"":""albxrm_decimal"",""value"":""10.01""}],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}}],""IsExecutingOffline"":false,""IsInTransaction"":false,""IsOfflinePlayback"":false,""IsolationMode"":1,""MessageName"":""Create"",""Mode"":1,""OperationCreatedOn"":""/Date(1608007658000+0000)/"",""OperationId"":""45bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""OrganizationId"":""0ba4ce62-d2d6-4681-bc25-b3bfb695d4d6"",""OrganizationName"":""0ba4ce62d2d64681bc25b3bfb695d4d6"",""OutputParameters"":[{""key"":""id"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""OwningExtension"":{""Id"":""2c28fe56-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""sdkmessageprocessingstep"",""Name"":null,""RowVersion"":null},""ParentContext"":{""BusinessUnitId"":""c3ec0cc2-d836-eb11-bf68-0022489b563d"",""CorrelationId"":""9d4c7524-a578-4783-b608-73f7b0b68fd2"",""Depth"":1,""InitiatingUserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""InitiatingUserId"":""a0bde583-0537-eb11-bf68-0022489b563d"",""InputParameters"":[{""key"":""Target"",""value"":{""__type"":""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",""Attributes"":[{""key"":""albxrm_name"",""value"":""Test Betim""},{""key"":""albxrm_wholenumber"",""value"":987654321},{""key"":""albxrm_dateandtime"",""value"":""/Date(1608015600000)/""},{""key"":""albxrm_twooptions"",""value"":true},{""key"":""albxrm_float"",""value"":2365.12},{""key"":""albxrm_lookupaccount"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""b76b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{""key"":""albxrm_customer"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""ad6b3f4b-1be7-e611-8101-e0071b6af231"",""KeyAttributes"":[],""LogicalName"":""account"",""Name"":null,""RowVersion"":null}},{""key"":""albxrm_multiplelinesoftext"",""value"":""sdafasf\nasdfas\nafsd""},{""key"":""albxrm_multiselectoptionset"",""value"":[{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":257760001},{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":257760002}]},{""key"":""albxrm_optionset"",""value"":{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":257760001}},{""key"":""albxrm_decimal"",""value"":10.01},{""key"":""albxrm_currency"",""value"":{""__type"":""Money:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":2154.32}},{""key"":""ownerid"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""a0bde583-0537-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""systemuser"",""Name"":null,""RowVersion"":null}},{""key"":""transactioncurrencyid"",""value"":{""__type"":""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",""Id"":""083081e1-0737-eb11-bf68-0022489b563d"",""KeyAttributes"":[],""LogicalName"":""transactioncurrency"",""Name"":null,""RowVersion"":null}},{""key"":""statuscode"",""value"":{""__type"":""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",""Value"":1}},{""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""EntityState"":null,""FormattedValues"":[{""key"":""albxrm_wholenumber"",""value"":""987654321""},{""key"":""albxrm_twooptions"",""value"":""True""},{""key"":""albxrm_decimal"",""value"":""10.01""}],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}},{""key"":""SuppressDuplicateDetection"",""value"":false}],""IsExecutingOffline"":false,""IsInTransaction"":false,""IsOfflinePlayback"":false,""IsolationMode"":1,""MessageName"":""Create"",""Mode"":1,""OperationCreatedOn"":""/Date(1608007658000+0000)/"",""OperationId"":""45bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""OrganizationId"":""0ba4ce62-d2d6-4681-bc25-b3bfb695d4d6"",""OrganizationName"":""0ba4ce62d2d64681bc25b3bfb695d4d6"",""OutputParameters"":[],""OwningExtension"":{""Id"":""2c28fe56-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""sdkmessageprocessingstep"",""Name"":null,""RowVersion"":null},""ParentContext"":null,""PostEntityImages"":[],""PreEntityImages"":[],""PrimaryEntityId"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""PrimaryEntityName"":""albxrm_alltypes"",""RequestId"":""3fab629b-b795-4834-a2ca-5a09b2cc6934"",""SecondaryEntityName"":""none"",""SharedVariables"":[{""key"":""IsAutoTransact"",""value"":true},{""key"":""DefaultsAddedFlag"",""value"":true}],""Stage"":30,""UserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""UserId"":""a0bde583-0537-eb11-bf68-0022489b563d""},""PostEntityImages"":[{""key"":""AsynchronousStepPrimaryName"",""value"":{""Attributes"":[{""key"":""albxrm_name"",""value"":""Test Betim""},{""key"":""albxrm_alltypesid"",""value"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1""}],""EntityState"":null,""FormattedValues"":[],""Id"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""KeyAttributes"":[],""LogicalName"":""albxrm_alltypes"",""RelatedEntities"":[],""RowVersion"":null}}],""PreEntityImages"":[],""PrimaryEntityId"":""44bfc2a7-903e-eb11-a813-000d3ad9c2e1"",""PrimaryEntityName"":""albxrm_alltypes"",""RequestId"":""3fab629b-b795-4834-a2ca-5a09b2cc6934"",""SecondaryEntityName"":""none"",""SharedVariables"":[{""key"":""IsAutoTransact"",""value"":true},{""key"":""DefaultsAddedFlag"",""value"":true}],""Stage"":40,""UserAzureActiveDirectoryObjectId"":""00000000-0000-0000-0000-000000000000"",""UserId"":""a0bde583-0537-eb11-bf68-0022489b563d""}";
            var inputContext = EntitySerializer.Deserialize<RemoteExecutionContext>(input);

            Assert.NotNull(inputContext);           
           var output = EntitySerializer.Serialize(inputContext, typeof(RemoteExecutionContext), new EntitySerializerOptions()
            {
                WriteSchema = WriteSchemaOptions.IfNeeded,
                DateOptions = DateOptions.SerializeXrmDate
            });
            _output.WriteLine(input);
            _output.WriteLine(output);
            var outputContext = EntitySerializer.Deserialize<RemoteExecutionContext>(output);
            Assert.NotNull(output);
            Assert.Equivalent(inputContext, outputContext, true);
        }

        [Fact]
        public void RemoteExecutionContextFromDocumentationCanBeDeserialized()
        {
            //Payload comes from: https://learn.microsoft.com/en-us/power-apps/developer/data-platform/use-webhooks
            var input = @"{
    ""BusinessUnitId"": ""e2b9dd85-e89e-e711-8122-000d3aa2331c"",
    ""CorrelationId"": ""aaaa0000-bb11-2222-33cc-444444dddddd"",
    ""Depth"": 1,
    ""InitiatingUserId"": ""11bb11bb-cc22-dd33-ee44-55ff55ff55ff"",
    ""InputParameters"": [{
        ""key"": ""Target"",
        ""value"": {
            ""__type"": ""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
            ""Attributes"": [{
                ""key"": ""firstname"",
                ""value"": ""James""
            }, {
                ""key"": ""contactid"",
                ""value"": ""6d81597f-0f9f-e711-8122-000d3aa2331c""
            }, {
                ""key"": ""fullname"",
                ""value"": ""James Glynn (sample)""
            }, {
                ""key"": ""yomifullname"",
                ""value"": ""James Glynn (sample)""
            }, {
                ""key"": ""modifiedon"",
                ""value"": ""\/Date(1506384247000)\/""
            }, {
                ""key"": ""modifiedby"",
                ""value"": {
                    ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                    ""Id"": ""11bb11bb-cc22-dd33-ee44-55ff55ff55ff"",
                    ""KeyAttributes"": [],
                    ""LogicalName"": ""systemuser"",
                    ""Name"": null,
                    ""RowVersion"": null
                }
            }, {
                ""key"": ""modifiedonbehalfby"",
                ""value"": null
            }],
            ""EntityState"": null,
            ""FormattedValues"": [],
            ""Id"": ""6d81597f-0f9f-e711-8122-000d3aa2331c"",
            ""KeyAttributes"": [],
            ""LogicalName"": ""contact"",
            ""RelatedEntities"": [],
            ""RowVersion"": null
        }
    }],
    ""IsExecutingOffline"": false,
    ""IsInTransaction"": false,
    ""IsOfflinePlayback"": false,
    ""IsolationMode"": 1,
    ""MessageName"": ""Update"",
    ""Mode"": 1,
    ""OperationCreatedOn"": ""\/Date(1506409448000-0700)\/"",
    ""OperationId"": ""4af10637-4ea2-e711-8122-000d3aa2331c"",
    ""OrganizationId"": ""00aa00aa-bb11-cc22-dd33-44ee44ee44ee"",
    ""OrganizationName"": ""OrgName"",
    ""OutputParameters"": [],
    ""OwningExtension"": {
        ""Id"": ""75417616-4ea2-e711-8122-000d3aa2331c"",
        ""KeyAttributes"": [],
        ""LogicalName"": ""sdkmessageprocessingstep"",
        ""Name"": null,
        ""RowVersion"": null
    },
    ""ParentContext"": {
        ""BusinessUnitId"": ""e2b9dd85-e89e-e711-8122-000d3aa2331c"",
        ""CorrelationId"": ""aaaa0000-bb11-2222-33cc-444444dddddd"",
        ""Depth"": 1,
        ""InitiatingUserId"": ""11bb11bb-cc22-dd33-ee44-55ff55ff55ff"",
        ""InputParameters"": [{
            ""key"": ""Target"",
            ""value"": {
                ""__type"": ""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                ""Attributes"": [{
                    ""key"": ""firstname"",
                    ""value"": ""James""
                }, {
                    ""key"": ""contactid"",
                    ""value"": ""6d81597f-0f9f-e711-8122-000d3aa2331c""
                }],
                ""EntityState"": null,
                ""FormattedValues"": [],
                ""Id"": ""6d81597f-0f9f-e711-8122-000d3aa2331c"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""contact"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        }, {
            ""key"": ""SuppressDuplicateDetection"",
            ""value"": false
        }],
        ""IsExecutingOffline"": false,
        ""IsInTransaction"": false,
        ""IsOfflinePlayback"": false,
        ""IsolationMode"": 1,
        ""MessageName"": ""Update"",
        ""Mode"": 1,
        ""OperationCreatedOn"": ""\/Date(1506409448000-0700)\/"",
        ""OperationId"": ""4af10637-4ea2-e711-8122-000d3aa2331c"",
        ""OrganizationId"": ""00aa00aa-bb11-cc22-dd33-44ee44ee44ee"",
        ""OrganizationName"": ""OneFarm"",
        ""OutputParameters"": [],
        ""OwningExtension"": {
            ""Id"": ""75417616-4ea2-e711-8122-000d3aa2331c"",
            ""KeyAttributes"": [],
            ""LogicalName"": ""sdkmessageprocessingstep"",
            ""Name"": null,
            ""RowVersion"": null
        },
        ""ParentContext"": null,
        ""PostEntityImages"": [],
        ""PreEntityImages"": [],
        ""PrimaryEntityId"": ""6d81597f-0f9f-e711-8122-000d3aa2331c"",
        ""PrimaryEntityName"": ""contact"",
        ""RequestId"": null,
        ""SecondaryEntityName"": ""none"",
        ""SharedVariables"": [{
            ""key"": ""ChangedEntityTypes"",
            ""value"": [{
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""feedback"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""contract"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""salesorder"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""connection"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""socialactivity"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""postfollow"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""incident"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""invoice"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""entitlement"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""lead"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""opportunity"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""quote"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""socialprofile"",
                ""value"": ""Update""
            }, {
                ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
                ""key"": ""contact"",
                ""value"": ""Update""
            }]
        }],
        ""Stage"": 30,
        ""UserId"": ""11bb11bb-cc22-dd33-ee44-55ff55ff55ff""
    },
    ""PostEntityImages"": [{
        ""key"": ""AsynchronousStepPrimaryName"",
        ""value"": {
            ""Attributes"": [{
                ""key"": ""fullname"",
                ""value"": ""James Glynn (sample)""
            }, {
                ""key"": ""contactid"",
                ""value"": ""6d81597f-0f9f-e711-8122-000d3aa2331c""
            }],
            ""EntityState"": null,
            ""FormattedValues"": [],
            ""Id"": ""6d81597f-0f9f-e711-8122-000d3aa2331c"",
            ""KeyAttributes"": [],
            ""LogicalName"": ""contact"",
            ""RelatedEntities"": [],
            ""RowVersion"": null
        }
    }],
    ""PreEntityImages"": [],
    ""PrimaryEntityId"": ""6d81597f-0f9f-e711-8122-000d3aa2331c"",
    ""PrimaryEntityName"": ""contact"",
    ""RequestId"": null,
    ""SecondaryEntityName"": ""none"",
    ""SharedVariables"": [],
    ""Stage"": 40,
    ""UserId"": ""11bb11bb-cc22-dd33-ee44-55ff55ff55ff""
}";

            var deserialized = EntitySerializer.Deserialize<RemoteExecutionContext>(input, new EntitySerializerOptions());
            Assert.NotNull(deserialized);
            //Assert ChangedEntityTypes
            Assert.Equal(1, deserialized.ParentContext.SharedVariables.Count);
            var changedEntityTypes = deserialized.ParentContext.SharedVariables["ChangedEntityTypes"] as Dictionary<string, string>;
            Assert.Equal(14, changedEntityTypes.Count);
            Assert.NotNull(changedEntityTypes);
            Assert.Equal(new Dictionary<string, string>
            {
                { "feedback", "Update" },
                { "contract", "Update" },
                { "salesorder", "Update" },
                { "connection", "Update" },
                { "socialactivity", "Update" },
                { "postfollow", "Update" },
                { "incident", "Update" },
                { "invoice", "Update" },
                { "entitlement", "Update" },
                { "lead", "Update" },
                { "opportunity", "Update" },
                { "quote", "Update" },
                { "socialprofile", "Update" },
                { "contact", "Update" }
            }, changedEntityTypes);

            //Assert other aspects of the RemoteExecutionContext
            var target = deserialized.InputParameters["Target"] as Entity;
            Assert.NotNull(target);
            Assert.Equal(7, target.Attributes.Count);
            Assert.Equal("James", target["firstname"]);
            Assert.Equal(new Guid("6d81597f-0f9f-e711-8122-000d3aa2331c"), target.Id);
            Assert.Equal("James Glynn (sample)", target["fullname"]);
            Assert.Equal("James Glynn (sample)", target["yomifullname"]);
            Assert.Equal(new Guid("11bb11bb-cc22-dd33-ee44-55ff55ff55ff"), (target["modifiedby"] as EntityReference).Id);
            Assert.Null(target["modifiedonbehalfby"]);
            Assert.Equal(new Guid("e2b9dd85-e89e-e711-8122-000d3aa2331c"), deserialized.BusinessUnitId);
            Assert.Equal(new Guid("aaaa0000-bb11-2222-33cc-444444dddddd"), deserialized.CorrelationId);
            Assert.Equal(1, deserialized.Depth);
            Assert.Equal(new Guid("11bb11bb-cc22-dd33-ee44-55ff55ff55ff"), deserialized.InitiatingUserId);
            Assert.Equal(1, deserialized.InputParameters.Count);
            Assert.Equal("Update", deserialized.MessageName);
            Assert.Equal(1, deserialized.Mode);
            Assert.Equal(new Guid("4af10637-4ea2-e711-8122-000d3aa2331c"), deserialized.OperationId);
            Assert.Equal(new Guid("00aa00aa-bb11-cc22-dd33-44ee44ee44ee"), deserialized.OrganizationId);
            Assert.Equal("OrgName", deserialized.OrganizationName);
            Assert.Equal(0, deserialized.OutputParameters.Count);
            Assert.Equal(new Guid("75417616-4ea2-e711-8122-000d3aa2331c"), deserialized.OwningExtension.Id);
            Assert.Equal("sdkmessageprocessingstep", deserialized.OwningExtension.LogicalName);
            Assert.Equal(2, deserialized.ParentContext.InputParameters.Count);
            Assert.Equal("Update", deserialized.ParentContext.MessageName);
            Assert.Equal(1, deserialized.ParentContext.Mode);
            Assert.Equal(new Guid("4af10637-4ea2-e711-8122-000d3aa2331c"), deserialized.ParentContext.OperationId);
            Assert.Equal(new Guid("00aa00aa-bb11-cc22-dd33-44ee44ee44ee"), deserialized.ParentContext.OrganizationId);
            Assert.Equal("OneFarm", deserialized.ParentContext.OrganizationName);
            Assert.Equal(0, deserialized.ParentContext.OutputParameters.Count);
            Assert.Equal(new Guid("75417616-4ea2-e711-8122-000d3aa2331c"), deserialized.ParentContext.OwningExtension.Id);
            Assert.Equal("sdkmessageprocessingstep", deserialized.ParentContext.OwningExtension.LogicalName);
            Assert.Equal(0, deserialized.ParentContext.PostEntityImages.Count);
            Assert.Equal(0, deserialized.ParentContext.PreEntityImages.Count);
            Assert.Equal(new Guid("6d81597f-0f9f-e711-8122-000d3aa2331c"), deserialized.ParentContext.PrimaryEntityId);
            Assert.Equal("contact", deserialized.ParentContext.PrimaryEntityName);
            Assert.Null(deserialized.ParentContext.RequestId);
            Assert.Equal("none", deserialized.ParentContext.SecondaryEntityName);
            Assert.Equal(30, deserialized.ParentContext.Stage);
            Assert.Equal(new Guid("11bb11bb-cc22-dd33-ee44-55ff55ff55ff"), deserialized.ParentContext.UserId);
            Assert.Equal(1, deserialized.PostEntityImages.Count);
            //Assert PostEntityImages 
            var postEntityImage = deserialized.PostEntityImages["AsynchronousStepPrimaryName"] as Entity;
            Assert.NotNull(postEntityImage);
            Assert.Equal(2, postEntityImage.Attributes.Count);
            Assert.Equal("James Glynn (sample)", postEntityImage["fullname"]);
            Assert.Equal(new Guid("6d81597f-0f9f-e711-8122-000d3aa2331c"), postEntityImage.Id);
            Assert.Equal("contact", postEntityImage.LogicalName);
            Assert.Equal(0, deserialized.PreEntityImages.Count);
            Assert.Equal(new Guid("6d81597f-0f9f-e711-8122-000d3aa2331c"), deserialized.PrimaryEntityId);
            Assert.Equal("contact", deserialized.PrimaryEntityName);
            Assert.Null(deserialized.RequestId);
            Assert.Equal("none", deserialized.SecondaryEntityName);
            Assert.Equal(0, deserialized.SharedVariables.Count);
            Assert.Equal(40, deserialized.Stage);
            Assert.Equal(new Guid("11bb11bb-cc22-dd33-ee44-55ff55ff55ff"), deserialized.UserId);
        }
    }
}
