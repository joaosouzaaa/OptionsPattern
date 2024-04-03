FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OptionsPattern.API/OptionsPattern.API.csproj", "OptionsPattern.API/"]
RUN dotnet restore "./OptionsPattern.API/OptionsPattern.API.csproj"
COPY . .
WORKDIR "/src/OptionsPattern.API"
RUN dotnet build "./OptionsPattern.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OptionsPattern.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OptionsPattern.API.dll"]