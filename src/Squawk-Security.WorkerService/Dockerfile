#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Squawk-Security.WorkerService/Squawk-Security.WorkerService.csproj", "Squawk-Security.WorkerService/"]
RUN dotnet restore "Squawk-Security.WorkerService/Squawk-Security.WorkerService.csproj"
COPY . .
WORKDIR "/src/Squawk-Security.WorkerService"
RUN dotnet build "Squawk-Security.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Squawk-Security.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update && \
	apt install -y --allow-unauthenticated \
		libpcap0.8

ENTRYPOINT ["dotnet", "Squawk-Security.WorkerService.dll"]