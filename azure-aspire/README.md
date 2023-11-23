# Prerequisites

- Have dotnet 8 sdk installed.
- Have the aspire workload installed:
```
dotnet workload install aspire
```
- Docker

# Examples

This solution example is based on the following template:
```
dotnet new aspire-starter
```

# Boilerplate Information

The two projects that are unique to aspire are `<appname>.AppHost` and `<appname>.ServiceDefaults`.

The `AppHost project will run any .NET projects, containers, or executables needed as part of your distributed application. If using Visual Studio, debugging will attach to all running projects, allowing to step into and across each service in the system.

The `ServiceDefaults` project contains common service-centric logic that applies to each of the projects in the app. This is where cross cutting concerns like service discovery, telemetry, and health check endpoints are configured. Here is where you would tweak settings. 

## The Dashboard

Launching an aspire application, lets  you see the developer dashboard. It functions a bit like an in-depth version of Azure Insights and Docker Desktop combined. The logs and traces here are super interesting.

## Routing

Similar to using host names in a docker network environment. Aspire seeks to remove the need to write ip addresses and ports, for all environments.
This code snippet is from the startup of the Blazor web application:
```
builder.Services.AddHttpClient<WeatherApiClient>(
    client => client.BaseAddress = new("http://apiservice"));
```
The `apiservice` will be a valid route, because of the name registering done in the `AppHost` project:
```
var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var apiservice = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiservice);

builder.Build().Run();
```
Aspire will then take care of routing communication from the Blazor web application the web api, whilst using logical names in the code. This removes the need to create abstract environment-based configuration for ip addresses, ports and alike.

# Source

Most information about Azure Aspire can be found in their introductory article, summarizing the dotnet 8 conference: https://devblogs.microsoft.com/dotnet/introducing-dotnet-aspire-simplifying-cloud-native-development-with-dotnet-8/
Other than that. There's the official Azure Aspire documentation: https://learn.microsoft.com/en-us/dotnet/aspire/