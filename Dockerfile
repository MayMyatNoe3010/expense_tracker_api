# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY *.sln ./
COPY ExpenseTracker.API/*.csproj ./ExpenseTracker.API/
COPY ExpenseTracker.Models/*.csproj ./ExpenseTracker.Models/
COPY ExpenseTracker.DataAccess/*.csproj ./ExpenseTracker.DataAccess/
COPY ExpenseTracker.Services/*.csproj ./ExpenseTracker.Services/
COPY ExpenseTracker.Utility/*.csproj ./ExpenseTracker.Utility/

# Restore dependencies
RUN dotnet restore

# Copy everything else
COPY . ./

# Build the project
WORKDIR /app/ExpenseTracker.API
RUN dotnet publish -c Release -o out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/ExpenseTracker.API/out .

# Expose port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "ExpenseTracker.API.dll"]
