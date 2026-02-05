using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using System;
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
  ""Unknown"": null,
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
              ""key"": ""requiredattendees"",
              ""value"": [
                {
                  ""__type"": ""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",
                  ""Attributes"": [
                    {
                      ""key"": ""partyid"",
                      ""value"": {
                        ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
                        ""Id"": ""f0459662-7d02-f111-8407-7ced8d48fc4e"",
                        ""KeyAttributes"": [],
                        ""LogicalName"": ""contact"",
                        ""Name"": null,
                        ""RowVersion"": null
                    }
                 }
               ],
               ""EntityState"": null,
               ""FormattedValues"": [],
               ""Id"": ""00000000-0000-0000-0000-000000000000"",
               ""KeyAttributes"": [],
               ""LogicalName"": ""activityparty"",
               ""RelatedEntities"": [],
               ""RowVersion"": null
               }
             ]
            },
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
            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(serializedContext, new EntitySerializerOptions()
            {
                Strictness = Strictness.Loose,
                KnownAttributeTypes = { { "requiredattendees", typeof(EntityCollection) } }
            });
            var target = remoteExecutionContext.InputParameters["Target"] as Entity;
            Assert.NotNull(remoteExecutionContext);
            Assert.Equal(40, remoteExecutionContext.Stage);
            Assert.Equal("Create", remoteExecutionContext.MessageName);
            Assert.Equal(321, target.GetAttributeValue<int>("shko_integer"));
            Assert.Equal(321, target.GetAttributeValue<int?>("shko_integer"));
            var shko_currency = target.GetAttributeValue<Money>("shko_currency");
            Assert.NotNull(shko_currency);
            Assert.Equal(100, shko_currency.Value);
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

        [Fact]
        public void DeserializeRemoteExecutionContextWithDocumentLocation()
        {
            var serializedContext = @"
{
    ""BusinessUnitId"": ""24e33957-e1a1-424e-943d-e8ce84c45633"",
    ""CorrelationId"": ""01b84871-96b1-48e0-ada2-a31031966e3f"",
    ""Depth"": 1,
    ""InitiatingUserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
    ""InitiatingUserId"": ""30c91177-9436-4042-ad53-dd966d490114"",
    ""InputParameters"": [
        {
            ""key"": ""Target"",
            ""value"": {
                ""__type"": ""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                ""Attributes"": [
                    {
                        ""key"": ""owningbusinessunit"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""24e33957-e1a1-424e-943d-e8ce84c45633"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""businessunit"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""modifiedonbehalfby"",
                        ""value"": null
                    },
                    {
                        ""key"": ""statecode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 0
                        }
                    },
                    {
                        ""key"": ""locationtype"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 0
                        }
                    },
                    {
                        ""key"": ""relativeurl"",
                        ""value"": ""Mini test""
                    },
                    {
                        ""key"": ""createdby"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""30c91177-9436-4042-ad53-dd966d490114"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""systemuser"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""regardingobjectid"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""0a3839b3-08d4-ef11-aeb0-00155d000101"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""account"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""statuscode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 1
                        }
                    },
                    {
                        ""key"": ""ownerid"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""30c91177-9436-4042-ad53-dd966d490114"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""systemuser"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""sharepointdocumentlocationid"",
                        ""value"": ""1e3839b3-08d4-ef11-aeb0-00155d000101""
                    },
                    {
                        ""key"": ""modifiedon"",
                        ""value"": ""\/Date(1737031936000)\/""
                    },
                    {
                        ""key"": ""owninguser"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""30c91177-9436-4042-ad53-dd966d490114"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""systemuser"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""modifiedby"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""30c91177-9436-4042-ad53-dd966d490114"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""systemuser"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""sitecollectionid"",
                        ""value"": ""b40f92c3-c1cc-ef11-aeae-00155d000101""
                    },
                    {
                        ""key"": ""createdon"",
                        ""value"": ""\/Date(1737031936000)\/""
                    },
                    {
                        ""key"": ""name"",
                        ""value"": ""Documents on Default Site 1""
                    },
                    {
                        ""key"": ""parentsiteorlocation"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""90fe6740-1cc1-e211-be17-000c29fb9e40"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""sharepointdocumentlocation"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""servicetype"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 0
                        }
                    }
                ],
                ""EntityState"": null,
                ""FormattedValues"": [
                    {
                        ""key"": ""statecode"",
                        ""value"": ""Active""
                    },
                    {
                        ""key"": ""locationtype"",
                        ""value"": ""General""
                    },
                    {
                        ""key"": ""statuscode"",
                        ""value"": ""Active""
                    },
                    {
                        ""key"": ""modifiedon"",
                        ""value"": ""2025-01-16T14:52:16+02:00""
                    },
                    {
                        ""key"": ""createdon"",
                        ""value"": ""2025-01-16T14:52:16+02:00""
                    }
                ],
                ""Id"": ""1e3839b3-08d4-ef11-aeb0-00155d000101"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""sharepointdocumentlocation"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        }
    ],
    ""IsExecutingOffline"": false,
    ""IsInTransaction"": false,
    ""IsOfflinePlayback"": false,
    ""IsolationMode"": 1,
    ""MessageName"": ""Create"",
    ""Mode"": 1,
    ""OperationCreatedOn"": ""\/Date(1737024736000+0200)\/"",
    ""OperationId"": ""203839b3-08d4-ef11-aeb0-00155d000101"",
    ""OrganizationId"": ""f0aabb07-b0c9-4cfe-80be-8effd49bf067"",
    ""OrganizationName"": ""ORG"",
    ""OutputParameters"": [
        {
            ""key"": ""id"",
            ""value"": ""1e3839b3-08d4-ef11-aeb0-00155d000101""
        }
    ],
    ""OwningExtension"": {
        ""Id"": ""ffd3ea1c-46ae-ef11-8a69-002248e53d94"",
        ""KeyAttributes"": [],
        ""LogicalName"": ""sdkmessageprocessingstep"",
        ""Name"": null,
        ""RowVersion"": null
    },
    ""ParentContext"": {
        ""BusinessUnitId"": ""24e33957-e1a1-424e-943d-e8ce84c45633"",
        ""CorrelationId"": ""01b84871-96b1-48e0-ada2-a31031966e3f"",
        ""Depth"": 1,
        ""InitiatingUserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
        ""InitiatingUserId"": ""30c91177-9436-4042-ad53-dd966d490114"",
        ""InputParameters"": [
            {
                ""key"": ""Query"",
                ""value"": {
                    ""__type"": ""QueryExpression:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                    ""ColumnSet"": {
                        ""AllColumns"": false,
                        ""AttributeExpressions"": [],
                        ""Columns"": [
                            ""documentid"",
                            ""fullname"",
                            ""relativelocation"",
                            ""sharepointcreatedon"",
                            ""ischeckedout"",
                            ""filetype"",
                            ""modified"",
                            ""sharepointmodifiedby"",
                            ""servicetype"",
                            ""absoluteurl"",
                            ""title"",
                            ""author"",
                            ""sharepointdocumentid"",
                            ""readurl"",
                            ""editurl"",
                            ""locationid"",
                            ""iconclassname"",
                            ""locationname""
                        ]
                    },
                    ""Criteria"": {
                        ""Conditions"": [
                            {
                                ""AttributeName"": ""isrecursivefetch"",
                                ""CompareColumns"": false,
                                ""Operator"": 0,
                                ""Values"": [
                                    false
                                ],
                                ""EntityName"": null
                            },
                            {
                                ""AttributeName"": ""regardingobjecttypecode"",
                                ""CompareColumns"": false,
                                ""Operator"": 0,
                                ""Values"": [
                                    1
                                ],
                                ""EntityName"": null
                            },
                            {
                                ""AttributeName"": ""regardingobjectid"",
                                ""CompareColumns"": false,
                                ""Operator"": 0,
                                ""Values"": [
                                    ""0a3839b3-08d4-ef11-aeb0-00155d000101""
                                ],
                                ""EntityName"": null
                            }
                        ],
                        ""FilterOperator"": 0,
                        ""Filters"": []
                    },
                    ""Distinct"": false,
                    ""EntityName"": ""sharepointdocument"",
                    ""LinkEntities"": [],
                    ""Orders"": [
                        {
                            ""Alias"": null,
                            ""AttributeName"": ""relativelocation"",
                            ""OrderType"": 0
                        }
                    ],
                    ""PageInfo"": {
                        ""Count"": 10,
                        ""PageNumber"": 1,
                        ""PagingCookie"": null,
                        ""ReturnTotalRecordCount"": true
                    },
                    ""NoLock"": false,
                    ""QueryHints"": """"
                }
            },
            {
                ""key"": ""IsAppModuleContext"",
                ""value"": false
            },
            {
                ""key"": ""AppModuleId"",
                ""value"": ""00000000-0000-0000-0000-000000000000""
            }
        ],
        ""IsExecutingOffline"": false,
        ""IsInTransaction"": false,
        ""IsOfflinePlayback"": false,
        ""IsolationMode"": 1,
        ""MessageName"": ""Create"",
        ""Mode"": 1,
        ""OperationCreatedOn"": ""\/Date(1737024736000+0200)\/"",
        ""OperationId"": ""203839b3-08d4-ef11-aeb0-00155d000101"",
        ""OrganizationId"": ""f0aabb07-b0c9-4cfe-80be-8effd49bf067"",
        ""OrganizationName"": ""ORG"",
        ""OutputParameters"": [],
        ""OwningExtension"": {
            ""Id"": ""ffd3ea1c-46ae-ef11-8a69-002248e53d94"",
            ""KeyAttributes"": [],
            ""LogicalName"": ""sdkmessageprocessingstep"",
            ""Name"": null,
            ""RowVersion"": null
        },
        ""ParentContext"": null,
        ""PostEntityImages"": [],
        ""PreEntityImages"": [],
        ""PrimaryEntityId"": ""1e3839b3-08d4-ef11-aeb0-00155d000101"",
        ""PrimaryEntityName"": ""sharepointdocument"",
        ""RequestId"": ""e28dd17d-f8ee-4830-849d-8f9441ecac76"",
        ""SecondaryEntityName"": ""none"",
        ""SharedVariables"": [
            {
                ""key"": ""IsAutoTransact"",
                ""value"": false
            }
        ],
        ""Stage"": 30,
        ""UserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
        ""UserId"": ""30c91177-9436-4042-ad53-dd966d490114""
    },
    ""PostEntityImages"": [
        {
            ""key"": ""PostImage"",
            ""value"": {
                ""Attributes"": [
                    {
                        ""key"": ""name"",
                        ""value"": ""Documents on Default Site 1""
                    },
                    {
                        ""key"": ""ownerid"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""30c91177-9436-4042-ad53-dd966d490114"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""systemuser"",
                            ""Name"": ""Name"",
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""parentsiteorlocation"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""90fe6740-1cc1-e211-be17-000c29fb9e40"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""sharepointdocumentlocation"",
                            ""Name"": ""account"",
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""regardingobjectid"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""0a3839b3-08d4-ef11-aeb0-00155d000101"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""account"",
                            ""Name"": ""Mini test"",
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""relativeurl"",
                        ""value"": ""Mini test""
                    },
                    {
                        ""key"": ""sharepointdocumentlocationid"",
                        ""value"": ""1e3839b3-08d4-ef11-aeb0-00155d000101""
                    },
                    {
                        ""key"": ""statecode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 0
                        }
                    },
                    {
                        ""key"": ""statuscode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 1
                        }
                    }
                ],
                ""EntityState"": null,
                ""FormattedValues"": [
                    {
                        ""key"": ""ownerid"",
                        ""value"": ""Name""
                    },
                    {
                        ""key"": ""parentsiteorlocation"",
                        ""value"": ""account""
                    },
                    {
                        ""key"": ""regardingobjectid"",
                        ""value"": ""Mini test""
                    },
                    {
                        ""key"": ""statecode"",
                        ""value"": ""Active""
                    },
                    {
                        ""key"": ""statuscode"",
                        ""value"": ""Active""
                    }
                ],
                ""Id"": ""1e3839b3-08d4-ef11-aeb0-00155d000101"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""sharepointdocumentlocation"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        },
        {
            ""key"": ""AsynchronousStepPrimaryName"",
            ""value"": {
                ""Attributes"": [
                    {
                        ""key"": ""name"",
                        ""value"": ""Documents on Default Site 1""
                    },
                    {
                        ""key"": ""sharepointdocumentlocationid"",
                        ""value"": ""1e3839b3-08d4-ef11-aeb0-00155d000101""
                    }
                ],
                ""EntityState"": null,
                ""FormattedValues"": [],
                ""Id"": ""1e3839b3-08d4-ef11-aeb0-00155d000101"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""sharepointdocumentlocation"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        }
    ],
    ""PreEntityImages"": [],
    ""PrimaryEntityId"": ""1e3839b3-08d4-ef11-aeb0-00155d000101"",
    ""PrimaryEntityName"": ""sharepointdocumentlocation"",
    ""RequestId"": ""e28dd17d-f8ee-4830-849d-8f9441ecac76"",
    ""SecondaryEntityName"": ""none"",
    ""SharedVariables"": [
        {
            ""key"": ""IsAutoTransact"",
            ""value"": true
        },
        {
            ""key"": ""DefaultsAddedFlag"",
            ""value"": true
        }
    ],
    ""Stage"": 40,
    ""UserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
    ""UserId"": ""30c91177-9436-4042-ad53-dd966d490114""
}
";
            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(serializedContext);
        }
    }
}
