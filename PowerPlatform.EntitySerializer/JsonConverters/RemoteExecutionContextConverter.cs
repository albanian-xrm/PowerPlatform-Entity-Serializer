using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
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
        private JsonConverter<object> objectContractConverter;
        private JsonConverter<IList<object>> listOfObjectsConverter;

        public RemoteExecutionContextConverter(EntitySerializerOptions entitySerializerOptions)
        {
            this.entitySerializerOptions = entitySerializerOptions;
        }
        public override RemoteExecutionContext Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
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
                        value.CorrelationId = guidConverter.Read(ref reader, typeof(Guid), options);
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
                        entitySerializerOptions.UnknownPropertiesLastSerialization[propertyName] = ObjectContractConverter.ReadValue(ref reader, options, entitySerializerOptions, ref objectContractConverter, ref listOfObjectsConverter, propertyName);
                        break;
                        //throw new JsonException($"Unknknown property \"{propertyName}\" for RemoteExecutionContext type.");
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
            if (value == null)
            {
                writer.WriteNullValue();
                writer.WriteEndObject();
                return;
            }
            if (guidConverter == null) guidConverter = entitySerializerOptions.converters.GetForType<Guid>();
            if (parameterCollectionConverter == null) parameterCollectionConverter = entitySerializerOptions.converters.GetForType<ParameterCollection>();
            if (dateTimeConverter == null) dateTimeConverter = entitySerializerOptions.converters.GetForType<DateTime>();
            if (entityImageCollectionConverter == null) entityImageCollectionConverter = entitySerializerOptions.converters.GetForType<EntityImageCollection>();
            if (entityReferenceConverter == null) entityReferenceConverter = entitySerializerOptions.converters.GetForType<EntityReference>();

            writer.WritePropertyName(nameof(value.BusinessUnitId));
            guidConverter.Write(writer, value.BusinessUnitId, options);

            writer.WritePropertyName(nameof(value.CorrelationId));
            guidConverter.Write(writer, value.CorrelationId, options);

            writer.WritePropertyName(nameof(value.Depth));
            writer.WriteNumberValue(value.Depth);

            writer.WritePropertyName(nameof(value.InitiatingUserAzureActiveDirectoryObjectId));
            guidConverter.Write(writer, value.InitiatingUserAzureActiveDirectoryObjectId, options);

            writer.WritePropertyName(nameof(value.InitiatingUserId));
            guidConverter.Write(writer, value.InitiatingUserId, options);

            writer.WritePropertyName(nameof(value.InputParameters));
            parameterCollectionConverter.Write(writer, value.InputParameters, options);

            writer.WritePropertyName(nameof(value.IsExecutingOffline));
            writer.WriteBooleanValue(value.IsExecutingOffline);

            writer.WritePropertyName(nameof(value.IsInTransaction));
            writer.WriteBooleanValue(value.IsInTransaction);

            writer.WritePropertyName(nameof(value.IsOfflinePlayback));
            writer.WriteBooleanValue(value.IsOfflinePlayback);

            writer.WritePropertyName(nameof(value.IsolationMode));
            writer.WriteNumberValue(value.IsolationMode);

            writer.WritePropertyName(nameof(value.MessageName));
            writer.WriteStringValue(value.MessageName);

            writer.WritePropertyName(nameof(value.Mode));
            writer.WriteNumberValue(value.Mode);

            writer.WritePropertyName(nameof(value.OperationCreatedOn));
            dateTimeConverter.Write(writer, value.OperationCreatedOn, options);

            writer.WritePropertyName(nameof(value.OperationId));
            guidConverter.Write(writer, value.OperationId, options);

            writer.WritePropertyName(nameof(value.OrganizationId));
            guidConverter.Write(writer, value.OrganizationId, options);

            writer.WritePropertyName(nameof(value.OrganizationName));
            writer.WriteStringValue(value.OrganizationName);

            writer.WritePropertyName(nameof(value.OutputParameters));
            parameterCollectionConverter.Write(writer, value.OutputParameters, options);

            writer.WritePropertyName(nameof(value.OwningExtension));
            entityReferenceConverter.Write(writer, value.OwningExtension, options);

            if (value.ParentContext != null)
            {
                writer.WritePropertyName(nameof(value.ParentContext));
                Write(writer, value.ParentContext, options); // Recursively write the parent context
            } else
            {
                writer.WriteNull(nameof(value.ParentContext));
            }

                writer.WritePropertyName(nameof(value.PostEntityImages));
            entityImageCollectionConverter.Write(writer, value.PostEntityImages, options);

            writer.WritePropertyName(nameof(value.PreEntityImages));
            entityImageCollectionConverter.Write(writer, value.PreEntityImages, options);

            writer.WritePropertyName(nameof(value.PrimaryEntityId));
            guidConverter.Write(writer, value.PrimaryEntityId, options);

            writer.WritePropertyName(nameof(value.PrimaryEntityName));
            writer.WriteStringValue(value.PrimaryEntityName);

            writer.WritePropertyName(nameof(value.RequestId));
            if (value.RequestId.HasValue)
            {
                guidConverter.Write(writer, value.RequestId.Value, options);
            }
            else
            {
                writer.WriteNullValue();
            }

            writer.WritePropertyName(nameof(value.SecondaryEntityName));
            writer.WriteStringValue(value.SecondaryEntityName);

            writer.WritePropertyName(nameof(value.SharedVariables));
            parameterCollectionConverter.Write(writer, value.SharedVariables, options);

            writer.WritePropertyName(nameof(value.Stage));
            writer.WriteNumberValue(value.Stage);

            writer.WritePropertyName(nameof(value.UserAzureActiveDirectoryObjectId));
            guidConverter.Write(writer, value.UserAzureActiveDirectoryObjectId, options);

            writer.WritePropertyName(nameof(value.UserId));
            guidConverter.Write(writer, value.UserId, options);

            writer.WriteEndObject();
        }
    }
}
