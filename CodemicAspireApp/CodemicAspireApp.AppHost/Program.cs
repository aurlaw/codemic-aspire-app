var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CodemicAspireApp_ApiService>("apiservice");

builder.AddProject<Projects.CodemicAspireApp_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();