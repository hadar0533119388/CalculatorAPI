# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Calculator/*.csproj ./Calculator/
COPY Calculator.Tests/*.csproj ./Calculator.Tests/
RUN dotnet restore

COPY . .
WORKDIR /app/Calculator
RUN dotnet publish -c Release -o /out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "Calculator.dll"]
