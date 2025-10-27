# Build Instructions

## Issue Resolution
The project was targeting .NET 9.0 but the system only had .NET 8.0 SDK installed.

## Solution
Install .NET 9.0 SDK using the Microsoft installation script:

```bash
# Install .NET 9.0 SDK
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 9.0

# Add to PATH for current session
export PATH="/home/runner/.dotnet:$PATH"

# Verify installation
dotnet --version
```

## Building the Project
```bash
cd LeaveManagementSystem
dotnet build
```

## Running the Project
```bash
cd LeaveManagementSystem
dotnet run
```

## Testing the API
The application exposes a Weather Forecast endpoint at:
```
GET http://localhost:5000/weatherforecast
```

## Entity Framework
The project uses Entity Framework Core with migrations. To list migrations:
```bash
dotnet ef migrations list
```

Note: The project is configured to use LocalDB which may not be available on non-Windows platforms, but this doesn't prevent building and running the application.