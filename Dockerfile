FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR  /source
COPY . .
RUN dotnet restore "./Agora.Api/Agora.Api.csproj" --disable-parallel
RUN dotnet publish "./Agora.Api/Agora.Api.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Agora.Api.dll"]