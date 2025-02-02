# Use the official .NET 9.0 image as the base image for running the app
# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the official .NET SDK image to build the app
# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the solution file and all the project files to the build container
COPY ["PracticeApp.sln", "/src/"]
COPY ["PracticeApp.Core/PracticeApp.Core.csproj", "PracticeApp.Core/"]
COPY ["PracticeApp.Data/PracticeApp.Data.csproj", "PracticeApp.Data/"]
COPY ["PracticeApp.WebApi/PracticeApp.WebApi.csproj", "PracticeApp.WebApi/"]

# Restore the dependencies
RUN dotnet restore "/src/PracticeApp.sln"

# Copy the entire code to the build container
COPY . .

# Set the working directory to the Web API project folder
WORKDIR "/src/PracticeApp.WebApi"

# Build the application
RUN dotnet build "PracticeApp.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application to the /app/publish directory
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PracticeApp.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Use the base image to run the application
FROM base AS final
WORKDIR /app

# Copy the published app from the publish stage
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "PracticeApp.WebApi.dll"]
