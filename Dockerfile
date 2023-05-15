FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY src/EngiePowerPlantCodingChallenge.WebApi .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS app
WORKDIR /app
COPY --from=build /src/out .
ENTRYPOINT ["dotnet", "EngiePowerPlantCodingChallenge.WebApi.dll"]
