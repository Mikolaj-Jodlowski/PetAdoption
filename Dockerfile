# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5013

# Use the official ASP.NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy the project files to the container
COPY ["PetAdoption.csproj", "."]
RUN dotnet restore

# Copy the entire project directory to the container
COPY . .

# Build the application
WORKDIR "/src/"
RUN dotnet build "PetAdoption.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PetAdoption.csproj" -c Release -o /app/publish

# Build the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Start the application
ENTRYPOINT ["dotnet", "PetAdoption.dll"]
