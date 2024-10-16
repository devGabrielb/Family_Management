FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5047

ENV ASPNETCORE_URLS=http://+:5047

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Adapters/Api/Api.csproj", "src/Adapters/Api/"]
COPY ["src/Adapters/Persistence/Persistence.csproj", "src/Adapters/Persistence/"]
COPY ["src/Adapters/ServiceBus/ServiceBus.csproj", "src/Adapters/ServiceBus/"]
COPY ["src/Core/Domain/Domain.csproj", "src/Core/Domain/"]
COPY ["src/Core/Application/Application.csproj", "src/Core/Application/"]
RUN dotnet restore "src/Adapters/Api/Api.csproj"
COPY . .
WORKDIR "/src/src/Adapters/Api"
RUN dotnet build "Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
