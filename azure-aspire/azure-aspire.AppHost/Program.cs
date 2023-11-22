var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.azure_aspire_ApiService>("apiservice");

builder.AddProject<Projects.azure_aspire_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();
