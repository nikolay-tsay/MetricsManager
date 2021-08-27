FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MetricsManager/MetricsManager.csproj", "MetricsManager/"]
RUN dotnet restore "MetricsManager/MetricsManager.csproj"
COPY . .
WORKDIR "/src/MetricsManager"
RUN dotnet build "MetricsManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetricsManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MetricsManager.dll"]
