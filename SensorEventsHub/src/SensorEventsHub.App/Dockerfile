#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SensorEventsHub.App/SensorEventsHub.App.csproj", "src/SensorEventsHub.App/"]
COPY ["src/SensorEventsHub.Domain/SensorEventsHub.Domain.csproj", "src/SensorEventsHub.Domain/"]
COPY ["src/SensorEventsHub.Infrastructure/SensorEventsHub.Infrastructure.csproj", "src/SensorEventsHub.Infrastructure/"]
RUN dotnet restore "src/SensorEventsHub.App/SensorEventsHub.App.csproj"
COPY . .
WORKDIR "/src/src/SensorEventsHub.App"
RUN dotnet build "SensorEventsHub.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensorEventsHub.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorEventsHub.App.dll","run", "--no-restore", "--urls", "https://0.0.0.0:5000"]