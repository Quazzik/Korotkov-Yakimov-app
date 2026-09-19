FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Console/Console.sln ./Console/
COPY Console/Console/*.csproj ./Console/Console/
COPY Console/WebAppi/*.csproj ./Console/WebAppi/
RUN dotnet restore Console/Console.sln

COPY Console/ ./Console/
RUN find Console -type d \( -name bin -o -name obj \) -prune -exec rm -rf {} +
RUN dotnet restore Console/Console.sln
RUN dotnet publish Console/WebAppi/WebAppi.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080
ENTRYPOINT ["dotnet", "WebAppi.dll"]
