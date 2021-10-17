#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Validata.API/Validata.API.csproj", "Validata.API/"]
COPY ["Validata.Infrastructure/Validata.Infrastructure.csproj", "Validata.Infrastructure/"]
COPY ["Validata.Domain/Validata.Domain.csproj", "Validata.Domain/"]
RUN dotnet restore "Validata.API/Validata.API.csproj"
COPY . .
WORKDIR "/src/Validata.API"
RUN dotnet build "Validata.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Validata.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Validata.API.dll"]
