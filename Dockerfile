# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["src/StartBack.Api/StartBack.Api.csproj", "src/StartBack.Api/"]
COPY ["src/StartBack.Application/StartBack.Application.csproj", "src/StartBack.Application/"]
COPY ["src/StartBack.Domain/StartBack.Domain.csproj", "src/StartBack.Domain/"]
COPY ["src/StartBack.Infrastructure/StartBack.Infrastructure.csproj", "src/StartBack.Infrastructure/"]

RUN dotnet restore "src/StartBack.Api/StartBack.Api.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/src/StartBack.Api"
RUN dotnet build "StartBack.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "StartBack.Api.csproj" -c Release -o /app/publish

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StartBack.Api.dll"]
