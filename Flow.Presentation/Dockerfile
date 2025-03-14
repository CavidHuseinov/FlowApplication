FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Flow.Presentation/Flow.Presentation.csproj", "Flow.Presentation/"]
COPY ["Flow.DAL/Flow.DAL.csproj", "Flow.DAL/"]
COPY ["Flow.Core/Flow.Core.csproj", "Flow.Core/"]
COPY ["Flow.Business/Flow.Business.csproj", "Flow.Business/"]
COPY ["Flow.Infrastructure/Flow.Infrastructure.csproj", "Flow.Infrastructure/"]

RUN dotnet restore "Flow.Presentation/Flow.Presentation.csproj"

COPY . .

WORKDIR "/src/Flow.Presentation"
RUN dotnet build "Flow.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Flow.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Flow.Presentation.dll"]
