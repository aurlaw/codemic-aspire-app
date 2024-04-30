# Codemic Aspire App

Demo app using .NET Aspire and .NET 8

## Prerequisites

- .NET 8 SDK
- Aspire
- Aspir8
- Docker
- Kubernetes(Minikube)
Requires Aspir8

`dotnet tool install -g aspirate --prerelease`


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
` eval $(minikube -p minikube docker-env)`

### Build Aspire Manifest and docker images

`aspirate build`

[//]: # (Note: There is an issue with Aspir8 parsing the maniest.json file. Ensure all PORTS are set to explicit string values and not placeholders)

### Generate Kubernetes manifest

`aspirate generate -m manifest.json`

### Apply manifest to cluster

`aspirate apply`

[//]: # (When using Minkube, ensure its started with `--insecure-registry` flag)

[//]: # ()
[//]: # (`minikube start --insecure-registry "10.0.0.0/24"`)