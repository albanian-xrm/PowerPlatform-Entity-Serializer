using Microsoft.Xrm.Sdk;
using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Xunit;

namespace AlbanianXrm.PowerPlatform
{
    public class DeserializationEncodingTests
    {
        string input = @"
{
  ""BusinessUnitId"": ""0669e963-e69c-ef11-8a6b-000d3a318589"",
  ""CorrelationId"": ""7038a274-4877-4f3f-a57a-0f4493a647c6"",
  ""Depth"": 1,
  ""InitiatingUserAgent"": """",
  ""InitiatingUserAzureActiveDirectoryObjectId"": ""30965b76-43d8-4300-a48f-dda5e92106ee"",
  ""InitiatingUserId"": ""3570e963-e69c-ef11-8a6b-000d3a318589"",
  ""InputParameters"": [
    {
      ""key"": ""Target"",
      ""value"": {
        ""__type"": ""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",
        ""Attributes"": [
          {
            ""key"": ""territorycode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""statecode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 0
            }
          },
          {
            ""key"": ""address2_shippingmethodcode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""isprivate"",
            ""value"": false
          },
          {
            ""key"": ""followemail"",
            ""value"": true
          },
          {
            ""key"": ""donotbulkemail"",
            ""value"": false
          },
          {
            ""key"": ""donotsendmm"",
            ""value"": false
          },
          {
            ""key"": ""createdon"",
            ""value"": ""/Date(1731053106000)/""
          },
          {
            ""key"": ""businesstypecode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""donotpostalmail"",
            ""value"": false
          },
          {
            ""key"": ""ownerid"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""3570e963-e69c-ef11-8a6b-000d3a318589"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""donotbulkpostalmail"",
            ""value"": false
          },
          {
            ""key"": ""name"",
            ""value"": ""ÐÐ°Ð‘Ð±Ð’Ð²Ð“Ð³Ð”Ð´Ð•ÐµÃ‹Ã«Ð–Ð¶Ð—Ð·Ð˜Ð¸Ð™Ð¹ÐšÐºÐ›Ð»ÐœÐ¼ÐÐ½ÐžÐ¾ÐŸÐ¿Ð Ñ€Ð¡ÑÐ¢Ñ‚Ð£ÑƒÐ¤Ñ„Ð¥Ñ…Ð¦Ñ†Ð§Ñ‡Ð¨ÑˆÐ©Ñ‰ÐªÑŠÐ«Ñ‹Ð¬ÑŒÐ­ÑÐ®ÑŽÐ¯ÑÐ Ð Ð ""
          },
          {
            ""key"": ""new_name"",
            ""value"": ""Ä¢ÄrÅ«mÅ¾Ä«mÄ“Å¡ÄÅ«Ä¼ÅÅ¡Ä¶KÄ¢Ä»ÄŒÅ†""
          },
          {
            ""key"": ""donotemail"",
            ""value"": false
          },
          {
            ""key"": ""address2_addresstypecode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""donotphone"",
            ""value"": false
          },
          {
            ""key"": ""transactioncurrencyid"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""889d2542-159d-ef11-8a6b-000d3a318589"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""transactioncurrency"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""modifiedby"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""3570e963-e69c-ef11-8a6b-000d3a318589"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
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
            ""key"": ""modifiedonbehalfby"",
            ""value"": null
          },
          {
            ""key"": ""preferredcontactmethodcode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""owningbusinessunit"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""0669e963-e69c-ef11-8a6b-000d3a318589"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""businessunit"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""accountid"",
            ""value"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1""
          },
          {
            ""key"": ""createdby"",
            ""value"": {
              ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Id"": ""3570e963-e69c-ef11-8a6b-000d3a318589"",
              ""KeyAttributes"": [],
              ""LogicalName"": ""systemuser"",
              ""Name"": null,
              ""RowVersion"": null
            }
          },
          {
            ""key"": ""donotfax"",
            ""value"": false
          },
          {
            ""key"": ""merged"",
            ""value"": false
          },
          {
            ""key"": ""customersizecode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""marketingonly"",
            ""value"": false
          },
          {
            ""key"": ""accountratingcode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""shippingmethodcode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""processid"",
            ""value"": ""00000000-0000-0000-0000-000000000000""
          },
          {
            ""key"": ""creditonhold"",
            ""value"": false
          },
          {
            ""key"": ""modifiedon"",
            ""value"": ""/Date(1731053106000)/""
          },
          {
            ""key"": ""participatesinworkflow"",
            ""value"": false
          },
          {
            ""key"": ""accountclassificationcode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""address2_freighttermscode"",
            ""value"": {
              ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
              ""Value"": 1
            }
          },
          {
            ""key"": ""exchangerate"",
            ""value"": 1
          }
        ],
        ""EntityState"": null,
        ""FormattedValues"": [
          {
            ""key"": ""territorycode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""statecode"",
            ""value"": ""Active""
          },
          {
            ""key"": ""address2_shippingmethodcode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""isprivate"",
            ""value"": ""No""
          },
          {
            ""key"": ""followemail"",
            ""value"": ""Allow""
          },
          {
            ""key"": ""donotbulkemail"",
            ""value"": ""Allow""
          },
          {
            ""key"": ""donotsendmm"",
            ""value"": ""Send""
          },
          {
            ""key"": ""createdon"",
            ""value"": ""2024-11-08T08:05:06-00:00""
          },
          {
            ""key"": ""businesstypecode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""donotpostalmail"",
            ""value"": ""Allow""
          },
          {
            ""key"": ""donotbulkpostalmail"",
            ""value"": ""No""
          },
          {
            ""key"": ""donotemail"",
            ""value"": ""Allow""
          },
          {
            ""key"": ""address2_addresstypecode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""donotphone"",
            ""value"": ""Allow""
          },
          {
            ""key"": ""statuscode"",
            ""value"": ""Active""
          },
          {
            ""key"": ""preferredcontactmethodcode"",
            ""value"": ""Any""
          },
          {
            ""key"": ""donotfax"",
            ""value"": ""Allow""
          },
          {
            ""key"": ""merged"",
            ""value"": ""No""
          },
          {
            ""key"": ""customersizecode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""marketingonly"",
            ""value"": ""No""
          },
          {
            ""key"": ""accountratingcode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""shippingmethodcode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""creditonhold"",
            ""value"": ""No""
          },
          {
            ""key"": ""modifiedon"",
            ""value"": ""2024-11-08T08:05:06-00:00""
          },
          {
            ""key"": ""participatesinworkflow"",
            ""value"": ""No""
          },
          {
            ""key"": ""accountclassificationcode"",
            ""value"": ""Default Value""
          },
          {
            ""key"": ""address2_freighttermscode"",
            ""value"": ""Default Value""
          }
        ],
        ""Id"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1"",
        ""KeyAttributes"": [],
        ""LogicalName"": ""account"",
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
  ""OperationCreatedOn"": ""/Date(1731053106922)/"",
  ""OperationId"": ""f8a13ba5-d91d-4dd5-936c-7f3b6d6adb95"",
  ""OrganizationId"": ""f42a590d-a29d-ef11-8a66-6045bd056902"",
  ""OrganizationName"": ""unqf42a590da29def118a666045bd056"",
  ""OutputParameters"": [
    {
      ""key"": ""id"",
      ""value"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1""
    }
  ],
  ""OwningExtension"": {
    ""Id"": ""a89a1ed8-a79d-ef11-8a69-000d3a30b0c1"",
    ""KeyAttributes"": [],
    ""LogicalName"": ""sdkmessageprocessingstep"",
    ""Name"": ""webhook.site test: Create of account"",
    ""RowVersion"": null
  },
  ""ParentContext"": {
    ""BusinessUnitId"": ""0669e963-e69c-ef11-8a6b-000d3a318589"",
    ""CorrelationId"": ""7038a274-4877-4f3f-a57a-0f4493a647c6"",
    ""Depth"": 1,
    ""InitiatingUserAgent"": """",
    ""InitiatingUserAzureActiveDirectoryObjectId"": ""30965b76-43d8-4300-a48f-dda5e92106ee"",
    ""InitiatingUserId"": ""3570e963-e69c-ef11-8a6b-000d3a318589"",
    ""InputParameters"": [
      {
        ""key"": ""Target"",
        ""value"": {
          ""__type"": ""Entity:http://schemas.microsoft.com/xrm/2011/Contracts"",
          ""Attributes"": [
          {
            ""key"": ""name"",
            ""value"": ""ÐÐ°Ð‘Ð±Ð’Ð²Ð“Ð³Ð”Ð´Ð•ÐµÃ‹Ã«Ð–Ð¶Ð—Ð·Ð˜Ð¸Ð™Ð¹ÐšÐºÐ›Ð»ÐœÐ¼ÐÐ½ÐžÐ¾ÐŸÐ¿Ð Ñ€Ð¡ÑÐ¢Ñ‚Ð£ÑƒÐ¤Ñ„Ð¥Ñ…Ð¦Ñ†Ð§Ñ‡Ð¨ÑˆÐ©Ñ‰ÐªÑŠÐ«Ñ‹Ð¬ÑŒÐ­ÑÐ®ÑŽÐ¯ÑÐ Ð Ð ""
          },
          {
            ""key"": ""new_name"",
            ""value"": ""Ä¢ÄrÅ«mÅ¾Ä«mÄ“Å¡ÄÅ«Ä¼ÅÅ¡Ä¶KÄ¢Ä»ÄŒÅ†""
          },
            {
              ""key"": ""creditonhold"",
              ""value"": false
            },
            {
              ""key"": ""donotpostalmail"",
              ""value"": false
            },
            {
              ""key"": ""donotfax"",
              ""value"": false
            },
            {
              ""key"": ""donotphone"",
              ""value"": false
            },
            {
              ""key"": ""donotbulkemail"",
              ""value"": false
            },
            {
              ""key"": ""followemail"",
              ""value"": true
            },
            {
              ""key"": ""donotemail"",
              ""value"": false
            },
            {
              ""key"": ""preferredcontactmethodcode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
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
              ""key"": ""donotsendmm"",
              ""value"": false
            },
            {
              ""key"": ""processid"",
              ""value"": ""00000000-0000-0000-0000-000000000000""
            },
            {
              ""key"": ""transactioncurrencyid"",
              ""value"": {
                ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Id"": ""889d2542-159d-ef11-8a6b-000d3a318589"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""transactioncurrency"",
                ""Name"": null,
                ""RowVersion"": null
              }
            },
            {
              ""key"": ""ownerid"",
              ""value"": {
                ""__type"": ""EntityReference:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Id"": ""3570e963-e69c-ef11-8a6b-000d3a318589"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""systemuser"",
                ""Name"": null,
                ""RowVersion"": null
              }
            },
            {
              ""key"": ""donotbulkpostalmail"",
              ""value"": false
            },
            {
              ""key"": ""accountratingcode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""accountclassificationcode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""isprivate"",
              ""value"": false
            },
            {
              ""key"": ""territorycode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""businesstypecode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""shippingmethodcode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""marketingonly"",
              ""value"": false
            },
            {
              ""key"": ""merged"",
              ""value"": false
            },
            {
              ""key"": ""address2_addresstypecode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""customersizecode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""participatesinworkflow"",
              ""value"": false
            },
            {
              ""key"": ""address2_shippingmethodcode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""address2_freighttermscode"",
              ""value"": {
                ""__type"": ""OptionSetValue:http://schemas.microsoft.com/xrm/2011/Contracts"",
                ""Value"": 1
              }
            },
            {
              ""key"": ""accountid"",
              ""value"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1""
            }
          ],
          ""EntityState"": null,
          ""FormattedValues"": [],
          ""Id"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1"",
          ""KeyAttributes"": [],
          ""LogicalName"": ""account"",
          ""RelatedEntities"": [],
          ""RowVersion"": null
        }
      },
      {
        ""key"": ""x-ms-app-name"",
        ""value"": ""new_Account""
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
    ""OperationCreatedOn"": ""/Date(1731053106906)/"",
    ""OperationId"": ""f8a13ba5-d91d-4dd5-936c-7f3b6d6adb95"",
    ""OrganizationId"": ""f42a590d-a29d-ef11-8a66-6045bd056902"",
    ""OrganizationName"": ""unqf42a590da29def118a666045bd056"",
    ""OutputParameters"": [],
    ""OwningExtension"": {
      ""Id"": ""ffc9bb1b-ea3e-db11-86a7-000a3a5473e8"",
      ""KeyAttributes"": [],
      ""LogicalName"": ""sdkmessageprocessingstep"",
      ""Name"": ""ObjectModel Implementation"",
      ""RowVersion"": null
    },
    ""ParentContext"": null,
    ""PostEntityImages"": [],
    ""PreEntityImages"": [],
    ""PrimaryEntityId"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1"",
    ""PrimaryEntityName"": ""account"",
    ""RequestId"": ""f8a13ba5-d91d-4dd5-936c-7f3b6d6adb95"",
    ""SecondaryEntityName"": ""none"",
    ""SharedVariables"": [
      {
        ""key"": ""IsAutoTransact"",
        ""value"": true
      },
      {
        ""key"": ""AcceptLang"",
        ""value"": ""en-US,en;q=0.9,lv;q=0.8""
      },
      {
        ""key"": ""x-ms-app-name"",
        ""value"": ""new_Account""
      },
      {
        ""key"": ""DefaultsAddedFlag"",
        ""value"": true
      },
      {
        ""key"": ""ChangedEntityTypes"",
        ""value"": [
          {
            ""__type"": ""KeyValuePairOfstringstring:#System.Collections.Generic"",
            ""key"": ""account"",
            ""value"": ""Update""
          }
        ]
      }
    ],
    ""Stage"": 30,
    ""UserAzureActiveDirectoryObjectId"": ""30965b76-43d8-4300-a48f-dda5e92106ee"",
    ""UserId"": ""3570e963-e69c-ef11-8a6b-000d3a318589""
  },
  ""PostEntityImages"": [],
  ""PreEntityImages"": [],
  ""PrimaryEntityId"": ""53c52f26-a89d-ef11-8a69-000d3a30b0c1"",
  ""PrimaryEntityName"": ""account"",
  ""RequestId"": ""f8a13ba5-d91d-4dd5-936c-7f3b6d6adb95"",
  ""SecondaryEntityName"": ""none"",
  ""SharedVariables"": [
    {
      ""key"": ""IsAutoTransact"",
      ""value"": true
    },
    {
      ""key"": ""AcceptLang"",
      ""value"": ""en-US,en;q=0.9,lv;q=0.8""
    },
    {
      ""key"": ""x-ms-app-name"",
      ""value"": ""new_Account""
    },
    {
      ""key"": ""DefaultsAddedFlag"",
      ""value"": true
    }
  ],
  ""Stage"": 40,
  ""UserAzureActiveDirectoryObjectId"": ""30965b76-43d8-4300-a48f-dda5e92106ee"",
  ""UserId"": ""3570e963-e69c-ef11-8a6b-000d3a318589""
}
";


        [Fact]
        public void HandleEncoding()
        {

#if NETCOREAPP
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            
            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(input);

            //This would fix it, but somehow library should handle it:

            //var encoding = Encoding.GetEncoding(1252);
            //var inputFixedEncoding = Encoding.UTF8.GetString(encoding.GetBytes(input));
            //var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(inputFixedEncoding);

            Assert.NotNull(remoteExecutionContext);
            Assert.NotNull(remoteExecutionContext.InputParameters);
            Assert.True(remoteExecutionContext.InputParameters.ContainsKey("Target"));

            var target = remoteExecutionContext.InputParameters["Target"] as Entity;
            Assert.NotNull(target);

            Assert.Equal("АаБбВвГгДдЕеËëЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯяРРР", target.GetAttributeValue<string>("name"));

            Assert.Equal("ĢārūmžīmēščūļōšĶKĢĻČņ", target.GetAttributeValue<string>("new_name"));
        }

        [Fact]
        public async Task HandleEncodingAsync()
        {

#if NETCOREAPP
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            {
                var remoteExecutionContext = await EntitySerializer.DeserializeAsync<RemoteExecutionContext>(stream);

                Assert.NotNull(remoteExecutionContext);
                Assert.NotNull(remoteExecutionContext.InputParameters);
                Assert.True(remoteExecutionContext.InputParameters.ContainsKey("Target"));

                var target = remoteExecutionContext.InputParameters["Target"] as Entity;
                Assert.NotNull(target);

                Assert.Equal("АаБбВвГгДдЕеËëЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯяРРР", target.GetAttributeValue<string>("name"));

                Assert.Equal("ĢārūmžīmēščūļōšĶKĢĻČņ", target.GetAttributeValue<string>("new_name"));
            }
        }
    }
}
