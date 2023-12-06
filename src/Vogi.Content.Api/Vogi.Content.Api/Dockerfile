#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Vogi.Content.Api/Vogi.ContentAutoat.Api.csproj", "Vogi.Content.Api/"]
COPY ["Vogi.Content.DbExtension/Vogi.ContentAutoat.DbExtension.csproj", "Vogi.Content.DbExtension/"]
COPY ["Vogi.ContentAutoat.Infrastructure/Vogi.ContentAutoat.Infrastructure.csproj", "Vogi.ContentAutoat.Infrastructure/"]
COPY ["Vogi.ContentAutoat.Domain/Vogi.ContentAutoat.Domain.csproj", "Vogi.ContentAutoat.Domain/"]
COPY ["Vogi.ContentAutoat.Application/Vogi.ContentAutoat.Application.csproj", "Vogi.ContentAutoat.Application/"]
COPY ["Vogi.ContentAutoat.Repository/Vogi.ContentAutoat.Repository.csproj", "Vogi.ContentAutoat.Repository/"]
RUN dotnet restore "Vogi.Content.Api/Vogi.ContentAutoat.Api.csproj"
COPY . .
WORKDIR "/src/Vogi.Content.Api"
RUN dotnet build "Vogi.ContentAutoat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vogi.ContentAutoat.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vogi.ContentAutoat.Api.dll"]