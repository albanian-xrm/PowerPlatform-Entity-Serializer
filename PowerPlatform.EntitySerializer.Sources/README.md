# AlbanianXrm.PowerPlatform.EntitySerializer

|Build Status|
|------------|
|[![Build Status](https://dev.azure.com/Albanian-Xrm/PowerPlatform-Entity-Serializer/_apis/build/status/albanian-xrm.PowerPlatform-Entity-Serializer?branchName=main)](https://dev.azure.com/Albanian-Xrm/PowerPlatform-Entity-Serializer/_build/latest?definitionId=4&branchName=main)|
|[![Build history](https://buildstats.info/azurepipelines/chart/Albanian-Xrm/PowerPlatform-Entity-Serializer/4)](https://dev.azure.com/Albanian-Xrm/PowerPlatform-Entity-Serializer/_build?definitionId=4)|

|Package|NuGet|
|------------|------------|
|AlbanianXrm.PowerPlatform.EntitySerializer.Sources|[![AlbanianXrm.PowerPlatform.EntitySerializer.Sources](https://buildstats.info/nuget/AlbanianXrm.PowerPlatform.EntitySerializer.Sources?includePreReleases=true)](https://www.nuget.org/packages/AlbanianXrm.PowerPlatform.EntitySerializer.Sources)|

This library can serialize an Microsoft.Xrm.Sdk.Entity to Json and back using [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json).

## Usage
To use the library:
1. Get the package from NuGet:
```
nuget install AlbanianXrm.PowerPlatform.EntitySerializer.Sources
```
2. Use EntitySerializer or the JsonConverters with your JsonSerializerOptions instance to serialize/deserialize your data.
