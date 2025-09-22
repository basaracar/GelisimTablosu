FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
HEALTHCHECK --interval=30s --timeout=3s --retries=3 \
  CMD curl -f http://localhost:8080/health || exit 1

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["GelisimTablosu.csproj", "./"]
RUN dotnet restore "GelisimTablosu.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GelisimTablosu.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GelisimTablosu.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "GelisimTablosu.dll"]