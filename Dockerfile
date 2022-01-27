FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /
# COPY . .
COPY ["/src/.", "src/"]
# COPY ["/src/Here.Api/Here.Api.csproj", "Here.Api/"]
# COPY ["/src/Here.Core/Here.Core.csproj", "Here.Core/"]
# WORKDIR "/Here.Core/"
# RUN dotnet restore "Here.Core.csproj"
# RUN dotnet build "Here.Core.csproj" -c Release -o /app/build

# WORKDIR "/Here.Api/"
RUN dotnet restore "src/Here.Api/Here.Api.csproj"
RUN dotnet build "src/Here.Api/Here.Api.csproj" -c Release -o /app/build
#COPY . .

FROM build AS publish
RUN dotnet publish "src/Here.Api/Here.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER 1001
ENTRYPOINT ["dotnet", "Here.dll"]
