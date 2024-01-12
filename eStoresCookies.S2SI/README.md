# eStores for Cookies

I am learning this project from multiple books, video courses, and websites.

## DAPR - Distributed Application Runtime - An event-driven, portable runtime for building microservices on cloud and edge

### Orders Microservice

```powershell
dotnet new webapi -o eStoresCookies.OrdersAPI
dotnet add package Dapr.AspNetCore --version 1.12.0
```

### Reservations Microservice

```powershell
dotnet new webapi -o eStoresCookies.ItemsReservationAPI
dotnet add package Dapr.AspNetCore --version 1.12.0
```

### Executing the application

```powershell
# orders-service HTTP + itemsreservation-service HTTP
dapr run --app-id "orders-service" --app-port "5001" --dapr-grpc-port "50010" --dapr-http-port "5010" -- dotnet run --project eStoresCookies.OrdersAPI.csproj --urls="http://+:5001"
dapr run --app-id "itemsreservation-service" --app-port "5002" --dapr-grpc-port "50020" --dapr-http-port "5020" -- dotnet run --project eStoresCookies.ItemsReservationAPI.csproj --urls="http://+:5002"

# orders-service HTTP + itemsreservation-service HTTP with Resiliency
dapr run --app-id "orders-service" --app-port "5001" --dapr-grpc-port "50010" --dapr-http-port "5010" --config "../daprconfig.yaml" --resources-path "../components" -- dotnet run --project eStoresCookies.OrdersAPI.csproj --urls="http://+:5001"
dapr run --app-id "itemsreservation-service" --app-port "5002" --dapr-grpc-port "50020" --dapr-http-port "5020" --config "../daprconfig.yaml" --resources-path "../components" -- dotnet run --project eStoresCookies.ItemsReservationAPI.csproj --urls="http://+:5002"
```

## Ways to Execute and Debug DAPR

> 1. Using DAPR CLI
> 2. Using Visual Studio Code, .NET Core Attach to Process
> 3. Leverage the Dapr extension for VS Code to scaffold the configuration files and launch the Dapr runtime

## Few commands to get started with DAPR

```bash
darp --version

darp --help

darp init # In  Run as administrator. It should install all required components

dapr uninstall --all

dapr init # For Standalone

dapr init -k  # For Kubernetes

dapr status -k

dapr dashboard
```

## First Project in DAPR

```bash
dotnet new webapi -o dapr.microservice.webapi

dotnet add package Dapr.AspNetCore --version 1.12.0

# launch Dapr
dapr run --app-id "sample" --app-port "5000" --dapr-http-port "5010" -- dotnet run --project dapr.microservice.webapi.csproj --urls="http://+:5000"

dapr run --app-id "sample" --app-port "5001" --dapr-http-port "5010" --dapr-grpc-port "50010" --metrics-port "9091"

http://localhost:5000/api/helloworld/gethello # Web API

http://localhost:5010/v1.0/invoke/sample/method/api/helloworld/gethello # DAPR invoke
```

