FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Here.Api/Here.Api.csproj", "Here.Api/"]
COPY ["Here.Core/Here.Core.csproj", "Here.Core/"]
RUN dotnet restore "Here.Api/Here.Api.csproj"
COPY . .
WORKDIR "/src/Here.Api"
RUN dotnet build "Here.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Here.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER 1001
ENTRYPOINT ["dotnet", "Here.dll"]
