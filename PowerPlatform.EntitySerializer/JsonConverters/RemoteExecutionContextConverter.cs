using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlbanianXrm.PowerPlatform.JsonConverters
{
    public class RemoteExecutionContextConverter : JsonConverter<RemoteExecutionContext>
    {
        private readonly EntitySerializerOptions entitySerializerOptions;
        private JsonConverter<ParameterCollection> parameterCollectionConverter;

        public RemoteExecutionContextConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override RemoteExecutionContext Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(RemoteExecutionContext));

            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            var value = new RemoteExecutionContext();

            reader.Read();
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                string propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case nameof(value.BusinessUnitId):
                        value.BusinessUnitId = reader.GetGuid();
                        break;
                    case nameof(value.CorrelationId):
                        value.BusinessUnitId = reader.GetGuid();
                        break;
                    case nameof(value.Depth):
                        value.Depth = reader.GetInt32();
                        break;
                    case nameof(value.InitiatingUserAzureActiveDirectoryObjectId):
                        value.InitiatingUserAzureActiveDirectoryObjectId = reader.GetGuid();
                        break;
                    case nameof(value.InitiatingUserId):
                        value.InitiatingUserId = reader.GetGuid();
                        break;
                    case nameof(value.InputParameters):
                        if (parameterCollectionConverter == null) parameterCollectionConverter = (JsonConverter<ParameterCollection>)entitySerializerOptions.converters[typeof(ParameterCollection)];
                        var inputParameters = parameterCollectionConverter.Read(ref reader, typeof(ParameterCollection), options);
                        foreach (var item in inputParameters)
                        {
                            value.InputParameters.Add(item);
                        }
                        break;
                    case nameof(value.IsExecutingOffline):
                        value.IsExecutingOffline = reader.GetBoolean();
                        break;
                    case nameof(value.IsInTransaction):
                        value.IsInTransaction = reader.GetBoolean();
                        break;
                    case nameof(value.IsOfflinePlayback):
                        value.IsOfflinePlayback = reader.GetBoolean();
                        break;
                    case nameof(value.IsolationMode):
                        value.IsolationMode = reader.GetInt32();
                        break;
                    case nameof(value.MessageName):
                        value.MessageName = reader.GetString();
                        break;
                    case nameof(value.Mode):
                        value.Mode = reader.GetInt32();
                        break;
                    case nameof(value.OperationCreatedOn):
                        value.OperationCreatedOn = JsonSerializer.Deserialize<DateTime>(ref reader, options);
                        break;
                    case nameof(value.OperationId):
                        value.OperationId = reader.GetGuid();
                        break;
                    case nameof(value.OrganizationId):
                        value.OrganizationId = reader.GetGuid();
                        break;
                    case nameof(value.OrganizationName):
                        value.OrganizationName = reader.GetString();
                        break;
                    case nameof(value.OutputParameters):
                        if (parameterCollectionConverter == null) parameterCollectionConverter = (JsonConverter<ParameterCollection>)entitySerializerOptions.converters[typeof(ParameterCollection)];
                        var outputParameters = parameterCollectionConverter.Read(ref reader, typeof(ParameterCollection), options);
                        foreach (var item in outputParameters)
                        {
                            value.OutputParameters.Add(item);
                        }
                        break;
                    case nameof(value.OwningExtension):
                        value.OwningExtension = JsonSerializer.Deserialize<EntityReference>(ref reader, options);
                        break;
                    case nameof(value.ParentContext):
                        value.ParentContext = Read(ref reader, typeof(RemoteExecutionContext), options);
                        break;
                    case nameof(value.PostEntityImages):
                        var postEntityImages = JsonSerializer.Deserialize<EntityImageCollection>(ref reader, options);
                        foreach (var item in postEntityImages)
                        {
                            value.PostEntityImages.Add(item);
                        }
                        break;
                    case nameof(value.PreEntityImages):
                        var preEntityImages = JsonSerializer.Deserialize<EntityImageCollection>(ref reader, options);
                        foreach (var item in preEntityImages)
                        {
                            value.PreEntityImages.Add(item);
                        }
                        break;
                    case nameof(value.PrimaryEntityId):
                        value.PrimaryEntityId = reader.GetGuid();
                        break;
                    case nameof(value.PrimaryEntityName):
                        value.PrimaryEntityName = reader.GetString();
                        break;
                    case nameof(value.RequestId):
                        value.RequestId = reader.TokenType == JsonTokenType.Null ? default(Guid?) : reader.GetGuid();
                        break;
                    case nameof(value.SecondaryEntityName):
                        value.SecondaryEntityName = reader.GetString();
                        break;
                    case nameof(value.SharedVariables):
                        if (parameterCollectionConverter == null) parameterCollectionConverter = (JsonConverter<ParameterCollection>)entitySerializerOptions.converters[typeof(ParameterCollection)];
                        var sharedVariables = parameterCollectionConverter.Read(ref reader, typeof(ParameterCollection), options);                      
                        foreach (var item in sharedVariables)
                        {
                            value.SharedVariables.Add(item);
                        }
                        break;
                    case nameof(value.Stage):
                        value.Stage = reader.GetInt32();
                        break;
                    case nameof(value.UserAzureActiveDirectoryObjectId):
                        value.UserAzureActiveDirectoryObjectId = reader.GetGuid();
                        break;
                    case nameof(value.UserId):
                        value.UserId = reader.GetGuid();
                        break;
                    default:
                        throw new JsonException($"Unknknown property \"{propertyName}\" for EntityReference type.");
                }
                if (!reader.Read())
                {
                    throw new JsonException();
                }
            }
            return value;
        }

        public override void Write(Utf8JsonWriter writer, RemoteExecutionContext value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
