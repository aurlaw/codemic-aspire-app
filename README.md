# Codemic Aspire App

Demo app using .NET Aspire and .NET 8

## Prerequisites

- .NET 8 SDK
- Aspire 
- Aspir8
- Docker
- Kubernetes(Minikube)
Requires Aspir8

```bash
dotnet workload update
dotnet workload install aspire
dotnet tool install -g aspirate --prerelease
dotnet tool install -g dotnet-grpc
```

This project contains the following services

- Redis Cache
- gRPC Service
- Minimal API Service
- Blazor Web app
- Vue SPA


#### Grpc Service

Uses shared proto files
```bash
cd CodemicAspireApp/CodemicAspireApp.GrpcService
dotnet-grpc add-file -s Server ../Shared/Protos/*.proto

cd CodemicAspireApp/CodemicAspireApp.ApiService
dotnet-grpc add-file -s Client ../Shared/Protos/*.proto

```

 Run CodemicAspireApp.AppHost project to start the Aspire process.



[//]: # (## Generate manifest)

[//]: # ()
[//]: # ()
[//]: # ()
[//]: # (`dotnet run --project CodemicAspireApp.AppHost/CodemicAspireApp.AppHost.csproj   --publisher manifest --output-path manifest.json`)

[//]: # ()


## Aspir8

[//]: # (Local Docker Respository)

[//]: # ()
[//]: # (`docker run -d -p 5001:5000 --restart always --name registry registry:2`)

### Initial set up using

These commands must be executed in the `CodemicAspireApp.AppHost` directory

`aspirate init`

Using Docker Desktop and Minikube

`eval $(minikube -p minikube docker-env)`

### Build Aspire Manifest and docker images

`aspirate build`

append `-ct TAG` for custom tags

[//]: # (Note: There is an issue with Aspir8 parsing the maniest.json file. Ensure all PORTS are set to explicit string values and not placeholders)

### Generate Kubernetes manifest

`aspirate generate -m manifest.json` 

append `-ct TAG` for custom tags

### Apply manifest to cluster

`aspirate apply`

[//]: # (When using Minkube, ensure its started with `--insecure-registry` flag)

[//]: # ()
[//]: # (`minikube start --insecure-registry "10.0.0.0/24"`)

### Testing

We need to expose the service from Kubernetes

```bash
kubectl port-forward service/apiservice 7080:8080
kubectl port-forward service/vue 8000:8000
kubectl port-forward service/webfrontend  8080:8080
kubectl port-forward service/aspire-dashboard  18888:18888
```

Vue app
`http:/localhost:8000/`

Blazor app
`http:/localhost:8080/`

Aspire Dashboard
`http:/localhost:18888/`