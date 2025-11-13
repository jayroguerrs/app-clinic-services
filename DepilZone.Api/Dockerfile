# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DepilZone.Api/DepilZone.Api.csproj", "DepilZone.Api/"]
COPY ["DepilZone.Application/DepilZone.Application.csproj", "DepilZone.Application/"]
COPY ["DepilZone.Domain/DepilZone.Domain.csproj", "DepilZone.Domain/"]
COPY ["DepilZone.Entidad/DepilZone.Entidad.csproj", "DepilZone.Entidad/"]
COPY ["DepilZone.Data/DepilZone.Data.csproj", "DepilZone.Data/"]
RUN dotnet restore "./DepilZone.Api/DepilZone.Api.csproj"
COPY . .
WORKDIR "/src/DepilZone.Api"
RUN dotnet build "./DepilZone.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DepilZone.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DepilZone.Api.dll"]