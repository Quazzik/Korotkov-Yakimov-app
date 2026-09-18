# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY SlagModeServer/SlagModeServer.sln ./SlagModeServer/

# Copy external libraries (mathLibs)
COPY mathLibs/ ./mathLibs/

# Copy project files for restore
COPY SlagModeServer/*.csproj ./SlagModeServer/
COPY SlagSolverLibrary/*.csproj ./SlagSolverLibrary/
RUN dotnet restore SlagModeServer/SlagModeServer.sln

# Copy all source code
COPY . ./

# Publish
RUN dotnet publish SlagModeServer/SlagModeServer.sln -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080
ENTRYPOINT ["dotnet", "SlagModeServer.dll"]