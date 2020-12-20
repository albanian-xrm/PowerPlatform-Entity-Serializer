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
        private JsonConverter<DateTime> dateTimeConverter;
        private JsonConverter<EntityImageCollection> entityImageCollectionConverter;
        private JsonConverter<EntityReference> entityReferenceConverter;
        private JsonConverter<Guid> guidConverter;

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
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.BusinessUnitId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.CorrelationId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.BusinessUnitId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.Depth):
                        value.Depth = reader.GetInt32();
                        break;
                    case nameof(value.InitiatingUserAzureActiveDirectoryObjectId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.InitiatingUserAzureActiveDirectoryObjectId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.InitiatingUserId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.InitiatingUserId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.InputParameters):
                        if (parameterCollectionConverter == null) parameterCollectionConverter = entitySerializerOptions.converters.GetForType<ParameterCollection>();
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
                        if (dateTimeConverter == null) dateTimeConverter = entitySerializerOptions.converters.GetForType<DateTime>();
                        value.OperationCreatedOn = dateTimeConverter.Read(ref reader, typeof(DateTime), options);
                        break;
                    case nameof(value.OperationId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.OperationId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.OrganizationId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.OrganizationId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.OrganizationName):
                        value.OrganizationName = reader.GetString();
                        break;
                    case nameof(value.OutputParameters):
                        if (parameterCollectionConverter == null) parameterCollectionConverter = entitySerializerOptions.converters.GetForType<ParameterCollection>();
                        var outputParameters = parameterCollectionConverter.Read(ref reader, typeof(ParameterCollection), options);
                        foreach (var item in outputParameters)
                        {
                            value.OutputParameters.Add(item);
                        }
                        break;
                    case nameof(value.OwningExtension):
                        if (entityReferenceConverter == null) entityReferenceConverter = entitySerializerOptions.converters.GetForType<EntityReference>();
                        value.OwningExtension = entityReferenceConverter.Read(ref reader, typeof(EntityReference), options);
                        break;
                    case nameof(value.ParentContext):
                        value.ParentContext = Read(ref reader, typeof(RemoteExecutionContext), options);
                        break;
                    case nameof(value.PostEntityImages):
                        if (entityImageCollectionConverter == null) entityImageCollectionConverter = entitySerializerOptions.converters.GetForType<EntityImageCollection>();
                        var postEntityImages = entityImageCollectionConverter.Read(ref reader, typeof(EntityImageCollection), options);
                        foreach (var item in postEntityImages)
                        {
                            value.PostEntityImages.Add(item);
                        }
                        break;
                    case nameof(value.PreEntityImages):
                        if (entityImageCollectionConverter == null) entityImageCollectionConverter = entitySerializerOptions.converters.GetForType<EntityImageCollection>();
                        var preEntityImages = entityImageCollectionConverter.Read(ref reader, typeof(EntityImageCollection), options);
                        foreach (var item in preEntityImages)
                        {
                            value.PreEntityImages.Add(item);
                        }
                        break;
                    case nameof(value.PrimaryEntityId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.PrimaryEntityId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.PrimaryEntityName):
                        value.PrimaryEntityName = reader.GetString();
                        break;
                    case nameof(value.RequestId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.RequestId = reader.TokenType == JsonTokenType.Null ? default(Guid?) : guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.SecondaryEntityName):
                        value.SecondaryEntityName = reader.GetString();
                        break;
                    case nameof(value.SharedVariables):
                        if (parameterCollectionConverter == null) parameterCollectionConverter = entitySerializerOptions.converters.GetForType<ParameterCollection>();
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
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.UserAzureActiveDirectoryObjectId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    case nameof(value.UserId):
                        if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
                        value.UserId = guidConverter.Read(ref reader, typeof(Guid), options);
                        break;
                    default:
                        throw new JsonException($"Unknknown property \"{propertyName}\" for RemoteExecutionContext type.");
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
