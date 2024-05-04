var builder = DistributedApplication.CreateBuilder(args);

// add redis for output caching
var cache = builder.AddRedis("cache");
var grpcService = builder.AddProject<Projects.CodemicAspireApp_GrpcService>("grpcservice")
    .WithHttpsEndpoint();

var apiService = builder.AddProject<Projects.CodemicAspireApp_ApiService>("apiservice")
    .WithReference(grpcService);

builder.AddProject<Projects.CodemicAspireApp_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService)
    .WithExternalHttpEndpoints();

// Vue: npm run dev
builder.AddNpmApp("vue", "../CodemicAspireApp.VueApp")
    .WithReference(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
