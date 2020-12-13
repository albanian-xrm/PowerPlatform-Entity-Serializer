# AlbanianXrm.PowerPlatform.EntitySerializer

|Build Status|
|------------|
|[![Build Status](https://dev.azure.com/Albanian-Xrm/PowerPlatform-Entity-Serializer/_apis/build/status/albanian-xrm.PowerPlatform-Entity-Serializer?branchName=main)](https://dev.azure.com/Albanian-Xrm/PowerPlatform-Entity-Serializer/_build/latest?definitionId=4&branchName=main)|

|Package|NuGet|
|------------|------------|
|AlbanianXrm.PowerPlatform.EntitySerializer|[![AlbanianXrm.PowerPlatform.EntitySerializer](https://buildstats.info/nuget/AlbanianXrm.PowerPlatform.EntitySerializer)](https://www.nuget.org/packages/AlbanianXrm.PowerPlatform.EntitySerializer)|

This library can serialize an Microsoft.Xrm.Sdk.Entity to Json and back using [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json).

## Usage
To use the library:
1. Get the package from NuGet:
```
nuget install AlbanianXrm.PowerPlatform.EntitySerializer -PreRelease
```
2. Use EntitySerializer or the JsonConverters with your JsonSerializerOptions instance to serialize/deserialize your data.
