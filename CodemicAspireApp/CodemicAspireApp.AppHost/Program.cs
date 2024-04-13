var builder = DistributedApplication.CreateBuilder(args);

// add redis for output caching
var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.CodemicAspireApp_ApiService>("apiservice");

builder.AddProject<Projects.CodemicAspireApp_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();