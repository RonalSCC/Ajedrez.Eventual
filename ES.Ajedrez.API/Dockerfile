FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ES.Ajedrez.API/ES.Ajedrez.API.csproj", "ES.Ajedrez.API/"]
RUN dotnet restore "ES.Ajedrez.API/ES.Ajedrez.API.csproj"
COPY . .
WORKDIR "/src/ES.Ajedrez.API"
RUN dotnet build "ES.Ajedrez.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ES.Ajedrez.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.Ajedrez.API.dll"]
