using Microsoft.Xrm.Sdk;
using System;
using Xunit;

namespace AlbanianXrm.PowerPlatform
{
    public class DeserializationFromActivityEntities
    {
        [Fact]
        public void DeserializeActivityParty()
        {
            var input = @"{
    ""BusinessUnitId"": ""8cb66f44-8d23-e311-a2cb-0050569c0f02"",
    ""CorrelationId"": ""3860c444-0576-4d79-9877-b0ca8e4e9bd4"",
    ""Depth"": 1,
    ""InitiatingUserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
    ""InitiatingUserId"": ""400075a6-19a2-49aa-8fa0-330ba2810540"",
    ""InputParameters"": [
        {
            ""key"": ""Target"",
            ""value"": {
                ""__type"": ""Entity:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                ""Attributes"": [
                    {
                        ""key"": ""activityid"",
                        ""value"": ""841579d9-7e63-ef11-9e4a-00155d0001ea""
                    },
                    {
                        ""key"": ""statecode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 3
                        }
                    },
                    {
                        ""key"": ""statuscode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 4
                        }
                    },
                    {
                        ""key"": ""modifiedon"",
                        ""value"": ""\/Date(1724658196000)\/""
                    },
                    {
                        ""key"": ""modifiedby"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""400075a6-19a2-49aa-8fa0-330ba2810540"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""systemuser"",
                            ""Name"": null,
                            ""RowVersion"": null
                        }
                    },
                    {
                        ""key"": ""modifiedonbehalfby"",
                        ""value"": null
                    }
                ],
                ""EntityState"": null,
                ""FormattedValues"": [],
                ""Id"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""new_customactivity"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        },
        {
            ""key"": ""parentExecutionId"",
            ""value"": ""1ede9b8e-fdad-4116-9706-d21cd5e30eea""
        }
    ],
    ""IsExecutingOffline"": false,
    ""IsInTransaction"": false,
    ""IsOfflinePlayback"": false,
    ""IsolationMode"": 1,
    ""MessageName"": ""Update"",
    ""Mode"": 1,
    ""OperationCreatedOn"": ""\/Date(1724647396000+0300)\/"",
    ""OperationId"": ""b51579d9-7e63-ef11-9e4a-00155d0001ea"",
    ""OrganizationId"": ""e4032af2-cacf-4dd0-92aa-9036176934a5"",
    ""OrganizationName"": ""Organization"",
    ""OutputParameters"": [],
    ""OwningExtension"": {
        ""Id"": ""66f73381-973e-ef11-9e49-00155d0001ea"",
        ""KeyAttributes"": [],
        ""LogicalName"": ""sdkmessageprocessingstep"",
        ""Name"": null,
        ""RowVersion"": null
    },
    ""ParentContext"": {
        ""BusinessUnitId"": ""8cb66f44-8d23-e311-a2cb-0050569c0f02"",
        ""CorrelationId"": ""3860c444-0576-4d79-9877-b0ca8e4e9bd4"",
        ""Depth"": 1,
        ""InitiatingUserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
        ""InitiatingUserId"": ""400075a6-19a2-49aa-8fa0-330ba2810540"",
        ""InputParameters"": [
            {
                ""key"": ""EntityMoniker"",
                ""value"": {
                    ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                    ""Id"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
                    ""KeyAttributes"": [],
                    ""LogicalName"": ""new_customactivity"",
                    ""Name"": null,
                    ""RowVersion"": null
                }
            },
            {
                ""key"": ""State"",
                ""value"": {
                    ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                    ""Value"": 3
                }
            },
            {
                ""key"": ""Status"",
                ""value"": {
                    ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                    ""Value"": 4
                }
            }
        ],
        ""IsExecutingOffline"": false,
        ""IsInTransaction"": false,
        ""IsOfflinePlayback"": false,
        ""IsolationMode"": 1,
        ""MessageName"": ""Update"",
        ""Mode"": 1,
        ""OperationCreatedOn"": ""\/Date(1724647396000+0300)\/"",
        ""OperationId"": ""b51579d9-7e63-ef11-9e4a-00155d0001ea"",
        ""OrganizationId"": ""e4032af2-cacf-4dd0-92aa-9036176934a5"",
        ""OrganizationName"": ""Organization"",
        ""OutputParameters"": [],
        ""OwningExtension"": {
            ""Id"": ""66f73381-973e-ef11-9e49-00155d0001ea"",
            ""KeyAttributes"": [],
            ""LogicalName"": ""sdkmessageprocessingstep"",
            ""Name"": null,
            ""RowVersion"": null
        },
        ""ParentContext"": null,
        ""PostEntityImages"": [],
        ""PreEntityImages"": [],
        ""PrimaryEntityId"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
        ""PrimaryEntityName"": ""new_customactivity"",
        ""RequestId"": ""3123f7a7-784a-4523-809a-11d47f16313a"",
        ""SecondaryEntityName"": ""none"",
        ""SharedVariables"": [
            {
                ""key"": ""IsAutoTransact"",
                ""value"": true
            }
        ],
        ""Stage"": 30,
        ""UserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
        ""UserId"": ""400075a6-19a2-49aa-8fa0-330ba2810540""
    },
    ""PostEntityImages"": [
        {
            ""key"": ""AsynchronousStepPrimaryName"",
            ""value"": {
                ""Attributes"": [
                    {
                        ""key"": ""subject"",
                        ""value"": ""This is a subject""
                    },
                    {
                        ""key"": ""activityid"",
                        ""value"": ""841579d9-7e63-ef11-9e4a-00155d0001ea""
                    }
                ],
                ""EntityState"": null,
                ""FormattedValues"": [],
                ""Id"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""new_customactivity"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        }
    ],
    ""PreEntityImages"": [
        {
            ""key"": ""Image"",
            ""value"": {
                ""Attributes"": [
                    {
                        ""key"": ""statecode"",
                        ""value"": {
                            ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Value"": 0
                        }
                    },
                    {
                        ""key"": ""description"",
                        ""value"": ""asdf""
                    },
                    {
                        ""key"": ""from"",
                        ""value"": {
                            ""__type"": ""EntityCollection:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Entities"": [
                                {
                                    ""Attributes"": [
                                        {
                                            ""key"": ""ispartydeleted"",
                                            ""value"": false
                                        },
                                        {
                                            ""key"": ""activityid"",
                                            ""value"": {
                                                ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Id"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
                                                ""KeyAttributes"": [],
                                                ""LogicalName"": ""activitypointer"",
                                                ""Name"": null,
                                                ""RowVersion"": null
                                            }
                                        },
                                        {
                                            ""key"": ""participationtypemask"",
                                            ""value"": {
                                                ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Value"": 1
                                            }
                                        },
                                        {
                                            ""key"": ""donotemail"",
                                            ""value"": false
                                        },
                                        {
                                            ""key"": ""scheduledend"",
                                            ""value"": ""\/Date(1724701394000)\/""
                                        },
                                        {
                                            ""key"": ""donotfax"",
                                            ""value"": false
                                        },
                                        {
                                            ""key"": ""donotpostalmail"",
                                            ""value"": false
                                        },
                                        {
                                            ""key"": ""ownerid"",
                                            ""value"": {
                                                ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Id"": ""8db66f44-8d23-e311-a2cb-0050569c0f02"",
                                                ""KeyAttributes"": [],
                                                ""LogicalName"": ""team"",
                                                ""Name"": null,
                                                ""RowVersion"": null
                                            }
                                        },
                                        {
                                            ""key"": ""partyid"",
                                            ""value"": {
                                                ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Id"": ""a76c0a41-4dec-ea11-a2d1-00155d04e323"",
                                                ""KeyAttributes"": [],
                                                ""LogicalName"": ""contact"",
                                                ""Name"": ""Some Contact"",
                                                ""RowVersion"": null
                                            }
                                        },
                                        {
                                            ""key"": ""activitypartyid"",
                                            ""value"": ""861579d9-7e63-ef11-9e4a-00155d0001ea""
                                        },
                                        {
                                            ""key"": ""instancetypecode"",
                                            ""value"": {
                                                ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Value"": 0
                                            }
                                        },
                                        {
                                            ""key"": ""scheduledstart"",
                                            ""value"": ""\/Date(1724701394000)\/""
                                        },
                                        {
                                            ""key"": ""donotphone"",
                                            ""value"": false
                                        }
                                    ],
                                    ""EntityState"": null,
                                    ""FormattedValues"": [
                                        {
                                            ""key"": ""ispartydeleted"",
                                            ""value"": ""No""
                                        },
                                        {
                                            ""key"": ""participationtypemask"",
                                            ""value"": ""Sender""
                                        },
                                        {
                                            ""key"": ""donotemail"",
                                            ""value"": ""Allow""
                                        },
                                        {
                                            ""key"": ""scheduledend"",
                                            ""value"": ""2024-08-26T22:43:14+03:00""
                                        },
                                        {
                                            ""key"": ""donotfax"",
                                            ""value"": ""Allow""
                                        },
                                        {
                                            ""key"": ""donotpostalmail"",
                                            ""value"": ""Allow""
                                        },
                                        {
                                            ""key"": ""partyid"",
                                            ""value"": ""Some Contact""
                                        },
                                        {
                                            ""key"": ""instancetypecode"",
                                            ""value"": ""Not Recurring""
                                        },
                                        {
                                            ""key"": ""scheduledstart"",
                                            ""value"": ""2024-08-26T22:43:14+03:00""
                                        },
                                        {
                                            ""key"": ""donotphone"",
                                            ""value"": ""Allow""
                                        }
                                    ],
                                    ""Id"": ""861579d9-7e63-ef11-9e4a-00155d0001ea"",
                                    ""KeyAttributes"": [],
                                    ""LogicalName"": ""activityparty"",
                                    ""RelatedEntities"": [],
                                    ""RowVersion"": ""147059704""
                                }
                            ],
                            ""EntityName"": ""activityparty"",
                            ""MinActiveRowVersion"": ""-1"",
                            ""MoreRecords"": false,
                            ""PagingCookie"": null,
                            ""TotalRecordCount"": -1,
                            ""TotalRecordCountLimitExceeded"": false
                        }
                    },
                    {
                        ""key"": ""regardingobjectid"",
                        ""value"": {
                            ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Id"": ""8b1579d9-7e63-ef11-9e4a-00155d0001ea"",
                            ""KeyAttributes"": [],
                            ""LogicalName"": ""new_otherentity"",
                            ""Name"": ""Other entity name"",
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
                        ""key"": ""subject"",
                        ""value"": ""This is a subject""
                    },
                    {
                        ""key"": ""to"",
                        ""value"": {
                            ""__type"": ""EntityCollection:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                            ""Entities"": [
                                {
                                    ""Attributes"": [
                                        {
                                            ""key"": ""ownerid"",
                                            ""value"": {
                                                ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Id"": ""8db66f44-8d23-e311-a2cb-0050569c0f02"",
                                                ""KeyAttributes"": [],
                                                ""LogicalName"": ""team"",
                                                ""Name"": null,
                                                ""RowVersion"": null
                                            }
                                        },
                                        {
                                            ""key"": ""activitypartyid"",
                                            ""value"": ""871579d9-7e63-ef11-9e4a-00155d0001ea""
                                        },
                                        {
                                            ""key"": ""participationtypemask"",
                                            ""value"": {
                                                ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Value"": 2
                                            }
                                        },
                                        {
                                            ""key"": ""activityid"",
                                            ""value"": {
                                                ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Id"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
                                                ""KeyAttributes"": [],
                                                ""LogicalName"": ""activitypointer"",
                                                ""Name"": null,
                                                ""RowVersion"": null
                                            }
                                        },
                                        {
                                            ""key"": ""ispartydeleted"",
                                            ""value"": false
                                        },
                                        {
                                            ""key"": ""scheduledend"",
                                            ""value"": ""\/Date(1724701394000)\/""
                                        },
                                        {
                                            ""key"": ""partyid"",
                                            ""value"": {
                                                ""__type"": ""EntityReference:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Id"": ""64b14206-8fbb-e611-80ef-005056bd19ee"",
                                                ""KeyAttributes"": [],
                                                ""LogicalName"": ""queue"",
                                                ""Name"": ""Queue Name"",
                                                ""RowVersion"": null
                                            }
                                        },
                                        {
                                            ""key"": ""scheduledstart"",
                                            ""value"": ""\/Date(1724701394000)\/""
                                        },
                                        {
                                            ""key"": ""instancetypecode"",
                                            ""value"": {
                                                ""__type"": ""OptionSetValue:http:\/\/schemas.microsoft.com\/xrm\/2011\/Contracts"",
                                                ""Value"": 0
                                            }
                                        }
                                    ],
                                    ""EntityState"": null,
                                    ""FormattedValues"": [
                                        {
                                            ""key"": ""participationtypemask"",
                                            ""value"": ""To Recipient""
                                        },
                                        {
                                            ""key"": ""ispartydeleted"",
                                            ""value"": ""No""
                                        },
                                        {
                                            ""key"": ""scheduledend"",
                                            ""value"": ""2024-08-26T22:43:14+03:00""
                                        },
                                        {
                                            ""key"": ""partyid"",
                                            ""value"": ""Queue Name""
                                        },
                                        {
                                            ""key"": ""scheduledstart"",
                                            ""value"": ""2024-08-26T22:43:14+03:00""
                                        },
                                        {
                                            ""key"": ""instancetypecode"",
                                            ""value"": ""Not Recurring""
                                        }
                                    ],
                                    ""Id"": ""871579d9-7e63-ef11-9e4a-00155d0001ea"",
                                    ""KeyAttributes"": [],
                                    ""LogicalName"": ""activityparty"",
                                    ""RelatedEntities"": [],
                                    ""RowVersion"": ""147059705""
                                }
                            ],
                            ""EntityName"": ""activityparty"",
                            ""MinActiveRowVersion"": ""-1"",
                            ""MoreRecords"": false,
                            ""PagingCookie"": null,
                            ""TotalRecordCount"": -1,
                            ""TotalRecordCountLimitExceeded"": false
                        }
                    }
                ],
                ""EntityState"": null,
                ""FormattedValues"": [
                    {
                        ""key"": ""statecode"",
                        ""value"": ""Open""
                    },
                    {
                        ""key"": ""regardingobjectid"",
                        ""value"": ""Other entity name""
                    },
                    {
                        ""key"": ""statuscode"",
                        ""value"": ""Open""
                    }
                ],
                ""Id"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
                ""KeyAttributes"": [],
                ""LogicalName"": ""new_customactivity"",
                ""RelatedEntities"": [],
                ""RowVersion"": null
            }
        }
    ],
    ""PrimaryEntityId"": ""841579d9-7e63-ef11-9e4a-00155d0001ea"",
    ""PrimaryEntityName"": ""new_customactivity"",
    ""RequestId"": ""3123f7a7-784a-4523-809a-11d47f16313a"",
    ""SecondaryEntityName"": ""none"",
    ""SharedVariables"": [
        {
            ""key"": ""IsAutoTransact"",
            ""value"": true
        }
    ],
    ""Stage"": 40,
    ""UserAzureActiveDirectoryObjectId"": ""00000000-0000-0000-0000-000000000000"",
    ""UserId"": ""400075a6-19a2-49aa-8fa0-330ba2810540""
}";

            var remoteExecutionContext = EntitySerializer.Deserialize<RemoteExecutionContext>(input);

            Assert.NotNull(remoteExecutionContext);
            Assert.NotNull(remoteExecutionContext.InputParameters);
            Assert.True(remoteExecutionContext.InputParameters.ContainsKey("Target"));

            var target = remoteExecutionContext.InputParameters["Target"] as Entity;
            Assert.NotNull(target);

            Assert.True(remoteExecutionContext.PreEntityImages.ContainsKey("Image"));
            var postEntityImage = remoteExecutionContext.PreEntityImages["Image"];

            Assert.NotNull(postEntityImage);
            EntityCollection entityCollection = postEntityImage.GetAttributeValue<EntityCollection>("to");
            Assert.NotNull(entityCollection);
            var partyId = entityCollection.Entities[0].GetAttributeValue<EntityReference>("partyid");
            Assert.NotNull(partyId);

            Assert.Equal(Guid.Parse("871579d9-7e63-ef11-9e4a-00155d0001ea"), entityCollection.Entities[0].GetAttributeValue<Guid>("activitypartyid"));

            Assert.Equal(Guid.Parse("841579d9-7e63-ef11-9e4a-00155d0001ea"), target.GetAttributeValue<Guid>("activityid"));
        }
    }
}
