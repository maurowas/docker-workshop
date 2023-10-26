FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["App1.csproj", "./"]
RUN dotnet restore "App1.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "App1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App1.dll"]
