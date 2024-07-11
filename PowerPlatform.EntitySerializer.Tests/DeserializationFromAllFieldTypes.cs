using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EntitySerializerTests
{
    public class DeserializationFromAllFieldTypes
    {
        [Fact]
        public void DeserializeRemoteExecutionContextWithAllFieldTypes()
        {
            var serializedContext = @"{
  ""BusinessUnitId"": ""d5807889-0f5f-ee11-8def-000d3adbef1f"",
  ""CorrelationId"": ""b5940787-bdf1-4d42-89aa-671ba512a488"",
  ""Depth"": 1,
  ""InitiatingUserAgent"": """",
  ""InitiatingUserAzureActiveDirectoryObjectId"": ""3d280606-3712-4759-b6b9-7302f8d1a3b0"",
  ""InitiatingUserId"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
  ""InputParameters"": [
    {
      ""key"": ""Target"",
      ""value"": {
        ""__type"": ""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",
        ""Attributes"": [
          {
            ""key"": ""timezoneruleversionnumber"",
            ""value"": 0
          },
          {
            ""key"": ""shko_integer"",
            ""value"": 321
          },
          {
            ""key"": ""shko_currency"",
            ""value"": {
              ""__type"": ""Money:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 100
            }
          },
          {
            ""key"": ""modifiedonbehalfby"",
            ""value"": null
          },
          {
            ""key"": ""shko_datetime"",
            ""value"": ""/Date(1697526000000)/""
          },
          {
            ""key"": ""shko_decimal"",
            ""value"": 10.12
          },
          {
            ""key"": ""statecode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 0
            }
          },
          {
            ""key"": ""statuscode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""shko_boolean"",
            ""value"": false
          },
          {
            ""key"": ""owningbusinessunit"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""d5807889-0f5f-ee11-8def-000d3adbef1f"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""businessunit"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""shko_choice"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 342490000
            }
          },
          {
            ""key"": ""shko_string"",
            ""value"": ""This is a String""
          },
          {
            ""key"": ""shko_name"",
            ""value"": ""Betim Beja""
          },
          {
            ""key"": ""ownerid"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""shko_choices"",
            ""value"": [
              {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 342490001
              },
              {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 342490002
              }
            ]
          },
          {
            ""key"": ""modifiedon"",
            ""value"": ""/Date(1697398445000)/""
          },
          {
            ""key"": ""shko_allfieldsid"",
            ""value"": ""6420f0cc-916b-ee11-9ae6-000d3a688809""
          },
          {
            ""key"": ""modifiedby"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""shko_lookup"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""createdon"",
            ""value"": ""/Date(1697398445000)/""
          },
          {
            ""key"": ""createdby"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""transactioncurrencyid"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""4de444aa-375f-ee11-8def-000d3adbef1f"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""transactioncurrency"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""exchangerate"",
            ""value"": 1
          },
          {
            ""key"": ""shko_currency_base"",
            ""value"": {
              ""__type"": ""Money:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 100
            }
          }
        ],
        ""EntityState"": null,
        ""FormattedValues"": [
          {
            ""key"": ""timezoneruleversionnumber"",
            ""value"": ""0""
          },
          {
            ""key"": ""shko_integer"",
            ""value"": ""321""
          },
          {
            ""key"": ""shko_currency"",
            ""value"": ""â‚¬100.00""
          },
          {
            ""key"": ""shko_datetime"",
            ""value"": ""2023-10-17T09:00:00+02:00""
          },
          {
            ""key"": ""shko_decimal"",
            ""value"": ""10.12""
          },
          {
            ""key"": ""statecode"",
            ""value"": ""Active""
          },
          {
            ""key"": ""statuscode"",
            ""value"": ""Active""
          },
          {
            ""key"": ""shko_boolean"",
            ""value"": ""No""
          },
          {
            ""key"": ""shko_choice"",
            ""value"": ""Zero""
          },
          {
            ""key"": ""shko_choices"",
            ""value"": ""One; Two""
          },
          {
            ""key"": ""modifiedon"",
            ""value"": ""2023-10-15T21:34:05+02:00""
          },
          {
            ""key"": ""createdon"",
            ""value"": ""2023-10-15T21:34:05+02:00""
          }
        ],
        ""Id"": ""6420f0cc-916b-ee11-9ae6-000d3a688809"",
        ""KeyAttributes"": [],
        ""LogicalName"": ""shko_allfields"",
        ""RelatedEntities"": [],
        ""RowVersion"": null
      }
    }
  ],
  ""IsExecutingOffline"": false,
  ""IsInTransaction"": true,
  ""IsOfflinePlayback"": false,
  ""IsolationMode"": 1,
  ""MessageName"": ""Create"",
  ""Mode"": 0,
  ""OperationCreatedOn"": ""/Date(1697398446012)/"",
  ""OperationId"": ""1ecf6213-9296-4772-b37c-c09138dd0d59"",
  ""OrganizationId"": ""b015df52-a05f-ee11-a382-000d3a64db73"",
  ""OrganizationName"": ""unqb015df52a05fee11a382000d3a64d"",
  ""OutputParameters"": [
    {
      ""key"": ""id"",
      ""value"": ""6420f0cc-916b-ee11-9ae6-000d3a688809""
    }
  ],
  ""OwningExtension"": {
    ""Id"": ""bd7c6a7e-916b-ee11-9ae6-002248998a0a"",
    ""KeyAttributes"": [],
    ""LogicalName"": ""sdkmessageprocessingstep"",
    ""Name"": ""Share RemoteExecutionContext: Create of shko_allfields"",
    ""RowVersion"": null
  },
  ""ParentContext"": {
    ""BusinessUnitId"": ""d5807889-0f5f-ee11-8def-000d3adbef1f"",
    ""CorrelationId"": ""b5940787-bdf1-4d42-89aa-671ba512a488"",
    ""Depth"": 1,
    ""InitiatingUserAgent"": """",
    ""InitiatingUserAzureActiveDirectoryObjectId"": ""3d280606-3712-4759-b6b9-7302f8d1a3b0"",
    ""InitiatingUserId"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
    ""InputParameters"": [
      {
        ""key"": ""Target"",
        ""value"": {
          ""__type"": ""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",
          ""Attributes"": [
            {
              ""key"": ""shko_string"",
              ""value"": ""This is a String""
            },
            {
              ""key"": ""shko_integer"",
              ""value"": 321
            },
            {
              ""key"": ""shko_decimal"",
              ""value"": 10.12
            },
            {
              ""key"": ""shko_datetime"",
              ""value"": ""/Date(1697526000000)/""
            },
            {
              ""key"": ""shko_currency"",
              ""value"": {
                ""__type"": ""Money:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 100
              }
            },
            {
              ""key"": ""shko_choices"",
              ""value"": [
                {
                  ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                  ""Value"": 342490001
                },
                {
                  ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                  ""Value"": 342490002
                }
              ]
            },
            {
              ""key"": ""shko_choice"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 342490000
              }
            },
            {
              ""key"": ""shko_name"",
              ""value"": ""Betim Beja""
            },
            {
              ""key"": ""shko_boolean"",
              ""value"": false
            },
            {
              ""key"": ""statuscode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""transactioncurrencyid"",
              ""value"": {
                ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Id"": ""4de444aa-375f-ee11-8def-000d3adbef1f"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""transactioncurrency"",
                ""Name"": null,
                ""RowVersion"": null
              }
            },
            {
              ""key"": ""shko_lookup"",
              ""value"": {
                ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Id"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""systemuser"",
                ""Name"": null,
                ""RowVersion"": null
              }
            },
            {
              ""key"": ""ownerid"",
              ""value"": {
                ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Id"": ""c7877889-0f5f-ee11-8def-000d3adbef1f"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""systemuser"",
                ""Name"": null,
                ""RowVersion"": null
              }
            },
            {
              ""key"": ""shko_allfieldsid"",
              ""value"": ""6420f0cc-916b-ee11-9ae6-000d3a688809""
            }
          ],
          ""EntityState"": null,
          ""FormattedValues"": [],
          ""Id"": ""6420f0cc-916b-ee11-9ae6-000d3a688809"",
          ""KeyAttributes"": [],
          ""LogicalName"": ""shko_allfields"",
          ""RelatedEntities"": [],
          ""RowVersion"": null
        }
      },
      {
        ""key"": ""x-ms-app-name"",
        ""value"": ""shko_Quick""
      },
      {
        ""key"": ""SuppressDuplicateDetection"",
        ""value"": false
      }
    ],
    ""IsExecutingOffline"": false,
    ""IsInTransaction"": true,
    ""IsOfflinePlayback"": false,
    ""IsolationMode"": 1,
    ""MessageName"": ""Create"",
    ""Mode"": 0,
    ""OperationCreatedOn"": ""/Date(1697398445918)/"",
    ""OperationId"": ""1ecf6213-9296-4772-b37c-c09138dd0d59"",
    ""OrganizationId"": ""b015df52-a05f-ee11-a382-000d3a64db73"",
    ""OrganizationName"": ""unqb015df52a05fee11a382000d3a64d"",
    ""OutputParameters"": [],
    ""OwningExtension"": {
      ""Id"": ""1b0fbaa3-345f-ee11-8def-000d3adbef1f"",
      ""KeyAttributes"": [],
      ""LogicalName"": ""sdkmessageprocessingstep"",
      ""Name"": ""ObjectModel Implementation"",
      ""RowVersion"": null
    },
    ""ParentContext"": null,
    ""PostEntityImages"": [],
    ""PreEntityImages"": [],
    ""PrimaryEntityId"": ""6420f0cc-916b-ee11-9ae6-000d3a688809"",
    ""PrimaryEntityName"": ""shko_allfields"",
    ""RequestId"": ""1ecf6213-9296-4772-b37c-c09138dd0d59"",
    ""SecondaryEntityName"": ""none"",
    ""SharedVariables"": [
      {
        ""key"": ""IsAutoTransact"",
        ""value"": true
      },
      {
        ""key"": ""AcceptLang"",
        ""value"": ""en-US,en;q=0.9""
      },
      {
        ""key"": ""x-ms-app-name"",
        ""value"": ""shko_Quick""
      },
      {
        ""key"": ""DefaultsAddedFlag"",
        ""value"": true
      }
    ],
    ""Stage"": 30,
    ""UserAzureActiveDirectoryObjectId"": ""3d280606-3712-4759-b6b9-7302f8d1a3b0"",
    ""UserId"": ""c7877889-0f5f-ee11-8def-000d3adbef1f""
  },
  ""PostEntityImages"": [],
  ""PreEntityImages"": [],
  ""PrimaryEntityId"": ""6420f0cc-916b-ee11-9ae6-000d3a688809"",
  ""PrimaryEntityName"": ""shko_allfields"",
  ""RequestId"": ""1ecf6213-9296-4772-b37c-c09138dd0d59"",
  ""SecondaryEntityName"": ""none"",
  ""SharedVariables"": [
    {
      ""key"": ""IsAutoTransact"",
      ""value"": true
    },
    {
      ""key"": ""AcceptLang"",
      ""value"": ""en-US,en;q=0.9""
    },
    {
      ""key"": ""x-ms-app-name"",
      ""value"": ""shko_Quick""
    },
    {
      ""key"": ""DefaultsAddedFlag"",
      ""value"": true
    }
  ],
  ""Stage"": 40,
  ""UserAzureActiveDirectoryObjectId"": ""3d280606-3712-4759-b6b9-7302f8d1a3b0"",
  ""UserId"": ""c7877889-0f5f-ee11-8def-000d3adbef1f""
}";
            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(serializedContext);
            var target = remoteExecutionContext.InputParameters["Target"] as Entity;
            Assert.NotNull(remoteExecutionContext);
            Assert.Equal(40, remoteExecutionContext.Stage);
            Assert.Equal("Create", remoteExecutionContext.MessageName);
            Assert.Equal(321, target.GetAttributeValue<int>("shko_integer"));
            Assert.Equal(321, target.GetAttributeValue<int?>("shko_integer"));
            var shko_currency = target.GetAttributeValue<Money>("shko_currency");
            Assert.NotNull(shko_currency);
            Assert.Equal(100,shko_currency.Value);
            Assert.Equal(new DateTime(2023, 10, 17, 07, 00, 00, DateTimeKind.Utc), target.GetAttributeValue<DateTime>("shko_datetime"));
            Assert.Equal(10.12m, target.GetAttributeValue<decimal>("shko_decimal"));
            Assert.False(target.GetAttributeValue<bool>("shko_bool"));
            var shko_choice = target.GetAttributeValue<OptionSetValue>("shko_choice");
            Assert.NotNull(shko_choice);
            Assert.Equal(342490000, shko_choice.Value);
            Assert.Equal("This is a String", target.GetAttributeValue<string>("shko_string"));
            Assert.Equal("Betim Beja", target.GetAttributeValue<string>("shko_name"));
            var shko_choices = target.GetAttributeValue<OptionSetValueCollection>("shko_choices");
            Assert.NotNull(shko_choices);
            Assert.Contains(new OptionSetValue(342490002), shko_choices);
        }
    }
}
